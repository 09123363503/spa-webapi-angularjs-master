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
    [RoutePrefix("api/mainarticlecomponents")]
    public class MainArticleComponentController : ApiControllerBase
    {
        private readonly IEntityBaseRepositoryInetger<MainArticleComponent> _mainArticleComponentsRepository;

        public MainArticleComponentController(IEntityBaseRepositoryInetger<MainArticleComponent> mainArticleComponentsRepository,
            IEntityBaseRepositoryInetger<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            _mainArticleComponentsRepository = mainArticleComponentsRepository;
        }

        [Route("mainarticlecomponents/{id:int}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var mainArticleComponent = _mainArticleComponentsRepository.GetSingle(id);

                MainArticleComponentViewModel mainArticleComponentVM = Mapper.Map<MainArticleComponent, MainArticleComponentViewModel>(mainArticleComponent);

                response = request.CreateResponse<MainArticleComponentViewModel>(HttpStatusCode.OK, mainArticleComponentVM);

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
                List<MainArticleComponent> mainArticleComponents = null;
                int totalMainArticleComponents = new int();

                if (!string.IsNullOrEmpty(filter))
                {
                    mainArticleComponents = _mainArticleComponentsRepository
                        .FindBy(m => m.Name.ToLower()
                        .Contains(filter.ToLower().Trim()))
                        .OrderBy(m => m.ID)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                    totalMainArticleComponents = _mainArticleComponentsRepository
                        .FindBy(m => m.Name.ToLower()
                        .Contains(filter.ToLower().Trim()))
                        .Count();
                }
                else
                {
                    mainArticleComponents = _mainArticleComponentsRepository
                        .GetAll()
                        .OrderBy(m => m.ID)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                    totalMainArticleComponents = _mainArticleComponentsRepository.GetAll().Count();
                }

                IEnumerable<MainArticleComponentViewModel> mainArticleComponentsVM = Mapper.Map<IEnumerable<MainArticleComponent>, IEnumerable<MainArticleComponentViewModel>>(mainArticleComponents);

                PaginationSet<MainArticleComponentViewModel> pagedSet = new PaginationSet<MainArticleComponentViewModel>()
                {
                    Page = currentPage,
                    TotalCount = totalMainArticleComponents,
                    TotalPages = (int)Math.Ceiling((decimal)totalMainArticleComponents / currentPageSize),
                    Items = mainArticleComponentsVM
                };

                response = request.CreateResponse<PaginationSet<MainArticleComponentViewModel>>(HttpStatusCode.OK, pagedSet);

                return response;
            });
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(HttpRequestMessage request, MainArticleComponentViewModel mainArticleComponent)
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
                    MainArticleComponent newMainArticleComponent = new MainArticleComponent();
                    newMainArticleComponent.UpdateMainArticleComponent(mainArticleComponent);
                    _mainArticleComponentsRepository.Add(newMainArticleComponent);

                    _unitOfWork.Commit();

                    // Update view model
                    mainArticleComponent = Mapper.Map<MainArticleComponent, MainArticleComponentViewModel>(newMainArticleComponent);
                    response = request.CreateResponse<MainArticleComponentViewModel>(HttpStatusCode.Created, mainArticleComponent);
                }

                return response;
            });
        }

        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, MainArticleComponentViewModel mainArticleComponent)
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
                    var mainArticleComponentDb = _mainArticleComponentsRepository.GetSingle(mainArticleComponent.ID);
                    if (mainArticleComponentDb == null)
                        response = request.CreateErrorResponse(HttpStatusCode.NotFound, "ردیف انتخاب شده معتبر نمی باشد");
                    else
                    {
                        mainArticleComponentDb.UpdateMainArticleComponent(mainArticleComponent);
                        _mainArticleComponentsRepository.Edit(mainArticleComponentDb);

                        _unitOfWork.Commit();
                        response = request.CreateResponse<MainArticleComponentViewModel>(HttpStatusCode.OK, mainArticleComponent);
                    }
                }

                return response;
            });
        }
    }
}