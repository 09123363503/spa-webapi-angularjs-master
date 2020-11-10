using AutoMapper;
using HomeCinema.Data.Infrastructure;
using HomeCinema.Data.Repositories;
using HomeCinema.Entities;
using HomeCinema.Web.Infrastructure.Core;
using HomeCinema.Web.Infrastructure.Extensions.BarcodeStructureOperation;
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
    [RoutePrefix("api/warehouses")]
    public class WarehouseController : ApiControllerBase
    {
        private readonly IEntityBaseRepositoryInetger<Warehouse> _warehousesRepository;

        public WarehouseController(IEntityBaseRepositoryInetger<Warehouse> warehousesRepository,
            IEntityBaseRepositoryInetger<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            _warehousesRepository = warehousesRepository;
        }

        [Route("warehouses/{id:int}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var warehouse = _warehousesRepository.GetSingle(id);

                WarehouseViewModel warehouseVM = Mapper.Map<Warehouse, WarehouseViewModel>(warehouse);

                response = request.CreateResponse<WarehouseViewModel>(HttpStatusCode.OK, warehouseVM);

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
                List<Warehouse> warehouses = null;
                int totalWarehouses = new int();

                if (!string.IsNullOrEmpty(filter))
                {
                    warehouses = _warehousesRepository
                        .FindBy(m => m.Name.ToLower()
                        .Contains(filter.ToLower().Trim()))
                        .OrderBy(m => m.ID)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                    totalWarehouses = _warehousesRepository
                        .FindBy(m => m.Name.ToLower()
                        .Contains(filter.ToLower().Trim()))
                        .Count();
                }
                else
                {
                    warehouses = _warehousesRepository
                        .GetAll()
                        .OrderBy(m => m.ID)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                    totalWarehouses = _warehousesRepository.GetAll().Count();
                }

                IEnumerable<WarehouseViewModel> warehouseVM = Mapper.Map<IEnumerable<Warehouse>, IEnumerable<WarehouseViewModel>>(warehouses);

                PaginationSet<WarehouseViewModel> pagedSet = new PaginationSet<WarehouseViewModel>()
                {
                    Page = currentPage,
                    TotalCount = totalWarehouses,
                    TotalPages = (int)Math.Ceiling((decimal)totalWarehouses / currentPageSize),
                    Items = warehouseVM
                };

                response = request.CreateResponse<PaginationSet<WarehouseViewModel>>(HttpStatusCode.OK, pagedSet);

                return response;
            });
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(HttpRequestMessage request, WarehouseViewModel warehouse)
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
                    Warehouse newWarehouse = new Warehouse();
                    newWarehouse.UpdateWarehouse(warehouse);
                    _warehousesRepository.Add(newWarehouse);

                    _unitOfWork.Commit();

                    // Update view model
                    warehouse = Mapper.Map<Warehouse, WarehouseViewModel>(newWarehouse);
                    response = request.CreateResponse<WarehouseViewModel>(HttpStatusCode.Created, warehouse);
                }

                return response;
            });
        }

        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, WarehouseViewModel warehouse)
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
                    var warehouseDb = _warehousesRepository.GetSingle(warehouse.ID);
                    if (warehouseDb == null)
                        response = request.CreateErrorResponse(HttpStatusCode.NotFound, "انبار انتخاب شده نامعتبر است");
                    else
                    {
                        warehouseDb.UpdateWarehouse(warehouse);
                        _warehousesRepository.Edit(warehouseDb);

                        _unitOfWork.Commit();
                        response = request.CreateResponse<WarehouseViewModel>(HttpStatusCode.OK, warehouse);
                    }
                }

                return response;
            });
        }
    }
}