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
    [RoutePrefix("api/barcodes")]
    public class BarcodeController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Barcode> _barcodesRepository;

        public BarcodeController(IEntityBaseRepository<Barcode> barcodesRepository,
            IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            _barcodesRepository = barcodesRepository;
        }

        [Route("barcodes/{id:int}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var barcode = _barcodesRepository.GetSingle(id);

                BarcodeViewModel barcodeVM = Mapper.Map<Barcode, BarcodeViewModel>(barcode);

                response = request.CreateResponse<BarcodeViewModel>(HttpStatusCode.OK, barcodeVM);

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
                List<Barcode> barcodes = null;
                int totalBarcodes = new int();

                if (!string.IsNullOrEmpty(filter))
                {
                    barcodes = _barcodesRepository
                        .FindBy(m => m.BarcodeString.ToLower()
                        .Contains(filter.ToLower().Trim()))
                        .OrderBy(m => m.ID)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                    totalBarcodes = _barcodesRepository
                        .FindBy(m => m.BarcodeString.ToLower()
                        .Contains(filter.ToLower().Trim()))
                        .Count();
                }
                else
                {
                    barcodes = _barcodesRepository
                        .GetAll()
                        .OrderBy(m => m.ID)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                    totalBarcodes = _barcodesRepository.GetAll().Count();
                }

                IEnumerable<BarcodeViewModel> barcodesVM = Mapper.Map<IEnumerable<Barcode>, IEnumerable<BarcodeViewModel>>(barcodes);

                PaginationSet<BarcodeViewModel> pagedSet = new PaginationSet<BarcodeViewModel>()
                {
                    Page = currentPage,
                    TotalCount = totalBarcodes,
                    TotalPages = (int)Math.Ceiling((decimal)totalBarcodes / currentPageSize),
                    Items = barcodesVM
                };

                response = request.CreateResponse<PaginationSet<BarcodeViewModel>>(HttpStatusCode.OK, pagedSet);

                return response;
            });
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(HttpRequestMessage request, BarcodeViewModel barcode)
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
                    Barcode newBarcode = new Barcode();
                    newBarcode.UpdateBarcode(barcode);
                    _barcodesRepository.Add(newBarcode);

                    _unitOfWork.Commit();

                    // Update view model
                    barcode = Mapper.Map<Barcode, BarcodeViewModel>(newBarcode);
                    response = request.CreateResponse<BarcodeViewModel>(HttpStatusCode.Created, barcode);
                }

                return response;
            });
        }

        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, BarcodeViewModel barcode)
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
                    var barcodeDb = _barcodesRepository.GetSingle(barcode.ID);
                    if (barcodeDb == null)
                        response = request.CreateErrorResponse(HttpStatusCode.NotFound, "بارکد نا معتبر است");
                    else
                    {
                        barcodeDb.UpdateBarcode(barcode);
                        _barcodesRepository.Edit(barcodeDb);

                        _unitOfWork.Commit();
                        response = request.CreateResponse<BarcodeViewModel>(HttpStatusCode.OK, barcode);
                    }
                }

                return response;
            });
        }
    }
}