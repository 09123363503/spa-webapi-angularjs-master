using HomeCinema.Entities;
using HomeCinema.Web.Models;

namespace HomeCinema.Web.Infrastructure.Extensions.DocumentOperation
{
    public static class DocumentEntitiesExtensions
    {
        public static void UpdateBaseInvocieType(this BaseInvoiceType baseInvoiceType, BaseInvoiceTypeViewModel baseInvoiceTypeVM)
        {
            baseInvoiceType.Code = baseInvoiceTypeVM.Code;
            baseInvoiceType.Name = baseInvoiceTypeVM.Name;
        }
        public static void UpdateInvoiceType(this InvoiceType invoiceType, InvoiceTypeViewModel invoiceTypeVM)
        {
            invoiceType.BaseInvoiceTypeID = invoiceTypeVM.BaseInvoiceTypeID;
            invoiceType.Code = invoiceTypeVM.Code;
            invoiceType.Name = invoiceTypeVM.Name;
            invoiceType.Abbreviation = invoiceTypeVM.Abbreviation;
        }
        public static void UpdateInvoiceItem(this InvoiceItem invoiceItem, InvoiceItemViewModel invoiceItemVM)
        {
            invoiceItem.InvoiceID = invoiceItemVM.InvoiceID;
            invoiceItem.Count = invoiceItemVM.Count;
            invoiceItem.UnitValue1 = invoiceItemVM.UnitValue1;
            invoiceItem.UnitValue2 = invoiceItemVM.UnitValue2;
            invoiceItem.UnitValue3 = invoiceItemVM.UnitValue3;
            invoiceItem.UnitPrice = invoiceItemVM.UnitPrice;
            invoiceItem.UsanceDate = invoiceItemVM.UsanceDate;
            invoiceItem.SaleMethod = invoiceItemVM.SaleMethod;
            invoiceItem.CreateUserID = invoiceItem.CreateUserID;
            invoiceItem.CreateOn = invoiceItemVM.CreateOn;
            invoiceItem.ModifyUserID = invoiceItemVM.ModifyUserID;
            invoiceItem.ModifyOn = invoiceItem.ModifyOn;
            invoiceItem.DeleteUserID = invoiceItemVM.DeleteUserID;
            invoiceItem.DeleteOn = invoiceItem.DeleteOn;
        }
        public static void UpdateInvoice(this Invoice invoice, InvoiceViewModel invoiceVM)
        {
            invoice.AccountID = invoiceVM.AccountID;
            invoice.InvoiceTypeID = invoiceVM.InvoiceTypeID;
            invoice.CompanyID = invoiceVM.CompanyID;
            invoice.WarehouseID = invoiceVM.WarehouseID;
            invoice.Date = invoiceVM.Date;
            invoice.Number = invoiceVM.Number;
            invoice.Description = invoiceVM.Description;
            invoice.TotalPrice = invoiceVM.TotalPrice;
            invoice.UsanceDate = invoiceVM.UsanceDate;
            invoice.CreateUserID = invoiceVM.CreateUserID;
            invoice.CreateOn = invoiceVM.CreateOn;
            invoice.ModifyUserID = invoiceVM.ModifyUserID;
            invoice.ModifyOn = invoiceVM.ModifyOn;
            invoice.DeleteUserID = invoiceVM.DeleteUserID;
            invoice.DeleteOn = invoiceVM.DeleteOn;
        }
    }
}