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
    [RoutePrefix("api/ProductionOrderItems")]
    public class ProductoinOrderItemController : ApiControllerBase
    {
        private readonly IEntityBaseRepositoryInetger<ProductionOrderItem> _productionOrderItemsRepository;

        public ProductoinOrderItemController(IEntityBaseRepositoryInetger<ProductionOrderItem> productionOrderItemsRepository,
            IEntityBaseRepositoryInetger<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            _productionOrderItemsRepository = productionOrderItemsRepository;
        }

        [Route("productionorderItems/{id:int}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var productionOrderItem = _productionOrderItemsRepository.GetSingle(id);

                ProductionOrderItemViewModel productionOrderItemVM = Mapper.Map<ProductionOrderItem, ProductionOrderItemViewModel>(productionOrderItem);

                response = request.CreateResponse<ProductionOrderItemViewModel>(HttpStatusCode.OK, productionOrderItemVM);

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
                List<ProductionOrderItem> productionOrderItems = null;
                int totalProductionOrderItems = new int();

                if (!string.IsNullOrEmpty(filter))
                {
                    productionOrderItems = _productionOrderItemsRepository
                        .FindBy(m => m.ArticleID.ToString().ToLower()
                        .Contains(filter.ToLower().Trim()))
                        .OrderBy(m => m.ID)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                    totalProductionOrderItems = _productionOrderItemsRepository
                        .FindBy(m => m.ArticleID.ToString().ToLower()
                        .Contains(filter.ToLower().Trim()))
                        .Count();
                }
                else
                {
                    productionOrderItems = _productionOrderItemsRepository
                        .GetAll()
                        .OrderBy(m => m.ID)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                    totalProductionOrderItems = _productionOrderItemsRepository.GetAll().Count();
                }

                IEnumerable<ProductionOrderItemViewModel> productionOrderItemVM = Mapper.Map<IEnumerable<ProductionOrderItem>, IEnumerable<ProductionOrderItemViewModel>>(productionOrderItems);

                PaginationSet<ProductionOrderItemViewModel> pagedSet = new PaginationSet<ProductionOrderItemViewModel>()
                {
                    Page = currentPage,
                    TotalCount = totalProductionOrderItems,
                    TotalPages = (int)Math.Ceiling((decimal)totalProductionOrderItems / currentPageSize),
                    Items = productionOrderItemVM
                };

                response = request.CreateResponse<PaginationSet<ProductionOrderItemViewModel>>(HttpStatusCode.OK, pagedSet);

                return response;
            });
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(HttpRequestMessage request, ProductionOrderItemViewModel productionOrderItem)
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
                    ProductionOrderItem newProductionOrderItem = new ProductionOrderItem();
                    newProductionOrderItem.UpdateProductionOrderItem(productionOrderItem);
                    _productionOrderItemsRepository.Add(newProductionOrderItem);

                    _unitOfWork.Commit();

                    // Update view model
                    productionOrderItem = Mapper.Map<ProductionOrderItem, ProductionOrderItemViewModel>(newProductionOrderItem);
                    response = request.CreateResponse<ProductionOrderItemViewModel>(HttpStatusCode.Created, productionOrderItem);
                }

                return response;
            });
        }

        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, ProductionOrderItemViewModel productionOrderItem)
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
                    var productionOrderItemDb = _productionOrderItemsRepository.GetSingle(productionOrderItem.ID);
                    if (productionOrderItemDb == null)
                        response = request.CreateErrorResponse(HttpStatusCode.NotFound, " مورد سفارش تولید انتخاب شده نا معتبر است");
                    else
                    {
                        productionOrderItemDb.UpdateProductionOrderItem(productionOrderItem);
                        _productionOrderItemsRepository.Edit(productionOrderItemDb);

                        _unitOfWork.Commit();
                        response = request.CreateResponse<ProductionOrderItemViewModel>(HttpStatusCode.OK, productionOrderItem);
                    }
                }

                return response;
            });
        }
    }
}