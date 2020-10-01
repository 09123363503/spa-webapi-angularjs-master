using AutoMapper;
using HomeCinema.Data.Infrastructure;
using HomeCinema.Data.Repositories;
using HomeCinema.Entities;
using HomeCinema.Web.Infrastructure.Core;
using HomeCinema.Web.Infrastructure.Extensions.WarehouseOperation;
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
    [RoutePrefix("api/componentItems")]
    public class ComponentItemController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<ComponentItem> _componentItemsRepository;

        public ComponentItemController(IEntityBaseRepository<ComponentItem> componentItemsRepository,
            IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            _componentItemsRepository = componentItemsRepository;
        }

        [AllowAnonymous]
        [Route("latest")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var componentItems = _componentItemsRepository.GetAll().OrderByDescending(m => m.Code).Take(50).ToList();

                IEnumerable<ComponentItemViewModel> componentItemsVM = Mapper.Map<IEnumerable<ComponentItem>, IEnumerable<ComponentItemViewModel>>(componentItems);

                response = request.CreateResponse<IEnumerable<ComponentItemViewModel>>(HttpStatusCode.OK, componentItemsVM);

                return response;
            });
        }

        [Route("Items/{id:int}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var componentItem = _componentItemsRepository.GetSingle(id);

                ComponentItemViewModel componentItemVM = Mapper.Map<ComponentItem, ComponentItemViewModel>(componentItem);

                response = request.CreateResponse<ComponentItemViewModel>(HttpStatusCode.OK, componentItemVM);

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
                List<ComponentItem> componentItems = null;
                int totalComponentItems = new int();

                if (!string.IsNullOrEmpty(filter))
                {
                    componentItems = _componentItemsRepository
                        .FindBy(m => m.Name.ToLower()
                        .Contains(filter.ToLower().Trim()))
                        .OrderBy(m => m.ID)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                    totalComponentItems = _componentItemsRepository
                        .FindBy(m => m.Name.ToLower()
                        .Contains(filter.ToLower().Trim()))
                        .Count();
                }
                else
                {
                    componentItems = _componentItemsRepository
                        .GetAll()
                        .OrderBy(m => m.ID)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                    totalComponentItems = _componentItemsRepository.GetAll().Count();
                }

                IEnumerable<ComponentItemViewModel> componentItemsVM = Mapper.Map<IEnumerable<ComponentItem>, IEnumerable<ComponentItemViewModel>>(componentItems);

                PaginationSet<ComponentItemViewModel> pagedSet = new PaginationSet<ComponentItemViewModel>()
                {
                    Page = currentPage,
                    TotalCount = totalComponentItems,
                    TotalPages = (int)Math.Ceiling((decimal)totalComponentItems / currentPageSize),
                    Items = componentItemsVM
                };

                response = request.CreateResponse<PaginationSet<ComponentItemViewModel>>(HttpStatusCode.OK, pagedSet);

                return response;
            });
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(HttpRequestMessage request, ComponentItemViewModel componentItem)
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
                    ComponentItem newComponentItem = new ComponentItem();
                    newComponentItem.UpdateComponentItem(componentItem);

                    //for (int i = 0; i < movie.NumberOfStocks; i++)
                    //{
                    //    Stock stock = new Stock()
                    //    {
                    //        IsAvailable = true,
                    //        Movie = newMovie,
                    //        UniqueKey = Guid.NewGuid()
                    //    };
                    //    newMovie.Stocks.Add(stock);
                    //}

                    _componentItemsRepository.Add(newComponentItem);

                    _unitOfWork.Commit();

                    // Update view model
                    componentItem = Mapper.Map<ComponentItem, ComponentItemViewModel>(newComponentItem);
                    response = request.CreateResponse<ComponentItemViewModel>(HttpStatusCode.Created, componentItem);
                }

                return response;
            });
        }

        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, ComponentItemViewModel componentItem)
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
                    var componentItemDb = _componentItemsRepository.GetSingle(componentItem.ID);
                    if (componentItemDb == null)
                        response = request.CreateErrorResponse(HttpStatusCode.NotFound, "آیتم انتخاب شده نامعنبر است");
                    else
                    {
                        componentItemDb.UpdateComponentItem(componentItem);
                        _componentItemsRepository.Edit(componentItemDb);

                        _unitOfWork.Commit();
                        response = request.CreateResponse<ComponentItemViewModel>(HttpStatusCode.OK, componentItem);
                    }
                }

                return response;
            });
        }
    }
}