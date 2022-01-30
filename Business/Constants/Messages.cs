﻿using Core.Entities.Concrete;
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
        public static string CarPriceInvalid = "Araba fiyatı sıfırdan düşük olamaz!";
        public static string CarsListed = "Arabalar listelendi.";
        public static string CarListed = "Araba listelendi.";
        public static string MaintenanceTime = "Sistem bakımda!";
        public static string CarDeleted = "Araba silindi.";
        public static string CarUpdated = "Araba güncellendi.";
        public static string BrandAdded = "Marka eklendi.";
        public static string BrandDeleted = "Marka silindi!";
        public static string BrandUpdated = "Marka güncellendi.";
        public static string BrandNameInvalid = "Marka adı geçersiz!";
        public static string CarBodyTypeNameInvalid = "Kasa tip ismi geçersiz!";
        public static string CarBodyTypeAdded = "Kasa tipi eklendi.";
        public static string FuelTypeNameInvalid = "Yakıt tip ismi geçersiz!";
        public static string FuelTypeAdded = "Yakıt tipi eklendi.";
        public static string AuthorizationDenied  = "Yetkiniz yok!";
        public static string UserRegistered = "Kullanıcı kaydı başarılı.";
        public static string UserNotFound = "Kullanıcı bulunamadı!";
        public static string PasswordError = "Parola hatalı!";
        public static string SuccessfulLogin = "Giriş başarılı.";
        public static string UserAlreadyExists = "Kullanıcı zaten mevcut!";
        public static string AccessTokenCreated = "Accesstoken başarıyla oluşturuldu.";
        public static string IdentityIsIncorrect = "Kimlik bilgileri hatalı!";
        public static string CarCanNotRented = "Bu araba henüz kiralanamaz!";
        public static string ReservationCancellationControl = "Rezervasyon en geç 1 gün kala iptal edilebilir!";
        public static string CarDetailsBrought = "Araba detayları getirildi.";
        public static string AddressAdded = "Adres eklendi.";
        public static string AddressUpdated = "Adres güncellendi.";
        public static string AddressListed = "Adres listelendi.";
        public static string AddressesListed = "Adresler listelendi.";
        public static string AddressDeleted = "Adres silindi!";
        public static string BrandsListed = "Markalar listelendi.";
        public static string BrandListed = "Marka listelendi.";
        public static string BrandNameExists = "Bu marka zaten mevcut!";
        public static string CarBodyTypeNameExists = "Bu kasa tipi zaten mevcut!";
        public static string CarBodyTypeListed = "Kasa tipi listelendi.";
        public static string CarBodyTypesListed = "Kasa tipleri listelendi.";
        public static string CarBodyTypeUpdated = "Kasa tipi güncellendi.";
        public static string CarBodyTypeDeleted = "Kasa tipi silindi!";
        public static string CarImageAdded = "Araç resmi eklendi.";
        public static string CarImageUpdated = "Araç resmi güncellendi.";
        public static string CarImageNotUpdated = "Araç resmi güncellenemedi!";
        public static string CarImageLimitExceeded = "Daha fazla resim eklenemez!";
        public static string CarImageDeleted = "Araç resmi silindi!";
        public static string CityNameExists = "Bu şehir zaten mevcut!";
        public static string CityUpdated = "Şehir güncellendi.";
        public static string CityListed = "Şehir listelendi.";
        public static string CitiesListed = "Şehirler listelendi.";
        public static string CityDeleted = "Şehir silindi!";
        public static string CityAdded = "Şehir eklendi.";
        public static string ColorNameExists = "Bu renk zaten mevcut!";
        public static string ColorUpdated = "Renk güncellendi.";
        public static string ColorListed = "Renk listelendi.";
        public static string ColorsListed = "Renkler listelendi.";
        public static string ColorDeleted = "Renk silindi!";
        public static string ColorAdded = "Renk eklendi.";
        public static string CustomerUpdated = "Müşteri bilgisi güncellendi";
        public static string CustomerListed = "Müşteri bilgisi listelendi.";
        public static string CustomersListed = "Müşteri bilgileri listelendi.";
        public static string CustomerDeleted = "Müşteri silindi!";
        public static string CustomerAdded = "Müşteri eklendi.";
        public static string FuelTypeNameExists = "Yakıt tipi zaten mevcut!";
        public static string FuelTypeUpdated = "Yakıt tipi bilgisi güncellendi.";
        public static string FuelTypeListed = "Yakıt tipi listelendi.";
        public static string FuelTypesListed = "Yakıt tipleri listelendi.";
        public static string FuelTypeDeleted = "Yakıt tipi silindi!";
        public static string GearTypeNameExists = "Bu vites tipi zaen mevcut!";
        public static string GearTypeUpdated = "Vites tipi güncellendi.";
        public static string GearTypeListed = "Vites tipi listelendi.";
        public static string GearTypesListed = "Vites tipleri listelendi.";
        public static string GearTypeDeleted = "Vites tipi silindi!";
        public static string GearTypeAdded = "Vites tipi eklendi.";
        public static string InvoiceUpdated = "Fatura bilgisi güncellendi.";
        public static string InvoiceListed = "Fatura bilgisi listelendi.";
        public static string InvoicesListed = "Fatura bilgileri listelendi.";
        public static string InvoiceDeleted = "Fatura silindi.";
        public static string InvoiceAdded = "Fatura eklendi.";
        public static string ModelNameExists = "Bu mdel zaten mevcut!";
        public static string ModelUpdated = "Model bilgisi güncellendi.";
        public static string ModelListed = "Model listelendi";
        public static string ModelsListed = "Modeller listelendi.";
        public static string ModelAdded = "Model eklendi.";
        public static string ModelDeleted = "Model silindi!";
        public static string OperationClaimUpdated = "Operasyon yetki bilgisi güncellendi.";
        public static string OperationClaimListed = "Operasyon yetki bilgisi listelendi.";
        public static string OperationClaimsListed = "Operasyon yetki bilgileri listelendi.";
        public static string OperationClaimDeleted = "Operasyon yetki bilgisi silindi!";
        public static string OperationClaimAdded = "Operasyon yetki bilgisi eklendi.";
        public static string OperationClaimNameExists = "Bu operasyon yetkisi zaten mevcut!";
        public static string PaymentUpdated = "Ödeme bilgisi güncellendi.";
        public static string PaymentListed = "Ödeme bilgisi listelendi.";
        public static string PaymentsListed = "Ödeme bilgileri listelendi.";
        public static string PaymentDeleted = "Ödeme bilgisi silindi!";
        public static string PaymentAdded = "Ödeme bilgisi eklendi.";
        public static string RentalListed = "Kiralama bilgisi listelendi.";
        public static string RentalsListed = "Kiralama bilgileri listelendi.";
        public static string RentalAdded = "Kiralama yapıldı.";
        public static string ReservationUpdated = "Rezervasyon bilgisi güncellendi.";
        public static string ReservationListed = "Rezervasyon bilgisi listelendi.";
        public static string ReservationsListed = "Rezetvasyon bilgileri güncellendi.";
        public static string ReservationDeleted = "Rezervasyon iptal edildi!";
        public static string ReservationAdded = "Rezervasyon yapıldı.";
        public static string TownNameExists = "Bu ilçe zaten mevcut!";
        public static string TownUpdated = "İlçe bilgisi güncellendi.";
        public static string TownListed = "İlçe bilgisi listelendi.";
        public static string TownsListed  = "İlçe bilgileri listelendi.";
        public static string TownDeleted = "İlçe silindi!";
        public static string TownAdded = "İlçe eklendi.";
        public static string EmailExists = "Bu mail adresi zaten kullanılmakta!";
        public static string UserOperationClaimUpdated = "Kullanıcı operasyon yetkileri güncellendi.";
        public static string UserOperationClaimListed = "Kullanıcı operasyon yetkisi listelendi.";
        public static string UserOperationClaimsListed = "Kullanıcı operasyon yetkileri listelendi.";
        public static string UserOperationClaimDeleted = "Kullanıcı operasyon yetkileri silindi!";
        public static string UserOperationClaimAdded = "Kullanıcı operasyon yetkisi eklenlendi.";
        public static string RentalDetailsBrought = "Kiralama detayları getirildi.";
    }
}
