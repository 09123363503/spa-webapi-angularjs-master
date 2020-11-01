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
    [RoutePrefix("api/invoices")]
    public class InvoiceController : ApiControllerBase
    {
        private readonly IEntityBaseRepositoryString<Invoice> _invoicesRepository;

        public InvoiceController(IEntityBaseRepositoryString<Invoice> invoicesRepository,
            IEntityBaseRepositoryInetger<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            _invoicesRepository = invoicesRepository;
        }

        [Route("invoices/{id:int}")]
        public HttpResponseMessage Get(HttpRequestMessage request, string id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var invoice = _invoicesRepository.GetSingle(id);

                InvoiceViewModel invoiceVM = Mapper.Map<Invoice, InvoiceViewModel>(invoice);

                response = request.CreateResponse<InvoiceViewModel>(HttpStatusCode.OK, invoiceVM);

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
                List<Invoice> invoices = null;
                int totalInvoices = new int();

                if (!string.IsNullOrEmpty(filter))
                {
                    invoices = _invoicesRepository
                        .FindBy(m => m.Number.ToString().ToLower()
                        .Contains(filter.ToLower().Trim()))
                        .OrderBy(m => m.ID)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                    totalInvoices = _invoicesRepository
                        .FindBy(m => m.Number.ToString().ToLower()
                        .Contains(filter.ToLower().Trim()))
                        .Count();
                }
                else
                {
                    invoices = _invoicesRepository
                        .GetAll()
                        .OrderBy(m => m.ID)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                    totalInvoices = _invoicesRepository.GetAll().Count();
                }

                IEnumerable<InvoiceViewModel> invoiceVM = Mapper.Map<IEnumerable<Invoice>, IEnumerable<InvoiceViewModel>>(invoices);

                PaginationSet<InvoiceViewModel> pagedSet = new PaginationSet<InvoiceViewModel>()
                {
                    Page = currentPage,
                    TotalCount = totalInvoices,
                    TotalPages = (int)Math.Ceiling((decimal)totalInvoices / currentPageSize),
                    Items = invoiceVM
                };

                response = request.CreateResponse<PaginationSet<InvoiceViewModel>>(HttpStatusCode.OK, pagedSet);

                return response;
            });
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(HttpRequestMessage request, InvoiceViewModel invoice)
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
                    Invoice newInvoice = new Invoice();
                    newInvoice.UpdateInvoice(invoice);
                    _invoicesRepository.Add(newInvoice);

                    _unitOfWork.Commit();

                    // Update view model
                    invoice = Mapper.Map<Invoice, InvoiceViewModel>(newInvoice);
                    response = request.CreateResponse<InvoiceViewModel>(HttpStatusCode.Created, invoice);
                }

                return response;
            });
        }

        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, InvoiceViewModel invoice)
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
                    var invoiceDb = _invoicesRepository.GetSingle(invoice.ID);
                    if (invoiceDb == null)
                        response = request.CreateErrorResponse(HttpStatusCode.NotFound, "فاکتور انتخاب شده نامعتبر است");
                    else
                    {
                        invoiceDb.UpdateInvoice(invoice);
                        _invoicesRepository.Edit(invoiceDb);

                        _unitOfWork.Commit();
                        response = request.CreateResponse<InvoiceViewModel>(HttpStatusCode.OK, invoice);
                    }
                }

                return response;
            });
        }
    }
}