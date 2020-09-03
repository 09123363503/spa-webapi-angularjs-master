using HomeCinema.Entities;
using HomeCinema.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            barcode.UnitID1 = barcodeVM.UnitID1;
            barcode.UnitID2 = barcodeVM.UnitID2;
            barcode.UnitID3 = barcodeVM.UnitID3;
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
        public static void UpdateCargo(this Cargo cargo, CargoViewModel cargoVM)
        {
            cargo.Date = cargoVM.Date;
            cargo.Number = cargoVM.Number;
            cargo.Input = cargoVM.Input;
            cargo.Output = cargoVM.Output;
            cargo.Prodution = cargoVM.Prodution;
            cargo.WHKeeperID = cargoVM.WHKeeperID;
            cargo.SumCount = cargoVM.SumCount;
            cargo.SumUnitID1 = cargoVM.SumUnitID1;
            cargo.SumunitID2 = cargoVM.SumunitID2;
            cargo.SumUnitValue1 = cargoVM.SumUnitValue1;
            cargo.SumUnitValue2 = cargoVM.SumUnitValue2;
            cargo.CreateUserID = cargoVM.CreateUserID;
            cargo.CreateOn = cargoVM.CreateOn;
            cargo.ModifyUserID = cargoVM.ModifyUserID;
            cargo.ModifyOn = cargoVM.ModifyOn;
            cargo.DeleteUserID = cargoVM.DeleteUserID;
            cargo.DeleteOn = cargoVM.DeleteOn;
        }
        public static void UpdateCargoDetail(this CargoDetail cargoDetail, CargoDetailViewModel cargoDetailVM)
        {
            cargoDetail.CargoID = cargoDetailVM.CargoID;
            cargoDetail.BarcodeID = cargoDetailVM.BarcodeID;
            cargoDetail.Count = cargoDetailVM.Count;
            cargoDetail.LocationID = cargoDetailVM.LocationID;
            cargoDetail.CreateUserID = cargoDetailVM.CreateUserID;
            cargoDetail.CreateOn = cargoDetailVM.CreateOn;
            cargoDetail.ModifyUserID = cargoDetailVM.ModifyUserID;
            cargoDetail.ModifyOn = cargoDetailVM.ModifyOn;
            cargoDetail.DeleteUserID = cargoDetailVM.DeleteUserID;
            cargoDetail.DeleteOn = cargoDetailVM.DeleteOn;
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
            warehouse.WHKeeperID = warehouseVM.WHKeeperID;
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
        public static void UpdateProductionOrderDetail(this ProductionOrderDetail productionOrderDetail, 
            ProductionOrderDetailViewModel productionOrderDetailVM)
        {
            productionOrderDetail.ProductionOrederID = productionOrderDetailVM.ProductionOrederID;
            productionOrderDetail.ArticleID = productionOrderDetailVM.ArticleID;
            productionOrderDetail.UnitID1 = productionOrderDetailVM.UnitID1;
            productionOrderDetail.UnitID2 = productionOrderDetailVM.UnitID2;
            productionOrderDetail.UnitID3 = productionOrderDetailVM.UnitID3;
            productionOrderDetail.UnitValue1 = productionOrderDetailVM.UnitValue1;
            productionOrderDetail.UnitValue2 = productionOrderDetailVM.UnitValue2;
            productionOrderDetail.UnitValue3 = productionOrderDetailVM.UnitValue3;
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