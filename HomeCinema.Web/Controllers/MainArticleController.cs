using AutoMapper;
using HomeCinema.Data.Infrastructure;
using HomeCinema.Data.Repositories;
using HomeCinema.Entities;
using HomeCinema.Services;
using HomeCinema.Services.Utilities;
using HomeCinema.Web.Infrastructure.Core;
using HomeCinema.Web.Infrastructure.Extensions.WarehouseOperation;
using HomeCinema.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HomeCinema.Web.Infrastructure.Extensions;

namespace HomeCinema.Web.Controllers
{
    //[Authorize(Role = "Admin")]
    [RoutePrefix("api/mainarticle")]
    public class MainArticleController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<MainArticle> _mainArticleRepository;

        public MainArticleController(IEntityBaseRepository<MainArticle> mainArticleRepository,
            IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            _mainArticleRepository = mainArticleRepository;
        }

        [AllowAnonymous]
        [Route("latest")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var mainArticles = _mainArticleRepository.GetAll().OrderByDescending(m => m.Code).Take(50).ToList();

                IEnumerable<MainArticleViewModel> mainArticlesVM = Mapper.Map<IEnumerable<MainArticle>, IEnumerable<MainArticleViewModel>>(mainArticles);

                response = request.CreateResponse<IEnumerable<MainArticleViewModel>>(HttpStatusCode.OK, mainArticlesVM);

                return response;
            });
        }

        [Route("mainarticledetails/{id:int}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var mainArticle = _mainArticleRepository.GetSingle(id);

                MainArticleViewModel mainArticleVM = Mapper.Map<MainArticle, MainArticleViewModel>(mainArticle);

                response = request.CreateResponse<MainArticleViewModel>(HttpStatusCode.OK, mainArticleVM);

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
                List<MainArticle> mainArticles = null;
                int totalMainArticles = new int();

                if (!string.IsNullOrEmpty(filter))
                {
                    mainArticles = _mainArticleRepository
                        .FindBy(m => m.Name.ToLower()
                        .Contains(filter.ToLower().Trim()))
                        .OrderBy(m => m.ID)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                    totalMainArticles = _mainArticleRepository
                        .FindBy(m => m.Name.ToLower()
                        .Contains(filter.ToLower().Trim()))
                        .Count();
                }
                else
                {
                    mainArticles = _mainArticleRepository
                        .GetAll()
                        .OrderBy(m => m.ID)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                    totalMainArticles = _mainArticleRepository.GetAll().Count();
                }

                IEnumerable<MainArticleViewModel> mainArticlesVM = Mapper.Map<IEnumerable<MainArticle>, IEnumerable<MainArticleViewModel>>(mainArticles);

                PaginationSet<MainArticleViewModel> pagedSet = new PaginationSet<MainArticleViewModel>()
                {
                    Page = currentPage,
                    TotalCount = totalMainArticles,
                    TotalPages = (int)Math.Ceiling((decimal)totalMainArticles / currentPageSize),
                    Items = mainArticlesVM
                };

                response = request.CreateResponse<PaginationSet<MainArticleViewModel>>(HttpStatusCode.OK, pagedSet);

                return response;
            });
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(HttpRequestMessage request, MainArticleViewModel mainArticle)
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
                    MainArticle newMainArticle = new MainArticle();
                    newMainArticle.UpdateMainArticle(mainArticle);

                    //for (int i = 0; i < movie.NumberOfStocks; i++) // work at this part for mainarticle
                    //{
                    //    Stock stock = new Stock()
                    //    {
                    //        IsAvailable = true,
                    //        Movie = newMovie,
                    //        UniqueKey = Guid.NewGuid()
                    //    };
                    //    newMovie.Stocks.Add(stock);
                    //}

                    _mainArticleRepository.Add(newMainArticle);
                    _unitOfWork.Commit();

                    // Update view model
                    mainArticle = Mapper.Map<MainArticle, MainArticleViewModel>(newMainArticle);
                    response = request.CreateResponse<MainArticleViewModel>(HttpStatusCode.Created, mainArticle);
                }

                return response;
            });
        }

        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, MainArticleViewModel mainArticle)
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
                    var mainArticleDb = _mainArticleRepository.GetSingle(mainArticle.ID);
                    if (mainArticleDb == null)
                        response = request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid movie.");
                    else
                    {
                        mainArticleDb.UpdateMainArticle(mainArticle);
                        _mainArticleRepository.Edit(mainArticleDb);

                        _unitOfWork.Commit();
                        response = request.CreateResponse<MainArticleViewModel>(HttpStatusCode.OK, mainArticle);
                    }
                }

                return response;
            });
        }


    }
}