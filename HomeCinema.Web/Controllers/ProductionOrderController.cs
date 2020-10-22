using AutoMapper;
using HomeCinema.Data.Infrastructure;
using HomeCinema.Data.Repositories;
using HomeCinema.Entities;
using HomeCinema.Web.Infrastructure.Core;
using HomeCinema.Web.Infrastructure.Extensions.BarcodeStructureOperation;
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
    [RoutePrefix("api/ProductionOrders")]
    public class ProductoinOrderController : ApiControllerBase
    {
        private readonly IEntityBaseRepositoryInetger<ProductionOrder> _productionOrdersRepository;

        public ProductoinOrderController(IEntityBaseRepositoryInetger<ProductionOrder> productionOrdersRepository,
            IEntityBaseRepositoryInetger<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            _productionOrdersRepository = productionOrdersRepository;
        }

        [Route("productionorders/{id:int}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var productionOrder = _productionOrdersRepository.GetSingle(id);

                ProductionOrderViewModel productionOrderVM = Mapper.Map<ProductionOrder, ProductionOrderViewModel>(productionOrder);

                response = request.CreateResponse<ProductionOrderViewModel>(HttpStatusCode.OK, productionOrderVM);

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
                List<ProductionOrder> productionOrders = null;
                int totalProductionOrders = new int();

                if (!string.IsNullOrEmpty(filter))
                {
                    productionOrders = _productionOrdersRepository
                        .FindBy(m => m.Number.ToString().ToLower()
                        .Contains(filter.ToLower().Trim()))
                        .OrderBy(m => m.ID)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                    totalProductionOrders = _productionOrdersRepository
                        .FindBy(m => m.Number.ToString().ToLower()
                        .Contains(filter.ToLower().Trim()))
                        .Count();
                }
                else
                {
                    productionOrders = _productionOrdersRepository
                        .GetAll()
                        .OrderBy(m => m.ID)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                    totalProductionOrders = _productionOrdersRepository.GetAll().Count();
                }

                IEnumerable<ProductionOrderViewModel> productionOrderVM = Mapper.Map<IEnumerable<ProductionOrder>, IEnumerable<ProductionOrderViewModel>>(productionOrders);

                PaginationSet<ProductionOrderViewModel> pagedSet = new PaginationSet<ProductionOrderViewModel>()
                {
                    Page = currentPage,
                    TotalCount = totalProductionOrders,
                    TotalPages = (int)Math.Ceiling((decimal)totalProductionOrders / currentPageSize),
                    Items = productionOrderVM
                };

                response = request.CreateResponse<PaginationSet<ProductionOrderViewModel>>(HttpStatusCode.OK, pagedSet);

                return response;
            });
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(HttpRequestMessage request, ProductionOrderViewModel productionOrder)
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
                    ProductionOrder newProductionOrder = new ProductionOrder();
                    newProductionOrder.UpdateProductionOrder(productionOrder);
                    _productionOrdersRepository.Add(newProductionOrder);

                    _unitOfWork.Commit();

                    // Update view model
                    productionOrder = Mapper.Map<ProductionOrder, ProductionOrderViewModel>(newProductionOrder);
                    response = request.CreateResponse<ProductionOrderViewModel>(HttpStatusCode.Created, productionOrder);
                }

                return response;
            });
        }

        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, ProductionOrderViewModel productionOrder)
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
                    var productionOrderDb = _productionOrdersRepository.GetSingle(productionOrder.ID);
                    if (productionOrderDb == null)
                        response = request.CreateErrorResponse(HttpStatusCode.NotFound, "سفارش تولید انتخاب شده نا معتبر است");
                    else
                    {
                        productionOrderDb.UpdateProductionOrder(productionOrder);
                        _productionOrdersRepository.Edit(productionOrderDb);

                        _unitOfWork.Commit();
                        response = request.CreateResponse<ProductionOrderViewModel>(HttpStatusCode.OK, productionOrder);
                    }
                }

                return response;
            });
        }
    }
}