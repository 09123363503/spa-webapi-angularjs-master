using HomeCinema.Entities;
using HomeCinema.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeCinema.Web.Infrastructure.Extensions
{
    public static class EntitiesExtensions
    {
        public static void UpdateMovie(this Movie movie, MovieViewModel movieVm)
        {
            movie.Title = movieVm.Title;
            movie.Description = movieVm.Description;
            movie.GenreId = movieVm.GenreId;
            movie.Director = movieVm.Director;
            movie.Writer = movieVm.Writer;
            movie.Producer = movieVm.Producer;
            movie.Rating = movieVm.Rating;
            movie.TrailerURI = movieVm.TrailerURI;
            movie.ReleaseDate = movieVm.ReleaseDate;
        }

        public static void UpdateCustomer(this Customer customer, CustomerViewModel customerVm)
        {
            customer.FirstName = customerVm.FirstName;
            customer.LastName = customerVm.LastName;
            customer.IdentityCard = customerVm.IdentityCard;
            customer.Mobile = customerVm.Mobile;
            customer.DateOfBirth = customerVm.DateOfBirth;
            customer.Email = customerVm.Email;
            customer.UniqueKey = (customerVm.UniqueKey == null || customerVm.UniqueKey == Guid.Empty)
                ? Guid.NewGuid() : customerVm.UniqueKey;
            customer.RegistrationDate = (customer.RegistrationDate == DateTime.MinValue ? DateTime.Now : customerVm.RegistrationDate);
        }
        //public static void UpdateMainArticle(this MainArticle mainArticle, MainArticleViewModel mainArticleVM)
        //{
        //    mainArticle.Code = mainArticleVM.Code;
        //    mainArticle.Name = mainArticleVM.Name;
        //    mainArticle.ViewName = mainArticleVM.ViewName;
        //    mainArticle.Unit1ID = mainArticleVM.Unit1;
        //    mainArticle.Unit2ID = mainArticleVM.Unit2;
        //    mainArticle.Unit3ID = mainArticleVM.Unit3;
        //    mainArticle.PurchaseAccID = mainArticleVM.PurchaseAccID;
        //    mainArticle.SalesAccID = mainArticleVM.SalesAccID;
        //    mainArticle.InventoryAccID = mainArticleVM.InventoryAccID;
        //    mainArticle.RegisterID = mainArticleVM.RegisterID;
        //    mainArticle.EditionID = mainArticleVM.EditionID;
        //    mainArticle.DeleteID = mainArticleVM.DeleteID;
        //    mainArticle.RegisterDateTime = mainArticleVM.RegisterDateTime;
        //    mainArticle.EditionDateTime = mainArticleVM.EditionDateTime;
        //    mainArticle.DeleteDateTime = mainArticleVM.DeleteDateTime;
        //}
        //public static void UpdateArticle(this Article article, ArticleViewModel articleVM)
        //{
        //    article.MainArticleID = articleVM.MainArticleID;
        //    article.Code = articleVM.Code;
        //    article.Name = articleVM.Name;
        //    article.RegisterID = articleVM.RegisterID;
        //    article.EditionID = articleVM.EditionID;
        //    article.DeleteID = article.DeleteID;
        //    article.RegisterDateTime = articleVM.RegisterDateTime;
        //    article.EditionDateTime = articleVM.EditionDateTime;
        //    article.DeleteDateTime = articleVM.DeleteDateTime;
        //}
    }
}