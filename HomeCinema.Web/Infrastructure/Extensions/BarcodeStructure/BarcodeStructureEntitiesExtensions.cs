using HomeCinema.Entities;
using HomeCinema.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeCinema.Web.Infrastructure.Extensions.BarcodeStructure
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
            lot.RegisterID = lotVM.RegisterID;
            lot.RegisterDateTime = lotVM.RegisterDateTime;
            lot.EditID = lotVM.EditID;
            lot.EditDateTime = lotVM.EditDateTime;
            lot.DeleteID = lotVM.DeleteID;
            lot.DeleteDatetime = lotVM.DeleteDatetime;
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
            barcode.RegisterID = barcodeVM.RegisterID;
            barcode.RegisterDateTime = barcodeVM.RegisterDateTime;
            barcode.EditID = barcodeVM.EditID;
            barcode.EditDateTime = barcodeVM.EditDateTime;
            barcode.DeleteID = barcodeVM.DeleteID;
            barcode.DeleteDateTime = barcodeVM.DeleteDateTime;
        }
    }
}