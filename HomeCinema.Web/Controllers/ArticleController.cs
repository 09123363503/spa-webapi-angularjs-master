using AutoMapper;
using HomeCinema.Data.Infrastructure;
using HomeCinema.Data.Repositories;
using HomeCinema.Entities;
using HomeCinema.Web.Infrastructure.Core;
using HomeCinema.Web.Infrastructure.Extensions.Warehouse;
using HomeCinema.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using HomeCinema.Web.Infrastructure.Extensions;
using HomeCinema.Data.Extensions;

namespace HomeCinema.Web.Controllers
{
    //[Authorize(Roles = "Admin")]
    [RoutePrefix("api/articles")]
    public class ArticlesController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Article> _articlesRepository;

        public ArticlesController(IEntityBaseRepository<Article> articlesRepository,
            IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            _articlesRepository = articlesRepository;
        }

        [Route("articles/{id:int}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var article = _articlesRepository.GetSingle(id);

                ArticleViewModel articleVM = Mapper.Map<Article, ArticleViewModel>(article);

                response = request.CreateResponse<ArticleViewModel>(HttpStatusCode.OK, articleVM);

                return response;
            });
        }

        [AllowAnonymous]
        [Route("{page:int=0}/{pageSize=3}/{filter?}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int? page, int? pageSize, string filter = null)
        {
            int currentPage = page.Value;
            int currentPageSize = pageSize.Value;

            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                List<Article> articles = null;
                int totalArticles = new int();

                if (!string.IsNullOrEmpty(filter))
                {
                    articles = _articlesRepository
                        .FindBy(m => m.Name.ToLower()
                        .Contains(filter.ToLower().Trim()))
                        .OrderBy(m => m.ID)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                    totalArticles = _articlesRepository
                        .FindBy(m => m.Name.ToLower()
                        .Contains(filter.ToLower().Trim()))
                        .Count();
                }
                else
                {
                    articles = _articlesRepository
                        .GetAll()
                        .OrderBy(m => m.ID)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                    totalArticles = _articlesRepository.GetAll().Count();
                }

                IEnumerable<ArticleViewModel> articlesVM = Mapper.Map<IEnumerable<Article>, IEnumerable<ArticleViewModel>>(articles);

                PaginationSet<ArticleViewModel> pagedSet = new PaginationSet<ArticleViewModel>()
                {
                    Page = currentPage,
                    TotalCount = totalArticles,
                    TotalPages = (int)Math.Ceiling((decimal)totalArticles / currentPageSize),
                    Items = articlesVM
                };

                response = request.CreateResponse<PaginationSet<ArticleViewModel>>(HttpStatusCode.OK, pagedSet);

                return response;
            });
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(HttpRequestMessage request, ArticleViewModel article)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    Article newArticle = new Article();
                    newArticle.UpdateArticle(article);
                    _articlesRepository.Add(newArticle);

                    _unitOfWork.Commit();

                    // Update view model
                    article = Mapper.Map<Article, ArticleViewModel>(newArticle);
                    response = request.CreateResponse<ArticleViewModel>(HttpStatusCode.Created, article);
                }

                return response;
            });
        }

        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, ArticleViewModel article)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var articleDb = _articlesRepository.GetSingle(article.ID);
                    if (articleDb == null)
                        response = request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid movie.");
                    else
                    {
                        articleDb.UpdateArticle(article);
                        _articlesRepository.Edit(articleDb);

                        _unitOfWork.Commit();
                        response = request.CreateResponse<ArticleViewModel>(HttpStatusCode.OK, article);
                    }
                }

                return response;
            });
        }
    }
}