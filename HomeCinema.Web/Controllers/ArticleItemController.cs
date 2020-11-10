using AutoMapper;
using HomeCinema.Data.Infrastructure;
using HomeCinema.Data.Repositories;
using HomeCinema.Entities;
using HomeCinema.Web.Infrastructure.Core;
using HomeCinema.Web.Infrastructure.Extensions.WarehouseOperation;
using HomeCinema.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HomeCinema.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/articleitems")]
    public class ArticleItemController : ApiControllerBase
    {
        private readonly IEntityBaseRepositoryInetger<ArticleItem> _articleItemsRepository;

        public ArticleItemController(IEntityBaseRepositoryInetger<ArticleItem> articleItemsRepository,
            IEntityBaseRepositoryInetger<Error> _errorsRepository, IUnitOfWork _unitOfWork)
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
                int totalArticleItems = new int();

                if (!string.IsNullOrEmpty(filter))
                {
                    articleItems = _articleItemsRepository
                        .FindBy(m => m.ArticleID.ToString()
                        .Contains(filter.ToLower().Trim()))
                        .OrderBy(m => m.ID)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                    totalArticleItems = _articleItemsRepository
                        .FindBy(m => m.ArticleID.ToString()
                        .Contains(filter.ToLower().Trim()))
                        .Count();
                }
                else
                {
                    articleItems = _articleItemsRepository
                        .GetAll()
                        .OrderBy(m => m.ID)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                    totalArticleItems = _articleItemsRepository.GetAll().Count();
                }

                IEnumerable<ArticleItemViewModel> articleItemsVM = Mapper.Map<IEnumerable<ArticleItem>, IEnumerable<ArticleItemViewModel>>(articleItems);

                PaginationSet<ArticleItemViewModel> pagedSet = new PaginationSet<ArticleItemViewModel>()
                {
                    Page = currentPage,
                    TotalCount = totalArticleItems,
                    TotalPages = (int)Math.Ceiling((decimal)totalArticleItems / currentPageSize),
                    Items = articleItemsVM
                };

                response = request.CreateResponse<PaginationSet<ArticleItemViewModel>>(HttpStatusCode.OK, pagedSet);

                return response;
            });
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(HttpRequestMessage request, ArticleItemViewModel articleItem)
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
                    ArticleItem newArticleItem = new ArticleItem();
                    newArticleItem.UpdateArticleItem(articleItem);
                    _articleItemsRepository.Add(newArticleItem);

                    _unitOfWork.Commit();

                    // Update view model
                    articleItem = Mapper.Map<ArticleItem, ArticleItemViewModel>(newArticleItem);
                    response = request.CreateResponse<ArticleItemViewModel>(HttpStatusCode.Created, articleItem);
                }

                return response;
            });
        }

        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, ArticleItemViewModel articleItem)
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
                    var articleItemDb = _articleItemsRepository.GetSingle(articleItem.ID);
                    if (articleItemDb == null)
                        response = request.CreateErrorResponse(HttpStatusCode.NotFound, "مورد انتخاب شده نامعتبر است");
                    else
                    {
                        articleItemDb.UpdateArticleItem(articleItem);
                        _articleItemsRepository.Edit(articleItemDb);

                        _unitOfWork.Commit();
                        response = request.CreateResponse<ArticleItemViewModel>(HttpStatusCode.OK, articleItem);
                    }
                }

                return response;
            });
        }
    }
}