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
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/articleitems")]
    public class ArticleItemController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<ArticleItem> _articleItemsRepository;

        public ArticleItemController(IEntityBaseRepository<ArticleItem> articleItemsRepository,
            IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            _articleItemsRepository = articleItemsRepository;
        }

        [Route("articleitems/{id:int}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var articleItem = _articleItemsRepository.GetSingle(id);

                ArticleItemViewModel articleItemVM = Mapper.Map<ArticleItem, ArticleItemViewModel>(articleItem);

                response = request.CreateResponse<ArticleItemViewModel>(HttpStatusCode.OK, articleItemVM);

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
                List<ArticleItem> articleItems = null;
                int totalArticles = new int();

                if (!string.IsNullOrEmpty(filter))
                {
                    articleItems = _articleItemsRepository
                        .FindBy(m => m.ComponentItemID.ToLower()
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
    }
}