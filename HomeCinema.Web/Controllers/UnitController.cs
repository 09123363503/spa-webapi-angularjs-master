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
using System.Web;
using System.Web.Http;
using HomeCinema.Web.Infrastructure.Extensions;
using HomeCinema.Data.Extensions;
using System.Net.Http;
using System.Net;

namespace HomeCinema.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/units")]
    public class UnitsController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Unit> _unitsRepository;

        public UnitsController(IEntityBaseRepository<Unit> unitsRepository,
            IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            _unitsRepository = unitsRepository;
        }

        [AllowAnonymous]
        [Route("latest")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var units = _unitsRepository.GetAll().OrderByDescending(m => m.Code).Take(50).ToList();

                IEnumerable<UnitViewModel> unitsVM = Mapper.Map<IEnumerable<Unit>, IEnumerable<UnitViewModel>>(units);

                response = request.CreateResponse<IEnumerable<UnitViewModel>>(HttpStatusCode.OK, unitsVM);

                return response;
            });
        }

        [Route("details/{id:int}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var unit = _unitsRepository.GetSingle(id);

                UnitViewModel unitVM = Mapper.Map<Unit, UnitViewModel>(unit);

                response = request.CreateResponse<UnitViewModel>(HttpStatusCode.OK, unitVM);

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
                List<Unit> units = null;
                int totalUnits = new int();

                if (!string.IsNullOrEmpty(filter))
                {
                    units = _unitsRepository
                        .FindBy(m => m.Name.ToLower()
                        .Contains(filter.ToLower().Trim()))
                        .OrderBy(m => m.ID)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                    totalUnits = _unitsRepository
                        .FindBy(m => m.Name.ToLower()
                        .Contains(filter.ToLower().Trim()))
                        .Count();
                }
                else
                {
                    units = _unitsRepository
                        .GetAll()
                        .OrderBy(m => m.ID)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                    totalUnits = _unitsRepository.GetAll().Count();
                }

                IEnumerable<UnitViewModel> unitsVM = Mapper.Map<IEnumerable<Unit>, IEnumerable<UnitViewModel>>(units);

                PaginationSet<UnitViewModel> pagedSet = new PaginationSet<UnitViewModel>()
                {
                    Page = currentPage,
                    TotalCount = totalUnits,
                    TotalPages = (int)Math.Ceiling((decimal)totalUnits / currentPageSize),
                    Items = unitsVM
                };

                response = request.CreateResponse<PaginationSet<UnitViewModel>>(HttpStatusCode.OK, pagedSet);

                return response;
            });
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(HttpRequestMessage request, UnitViewModel unit)
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
                    Unit newUnit = new Unit();
                    newUnit.UpdateUnit(unit);

                    _unitsRepository.Add(newUnit);

                    _unitOfWork.Commit();

                    // Update view model
                    unit = Mapper.Map<Unit, UnitViewModel>(newUnit);
                    response = request.CreateResponse<UnitViewModel>(HttpStatusCode.Created, unit);
                }

                return response;
            });
        }

        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, UnitViewModel unit)
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
                    var unitDb = _unitsRepository.GetSingle(unit.ID);
                    if (unitDb == null)
                        response = request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Unit.");
                    else
                    {
                        unitDb.UpdateUnit(unit);
                        _unitsRepository.Edit(unitDb);

                        _unitOfWork.Commit();
                        response = request.CreateResponse<UnitViewModel>(HttpStatusCode.OK, unit);
                    }
                }

                return response;
            });
        }
    }
}