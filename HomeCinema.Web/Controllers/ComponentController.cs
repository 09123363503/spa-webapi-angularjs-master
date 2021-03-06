﻿using AutoMapper;
using HomeCinema.Data.Infrastructure;
using HomeCinema.Data.Repositories;
using HomeCinema.Entities;
using HomeCinema.Web.Infrastructure.Core;
using HomeCinema.Web.Infrastructure.Extensions.WarehouseOperation;
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
    [RoutePrefix("api/components")]
    public class ComponentController : ApiControllerBase
    {
        private readonly IEntityBaseRepositoryInetger<Component> _componentsRepository;

        public ComponentController(IEntityBaseRepositoryInetger<Component> componentsRepository,
            IEntityBaseRepositoryInetger<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            _componentsRepository = componentsRepository;
        }

        [AllowAnonymous]
        [Route("latest")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var components = _componentsRepository.GetAll().OrderByDescending(m => m.Code).Take(50).ToList();

                IEnumerable<ComponentViewModel> componentsVM = Mapper.Map<IEnumerable<Component>, IEnumerable<ComponentViewModel>>(components);

                response = request.CreateResponse<IEnumerable<ComponentViewModel>>(HttpStatusCode.OK, componentsVM);

                return response;
            });
        }

        [Route("Items/{id:int}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var component = _componentsRepository.GetSingle(id);

                ComponentViewModel componentVM = Mapper.Map<Component, ComponentViewModel>(component);

                response = request.CreateResponse<ComponentViewModel>(HttpStatusCode.OK, componentVM);

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
                List<Component> components = null;
                int totalComponents = new int();

                if (!string.IsNullOrEmpty(filter))
                {
                    components = _componentsRepository
                        .FindBy(m => m.Name.ToLower()
                        .Contains(filter.ToLower().Trim()))
                        .OrderBy(m => m.ID)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                    totalComponents = _componentsRepository
                        .FindBy(m => m.Name.ToLower()
                        .Contains(filter.ToLower().Trim()))
                        .Count();
                }
                else
                {
                    components = _componentsRepository
                        .GetAll()
                        .OrderBy(m => m.ID)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                    totalComponents = _componentsRepository.GetAll().Count();
                }

                IEnumerable<ComponentViewModel> componentsVM = Mapper.Map<IEnumerable<Component>, IEnumerable<ComponentViewModel>>(components);

                PaginationSet<ComponentViewModel> pagedSet = new PaginationSet<ComponentViewModel>()
                {
                    Page = currentPage,
                    TotalCount = totalComponents,
                    TotalPages = (int)Math.Ceiling((decimal)totalComponents / currentPageSize),
                    Items = componentsVM
                };

                response = request.CreateResponse<PaginationSet<ComponentViewModel>>(HttpStatusCode.OK, pagedSet);

                return response;
            });
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(HttpRequestMessage request, ComponentViewModel component)
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
                    Component newComponent = new Component();
                    newComponent.UpdateComponent(component);

                    //for (int i = 0; i < movie.NumberOfStocks; i++)
                    //{
                    //    Stock stock = new Stock()
                    //    {
                    //        IsAvailable = true,
                    //        Movie = newMovie,
                    //        UniqueKey = Guid.NewGuid()
                    //    };
                    //    newMovie.Stocks.Add(stock);
                    //}

                    _componentsRepository.Add(newComponent);

                    _unitOfWork.Commit();

                    // Update view model
                    component = Mapper.Map<Component, ComponentViewModel>(newComponent);
                    response = request.CreateResponse<ComponentViewModel>(HttpStatusCode.Created, component);
                }

                return response;
            });
        }

        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, ComponentViewModel component)
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
                    var componentDb = _componentsRepository.GetSingle(component.ID);
                    if (componentDb == null)
                        response = request.CreateErrorResponse(HttpStatusCode.NotFound, "جزء کالای انتخاب شده نامعتبر است");
                    else
                    {
                        componentDb.UpdateComponent(component);
                        _componentsRepository.Edit(componentDb);

                        _unitOfWork.Commit();
                        response = request.CreateResponse<ComponentViewModel>(HttpStatusCode.OK, component);
                    }
                }

                return response;
            });
        }
    }
}