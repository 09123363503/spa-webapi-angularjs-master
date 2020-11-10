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
    [RoutePrefix("api/locations")]
    public class LocationController : ApiControllerBase
    {
        private readonly IEntityBaseRepositoryInetger<Location> _locationsRepository;

        public LocationController(IEntityBaseRepositoryInetger<Location> locationsRepository,
            IEntityBaseRepositoryInetger<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            _locationsRepository = locationsRepository;
        }

        [Route("locations/{id:int}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var location = _locationsRepository.GetSingle(id);

                LocationViewModel locationVM = Mapper.Map<Location, LocationViewModel>(location);

                response = request.CreateResponse<LocationViewModel>(HttpStatusCode.OK, locationVM);

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
                List<Location> locations = null;
                int totalLocations = new int();

                if (!string.IsNullOrEmpty(filter))
                {
                    locations = _locationsRepository
                        .FindBy(m => m.Name.ToLower()
                        .Contains(filter.ToLower().Trim()))
                        .OrderBy(m => m.ID)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                    totalLocations = _locationsRepository
                        .FindBy(m => m.Name.ToLower()
                        .Contains(filter.ToLower().Trim()))
                        .Count();
                }
                else
                {
                    locations = _locationsRepository
                        .GetAll()
                        .OrderBy(m => m.ID)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                    totalLocations = _locationsRepository.GetAll().Count();
                }

                IEnumerable<LocationViewModel> locationVM = Mapper.Map<IEnumerable<Location>, IEnumerable<LocationViewModel>>(locations);

                PaginationSet<LocationViewModel> pagedSet = new PaginationSet<LocationViewModel>()
                {
                    Page = currentPage,
                    TotalCount = totalLocations,
                    TotalPages = (int)Math.Ceiling((decimal)totalLocations / currentPageSize),
                    Items = locationVM
                };

                response = request.CreateResponse<PaginationSet<LocationViewModel>>(HttpStatusCode.OK, pagedSet);

                return response;
            });
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(HttpRequestMessage request, LocationViewModel location)
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
                    Location newLocation = new Location();
                    newLocation.UpdateLocation(location);
                    _locationsRepository.Add(newLocation);

                    _unitOfWork.Commit();

                    // Update view model
                    location = Mapper.Map<Location, LocationViewModel>(newLocation);
                    response = request.CreateResponse<LocationViewModel>(HttpStatusCode.Created, location);
                }

                return response;
            });
        }

        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, LocationViewModel location)
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
                    var locationDb = _locationsRepository.GetSingle(location.ID);
                    if (locationDb == null)
                        response = request.CreateErrorResponse(HttpStatusCode.NotFound, "موقعیت انتخاب شده در انبار نا معتبر است");
                    else
                    {
                        locationDb.UpdateLocation(location);
                        _locationsRepository.Edit(locationDb);

                        _unitOfWork.Commit();
                        response = request.CreateResponse<LocationViewModel>(HttpStatusCode.OK, location);
                    }
                }

                return response;
            });
        }
    }
}