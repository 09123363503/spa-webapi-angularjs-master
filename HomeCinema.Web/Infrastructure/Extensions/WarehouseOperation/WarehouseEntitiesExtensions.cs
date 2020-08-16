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
            mainArticle.RegisterID = mainArticleVM.RegisterID;
            mainArticle.EditionID = mainArticleVM.EditionID;
            mainArticle.DeleteID = mainArticleVM.DeleteID;
            mainArticle.RegisterDateTime = mainArticleVM.RegisterDateTime;
            mainArticle.EditionDateTime = mainArticleVM.EditionDateTime;
            mainArticle.DeleteDateTime = mainArticleVM.DeleteDateTime;
        }
        public static void UpdateArticle(this Article article, ArticleViewModel articleVM)
        {
            article.MainArticleID = articleVM.MainArticleID;
            article.Code = articleVM.Code;
            article.Name = articleVM.Name;
            article.RegisterID = articleVM.RegisterID;
            article.EditionID = articleVM.EditionID;
            article.DeleteID = article.DeleteID;
            article.RegisterDateTime = articleVM.RegisterDateTime;
            article.EditionDateTime = articleVM.EditionDateTime;
            article.DeleteDateTime = articleVM.DeleteDateTime;
        }
        public static void UpdateUnit(this Unit unit, UnitViewModel unitVM)
        {
            unit.Code = unitVM.Code;
            unit.Name = unitVM.Name;
            unit.RegisterID = unitVM.RegisterID;
            unit.EditID = unitVM.EditionID;
            unit.DeleteID = unitVM.DeleteID;
            unit.RegisterDatetime = unitVM.RegisterDatetime;
            unit.EditDateTime = unitVM.EditionDateTime;
            unit.DeleteDateTime = unitVM.DeleteDateTime;
        }
        public static void UpdateComponent(this Component component, ComponentViewModel componentVM)
        {
            component.Code = componentVM.Code;
            component.Name = componentVM.Name;
            component.Lenght = componentVM.Lengtht;
            component.RegisterID = componentVM.RegisterID;
            component.EditionID = componentVM.EditionID;
            component.DeleteID = componentVM.DeleteID;
            component.RegisterDatetime = componentVM.RegisterDateTime;
            component.EditionDateTime = componentVM.EditionDateTime;
            component.DeleteDateTime = componentVM.DeleteDateTime;
        }
        public static void UpdateComponentItem(this ComponentItem componentItem, ComponentItemViewModel componentItemVM)
        {
            componentItem.ComponentID = componentItemVM.ComponentID;
            componentItem.Code = componentItemVM.Code;
            componentItem.Name = componentItemVM.Name;
            componentItem.RegisterID = componentItemVM.RegisterID;
            componentItem.EditionID = componentItemVM.EditionID;
            componentItem.DeleteID = componentItemVM.DeleteID;
            componentItem.RegisterDatetime = componentItemVM.RegisterDatetime;
            componentItem.EditionDateTime = componentItemVM.EditionDateTime;
            componentItem.DeleteDateTime = componentItemVM.DeleteDateTime;
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