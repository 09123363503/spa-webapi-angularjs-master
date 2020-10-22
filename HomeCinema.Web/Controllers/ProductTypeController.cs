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
    [RoutePrefix("api/ProductTypes")]
    public class ProductTypeController : ApiControllerBase
    {
        private readonly IEntityBaseRepositoryInetger<ProductType> _productTypesRepository;

        public ProductTypeController(IEntityBaseRepositoryInetger<ProductType> productTypesRepository,
            IEntityBaseRepositoryInetger<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            _productTypesRepository = productTypesRepository;
        }

        [Route("productTypes/{id:int}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var productType = _productTypesRepository.GetSingle(id);

                ProductTypeViewModel productTypeVM = Mapper.Map<ProductType, ProductTypeViewModel>(productType);

                response = request.CreateResponse<ProductTypeViewModel>(HttpStatusCode.OK, productTypeVM);

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
                List<ProductType> productTypes = null;
                int totalProductTypes = new int();

                if (!string.IsNullOrEmpty(filter))
                {
                    productTypes = _productTypesRepository
                        .FindBy(m => m.Name.ToLower()
                        .Contains(filter.ToLower().Trim()))
                        .OrderBy(m => m.ID)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                    totalProductTypes = _productTypesRepository
                        .FindBy(m => m.Name.ToLower()
                        .Contains(filter.ToLower().Trim()))
                        .Count();
                }
                else
                {
                    productTypes = _productTypesRepository
                        .GetAll()
                        .OrderBy(m => m.ID)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                    totalProductTypes = _productTypesRepository.GetAll().Count();
                }

                IEnumerable<ProductTypeViewModel> productTypeVM = Mapper.Map<IEnumerable<ProductType>, IEnumerable<ProductTypeViewModel>>(productTypes);

                PaginationSet<ProductTypeViewModel> pagedSet = new PaginationSet<ProductTypeViewModel>()
                {
                    Page = currentPage,
                    TotalCount = totalProductTypes,
                    TotalPages = (int)Math.Ceiling((decimal)totalProductTypes / currentPageSize),
                    Items = productTypeVM
                };

                response = request.CreateResponse<PaginationSet<ProductTypeViewModel>>(HttpStatusCode.OK, pagedSet);

                return response;
            });
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(HttpRequestMessage request, ProductTypeViewModel productType)
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
                    ProductType newProductType = new ProductType();
                    newProductType.UpdateProductType(productType);
                    _productTypesRepository.Add(newProductType);

                    _unitOfWork.Commit();

                    // Update view model
                    productType = Mapper.Map<ProductType, ProductTypeViewModel>(newProductType);
                    response = request.CreateResponse<ProductTypeViewModel>(HttpStatusCode.Created, productType);
                }

                return response;
            });
        }

        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, ProductTypeViewModel productType)
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
                    var productTypeDb = _productTypesRepository.GetSingle(productType.ID);
                    if (productTypeDb == null)
                        response = request.CreateErrorResponse(HttpStatusCode.NotFound, " مورد سفارش تولید انتخاب شده نا معتبر است");
                    else
                    {
                        productTypeDb.UpdateProductType(productType);
                        _productTypesRepository.Edit(productTypeDb);

                        _unitOfWork.Commit();
                        response = request.CreateResponse<ProductTypeViewModel>(HttpStatusCode.OK, productType);
                    }
                }

                return response;
            });
        }
    }
}