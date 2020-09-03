using HomeCinema.Entities;
using HomeCinema.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeCinema.Web.Infrastructure.Extensions.WarehouseOperation
{
    public static class WarehouseEntitiesExtensions
    {
        public static void UpdateMainArticle(this MainArticle mainArticle, MainArticleViewModel mainArticleVM)
        {
            mainArticle.Code = mainArticleVM.Code;
            mainArticle.Name = mainArticleVM.Name;
            mainArticle.ViewName = mainArticleVM.ViewName;
            mainArticle.Unit1ID = mainArticleVM.Unit1;
            mainArticle.Unit2ID = mainArticleVM.Unit2;
            mainArticle.Unit3ID = mainArticleVM.Unit3;
            mainArticle.PurchaseAccID = mainArticleVM.PurchaseAccID;
            mainArticle.SalesAccID = mainArticleVM.SalesAccID;
            mainArticle.InventoryAccID = mainArticleVM.InventoryAccID;
            mainArticle.CreateUserID = mainArticleVM.CreateUserID;
            mainArticle.ModifyUserID = mainArticleVM.ModifyUserID;
            mainArticle.DeleteUserID = mainArticleVM.DeleteUserID;
            mainArticle.CreateOn = mainArticleVM.CreateOn;
            mainArticle.ModifyOn = mainArticleVM.ModifyOn;
            mainArticle.DeleteOn = mainArticleVM.DeleteOn;
        }
        public static void UpdateArticle(this Article article, ArticleViewModel articleVM)
        {
            article.MainArticleID = articleVM.MainArticleID;
            article.Code = articleVM.Code;
            article.Name = articleVM.Name;
            article.CreateUserID = articleVM.CreateUserID;
            article.ModifyUserID = articleVM.ModifyUserID;
            article.DeleteUserID = article.DeleteUserID;
            article.CreateOn = articleVM.CreateOn;
            article.ModifyOn = articleVM.ModifyOn;
            article.DeleteOn = articleVM.DeleteOn;
        }
        public static void UpdateUnit(this Unit unit, UnitViewModel unitVM)
        {
            unit.Code = unitVM.Code;
            unit.Name = unitVM.Name;
            unit.CreateUserID = unitVM.CreateUserID;
            unit.ModifyUserID = unitVM.ModifyUserID;
            unit.DeleteUserID = unitVM.DeleteUserID;
            unit.CreateOn = unitVM.CreateOn;
            unit.ModifyOn = unitVM.ModifyOn;
            unit.DeleteOn = unitVM.DeleteOn;
        }
        public static void UpdateComponent(this Component component, ComponentViewModel componentVM)
        {
            component.Code = componentVM.Code;
            component.Name = componentVM.Name;
            component.Lenght = componentVM.Lengtht;
            component.CreateUserID = componentVM.CreateUserID;
            component.ModifyUserID = componentVM.ModifyUserID;
            component.DeleteUserID = componentVM.DeleteUserID;
            component.CreateOn = componentVM.CreateOn;
            component.ModifyOn = componentVM.ModifyOn;
            component.DeleteOn = componentVM.DeleteOn;
        }
        public static void UpdateComponentItem(this ComponentItem componentItem, ComponentItemViewModel componentItemVM)
        {
            componentItem.ComponentID = componentItemVM.ComponentID;
            componentItem.Code = componentItemVM.Code;
            componentItem.Name = componentItemVM.Name;
            componentItem.CreateUserID = componentItemVM.CreateUserID;
            componentItem.ModifyUserID = componentItemVM.ModifyUserID;
            componentItem.DeleteUserID = componentItemVM.DeleteUserID;
            componentItem.CreateOn = componentItemVM.CreateOn;
            componentItem.ModifyOn = componentItemVM.ModifyOn;
            componentItem.DeleteOn = componentItemVM.DeleteOn;
        }
        public static void UpdateArticleItem(this ArticleItem articleItem, ArticleItemViewModel articleItemVM)
        {
            articleItem.ArticleID = articleItemVM.ArticleID;
            articleItem.ComponentItemID = articleItemVM.ComponentItemID;
            articleItem.MainArticleComponentID = articleItemVM.MainArticleComponentID;
        }
        public static void UpdateMainArticleComponent(this MainArticleComponent mainArticleComponent, MainArticleComponentViewModel mainArticleComponentVM)
        {
            mainArticleComponent.MainAricleID = mainArticleComponentVM.MainAricleID;
            mainArticleComponent.ComponentID = mainArticleComponentVM.ComponentID;
            mainArticleComponent.Position = mainArticleComponentVM.Position;
            mainArticleComponent.Name = mainArticleComponentVM.Name;
        }
    }
}