﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi.";
        public static string CarPriceInvalid = "Araba fiyatı sıfırdan düşük olamaz!.";
        public static string Carlisted = "Arabalar listelendi";
        public static string MaintenanceTime = "Sistem bakımda!";
        public static string CarDeleted = "Araba silindi.";
        public static string CarUpdated = "Araba güncellendi.";
        public static string BrandAdded;
        public static string BrandDeleted;
        public static string BrandUpdated;
        public static string BrandNameInvalid;
        public static string CarBodyTypeNameInvalid;
        public static string CarBodyTypeAdded;
        public static string FuelTypeNameInvalid;
        public static string FuelTypeAdded;
    }
}