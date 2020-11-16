using AutoMapper;
using HomeCinema.Entities;
using HomeCinema.Web.Models;

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

            Mapper.CreateMap<CargoViewModel, Cargo>()
                .ForMember(p => p.BarcodeID, map => map.Ignore());

            Mapper.CreateMap<InvoiceItemViewModel, InvoiceItem>()
                .ForMember(p => p.InvoiceID, map => map.Ignore());
        }
    }
}