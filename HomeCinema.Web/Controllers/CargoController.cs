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
    [RoutePrefix("api/cargos")]
    public class CargoController : ApiControllerBase
    {
        private readonly IEntityBaseRepositoryString<Cargo> _cargosRepository;

        public CargoController(IEntityBaseRepositoryString<Cargo> cargosRepository,
            IEntityBaseRepositoryInetger<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            _cargosRepository = cargosRepository;
        }

        [Route("cargos/{id:int}")]
        public HttpResponseMessage Get(HttpRequestMessage request, string id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var cargo = _cargosRepository.GetSingle(id);

                CargoViewModel cargoVM = Mapper.Map<Cargo, CargoViewModel>(cargo);

                response = request.CreateResponse<CargoViewModel>(HttpStatusCode.OK, cargoVM);

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
                List<Cargo> cargos = null;
                int totalCargos = new int();

                if (!string.IsNullOrEmpty(filter))
                {
                    cargos = _cargosRepository
                        .FindBy(m => m.ArticleID.ToString().ToLower()
                        .Contains(filter.ToLower().Trim()))
                        .OrderBy(m => m.ID)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                    totalCargos = _cargosRepository
                        .FindBy(m => m.BarcodeID.ToString().ToLower()
                        .Contains(filter.ToLower().Trim()))
                        .Count();
                }
                else
                {
                    cargos = _cargosRepository
                        .GetAll()
                        .OrderBy(m => m.ID)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                    totalCargos = _cargosRepository.GetAll().Count();
                }

                IEnumerable<CargoViewModel> cargosVM = Mapper.Map<IEnumerable<Cargo>, IEnumerable<CargoViewModel>>(cargos);

                PaginationSet<CargoViewModel> pagedSet = new PaginationSet<CargoViewModel>()
                {
                    Page = currentPage,
                    TotalCount = totalCargos,
                    TotalPages = (int)Math.Ceiling((decimal)totalCargos / currentPageSize),
                    Items = cargosVM
                };

                response = request.CreateResponse<PaginationSet<CargoViewModel>>(HttpStatusCode.OK, pagedSet);

                return response;
            });
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(HttpRequestMessage request, CargoViewModel cargo)
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
                    Cargo newCargo = new Cargo();
                    newCargo.UpdateCargo(cargo);
                    _cargosRepository.Add(newCargo);

                    _unitOfWork.Commit();

                    // Update view model
                    cargo = Mapper.Map<Cargo, CargoViewModel>(newCargo);
                    response = request.CreateResponse<CargoViewModel>(HttpStatusCode.Created, cargo);
                }

                return response;
            });
        }

        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, CargoViewModel cargo)
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
                    var cargoDb = _cargosRepository.GetSingle(cargo.ID);
                    if (cargoDb == null)
                        response = request.CreateErrorResponse(HttpStatusCode.NotFound, "محموله انتخاب شده نا معتبر است");
                    else
                    {
                        cargoDb.UpdateCargo(cargo);
                        _cargosRepository.Edit(cargoDb);

                        _unitOfWork.Commit();
                        response = request.CreateResponse<CargoViewModel>(HttpStatusCode.OK, cargo);
                    }
                }

                return response;
            });
        }
    }
}