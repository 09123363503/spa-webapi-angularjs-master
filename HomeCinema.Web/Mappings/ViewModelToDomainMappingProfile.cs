using AutoMapper;
using HomeCinema.Entities;
using HomeCinema.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeCinema.Web.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<MovieViewModel, Movie>()
                //.ForMember(m => m.Image, map => map.Ignore())
                .ForMember(m => m.Genre, map => map.Ignore());

            Mapper.CreateMap<MainArticleViewModel, MainArticle>()
                .ForMember(m => m.CreateUserID, map => map.Ignore());

            Mapper.CreateMap<ArticleViewModel, Article>()
                .ForMember(p => p.Name, map => map.Ignore());
        }
    }
}