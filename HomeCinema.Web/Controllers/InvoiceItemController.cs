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
using HomeCinema.Web.Infrastructure.Extensions.DocumentOperation;

namespace HomeCinema.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/InvoiceItems")]
    public class InvoiceItemController : ApiControllerBase
    {
        private readonly IEntityBaseRepositoryString<InvoiceItem> _InvoiceItemsRepository;

        public InvoiceItemController(IEntityBaseRepositoryString<InvoiceItem> InvoiceItemsRepository,
            IEntityBaseRepositoryInetger<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            _InvoiceItemsRepository = InvoiceItemsRepository;
        }

        [Route("InvoiceItems/{id:int}")]
        public HttpResponseMessage Get(HttpRequestMessage request, string id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var InvoiceItem = _InvoiceItemsRepository.GetSingle(id);

                InvoiceItemViewModel InvoiceItemVM = Mapper.Map<InvoiceItem, InvoiceItemViewModel>(InvoiceItem);

                response = request.CreateResponse<InvoiceItemViewModel>(HttpStatusCode.OK, InvoiceItemVM);

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
                List<InvoiceItem> InvoiceItems = null;
                int totalInvoiceItems = new int();

                if (!string.IsNullOrEmpty(filter))
                {
                    InvoiceItems = _InvoiceItemsRepository
                        .FindBy(m => m.UnitPrice.ToString().ToLower()
                        .Contains(filter.ToLower().Trim()))
                        .OrderBy(m => m.ID)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                    totalInvoiceItems = _InvoiceItemsRepository
                        .FindBy(m => m.UnitPrice.ToString().ToLower()
                        .Contains(filter.ToLower().Trim()))
                        .Count();
                }
                else
                {
                    InvoiceItems = _InvoiceItemsRepository
                        .GetAll()
                        .OrderBy(m => m.ID)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                    totalInvoiceItems = _InvoiceItemsRepository.GetAll().Count();
                }

                IEnumerable<InvoiceItemViewModel> InvoiceItemVM = Mapper.Map<IEnumerable<InvoiceItem>, IEnumerable<InvoiceItemViewModel>>(InvoiceItems);

                PaginationSet<InvoiceItemViewModel> pagedSet = new PaginationSet<InvoiceItemViewModel>()
                {
                    Page = currentPage,
                    TotalCount = totalInvoiceItems,
                    TotalPages = (int)Math.Ceiling((decimal)totalInvoiceItems / currentPageSize),
                    Items = InvoiceItemVM
                };

                response = request.CreateResponse<PaginationSet<InvoiceItemViewModel>>(HttpStatusCode.OK, pagedSet);

                return response;
            });
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(HttpRequestMessage request, InvoiceItemViewModel InvoiceItem)
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
                    InvoiceItem newInvoiceItem = new InvoiceItem();
                    newInvoiceItem.UpdateInvoiceItem(InvoiceItem);
                    _InvoiceItemsRepository.Add(newInvoiceItem);

                    _unitOfWork.Commit();

                    // Update view model
                    InvoiceItem = Mapper.Map<InvoiceItem, InvoiceItemViewModel>(newInvoiceItem);
                    response = request.CreateResponse<InvoiceItemViewModel>(HttpStatusCode.Created, InvoiceItem);
                }

                return response;
            });
        }

        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, InvoiceItemViewModel InvoiceItem)
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
                    var InvoiceItemDb = _InvoiceItemsRepository.GetSingle(InvoiceItem.ID);
                    if (InvoiceItemDb == null)
                        response = request.CreateErrorResponse(HttpStatusCode.NotFound, "فاکتور انتخاب شده نامعتبر است");
                    else
                    {
                        InvoiceItemDb.UpdateInvoiceItem(InvoiceItem);
                        _InvoiceItemsRepository.Edit(InvoiceItemDb);

                        _unitOfWork.Commit();
                        response = request.CreateResponse<InvoiceItemViewModel>(HttpStatusCode.OK, InvoiceItem);
                    }
                }

                return response;
            });
        }
    }
}