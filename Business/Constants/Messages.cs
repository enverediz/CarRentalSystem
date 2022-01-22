using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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
        public static string AuthorizationDenied  = "Yetkiniz yok!";
        public static string UserRegistered = "Kullanıcı kaydı başarılı.";
        public static string UserNotFound = "Kullanıcı bulunamadı!";
        public static string PasswordError = "Parola hatalı!";
        public static string SuccessfulLogin = "Giriş başarılı.";
        public static string UserAlreadyExists = "Kullanıcı zaten mevcut!";
        public static string AccessTokenCreated = "Accesstoken başarıyla oluşturuldu.";
    }
}
