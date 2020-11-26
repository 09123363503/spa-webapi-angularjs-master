using HomeCinema.Entities;
using HomeCinema.Web.Models;

namespace HomeCinema.Web.Infrastructure.Extensions.BarcodeStructureOperation
{
    public static class BarcodeStructureEntitiesExtensions
    {
        public static void UpdateLot(this Lot lot, LotViewModel lotVM)
        {
            lot.ArticleID = lotVM.ArticleID;
            lot.ProducerLot = lotVM.ProducerLot;
            lot.ProductionOrderID = lotVM.ProductionOrderID;
            lot.OwnerID = lotVM.OwnerID;
            lot.Grade = lotVM.Grade;
            lot.CreateUserID = lotVM.CreateUserID;
            lot.CreateOn = lotVM.CreateOn;
            lot.ModifyUserID = lotVM.ModifyUserID;
            lot.ModifyOn = lotVM.ModifyOn;
            lot.DeleteUserID = lotVM.DeleteUserID;
            lot.DeleteOn = lotVM.DeleteOn;
        }
        public static void UpdateBarcode(this Barcode barcode, BarcodeViewModel barcodeVM)
        {
            barcode.BarcodeString = barcodeVM.BarcodeString;
            barcode.ArticleID = barcodeVM.ArticleID;
            barcode.Grade = barcodeVM.Grade;
            barcode.UnitValue1 = barcodeVM.UnitValue1;
            barcode.UnitValue2 = barcodeVM.UnitValue2;
            barcode.UnitValue3 = barcodeVM.UnitValue3;
            barcode.Count = barcodeVM.Count;
            barcode.CreateUserID = barcodeVM.CreateUserID;
            barcode.CreateOn = barcodeVM.CreateOn;
            barcode.ModifyUserID = barcodeVM.ModifyUserID;
            barcode.ModifyOn = barcodeVM.ModifyOn;
            barcode.DeleteUserID = barcodeVM.DeleteUserID;
            barcode.DeleteOn = barcodeVM.DeleteOn;
        }
        public static void UpdateCargo(this Cargo cargoItem, CargoViewModel cargoVM)
        {
            cargoItem.BarcodeID = cargoVM.BarcodeID;
            cargoItem.Count = cargoVM.Count;
            cargoItem.LocationID = cargoVM.LocationID;
            cargoItem.CreateUserID = cargoVM.CreateUserID;
            cargoItem.CreateOn = cargoVM.CreateOn;
            cargoItem.ModifyUserID = cargoVM.ModifyUserID;
            cargoItem.ModifyOn = cargoVM.ModifyOn;
            cargoItem.DeleteUserID = cargoVM.DeleteUserID;
            cargoItem.DeleteOn = cargoVM.DeleteOn;
        }
        public static void UpdateLocation(this Location location, LocationViewModel locationVM)
        {
            location.WarehouseID = locationVM.WarehouseID;
            location.Name = locationVM.Name;
            location.Block = locationVM.Block;
            location.Shelf = locationVM.Shelf;
            location.Level = locationVM.Level;
            location.Row = locationVM.Row;
        }
        public static void UpdateWarehouse(this Warehouse warehouse, WarehouseViewModel warehouseVM)
        {
            warehouse.ParentID = warehouseVM.ParentID;
            warehouse.Code = warehouseVM.Code;
            warehouse.Name = warehouseVM.Name;
            warehouse.AreaLocation = warehouseVM.AreaLocation;
            warehouse.Leased = warehouseVM.Leased;
            warehouse.IsGroup = warehouseVM.IsGroup;
            warehouse.Description = warehouseVM.Description;
            warehouse.CreateUserID = warehouseVM.CreateUserID;
            warehouse.CreateOn = warehouseVM.CreateOn;
            warehouse.ModifyUserID = warehouseVM.ModifyUserID;
            warehouse.ModifyOn = warehouseVM.ModifyOn;
            warehouse.DeleteUserID = warehouseVM.DeleteUserID;
            warehouse.DeleteOn = warehouseVM.DeleteOn;
        }
        public static void UpdateProductionOrder(this ProductionOrder productionOrder, ProductionOrderViewModel productionOrderVM)
        {
            productionOrder.ProductionLineID = productionOrderVM.ProductionLineID;
            productionOrder.Number = productionOrderVM.Number;
            productionOrder.Date = productionOrderVM.Date;
            productionOrder.ProductTypeID = productionOrderVM.ProductTypeID;
            productionOrder.Description = productionOrderVM.Description;
            productionOrder.StartDateTime = productionOrderVM.StartDateTime;
            productionOrder.FinishDateTime = productionOrderVM.FinishDateTime;
            productionOrder.State = productionOrderVM.State;
            productionOrderVM.FinancialPeriodID = productionOrderVM.FinancialPeriodID;
            productionOrder.ConfirmID = productionOrderVM.ConfirmID;
            productionOrder.DeliveryDateTime = productionOrderVM.DeliveryDateTime;
            productionOrder.CreateUserID = productionOrderVM.CreateUserID;
            productionOrder.CreateOn = productionOrderVM.CreateOn;
            productionOrder.ModifyUserID = productionOrderVM.ModifyUserID;
            productionOrder.ModifyOn = productionOrderVM.ModifyOn;
            productionOrder.DeleteUserID = productionOrderVM.DeleteUserID;
            productionOrder.DeleteOn = productionOrderVM.DeleteOn;
        }
        public static void UpdateProductionOrderItem(this ProductionOrderItem productionOrderItem,
            ProductionOrderItemViewModel productionOrderItemVM)
        {
            productionOrderItem.ProductionOrederID = productionOrderItemVM.ProductionOrederID;
            productionOrderItem.ArticleID = productionOrderItemVM.ArticleID;
            productionOrderItem.UnitValue1 = productionOrderItemVM.UnitValue1;
            productionOrderItem.UnitValue2 = productionOrderItemVM.UnitValue2;
            productionOrderItem.UnitValue3 = productionOrderItemVM.UnitValue3;
        }
        public static void UpdateProductionLine(this ProductionLine productionLine, ProductionLineViewModel productionLineVM)
        {
            // Work after complelte section
        }
        public static void UpdateProductType(this ProductType productType, ProductTypeViewModel productTypeVM)
        {
            productType.Code = productTypeVM.Code;
            productType.Name = productTypeVM.Name;
            productType.Description = productTypeVM.Description;
        }
    }
}