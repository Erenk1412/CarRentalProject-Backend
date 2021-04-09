using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
   public static class Messages
    {
        public static string CarAdded = "Araç eklendi";
        public static string CarDeleted ="Araç Silindi";
        public static string ErrorBrandId ="Aracın BrandId sıfır olamaz";
        public static string GetSuccess ="Listeleme tamamlandı";
        public static string GetError = "Ürünler Listelenirken bir hata oluştu";
        public static string MaintenanceTime = "Sistem bakım saati.Lütfen 24.00 dan sonra deneyiniz";
        public static string CarUpdated ="Araç güncellendi";
        public static string CarImageLimitExceeded="Bir aracın 5'ten fazla resmi olamaz";
        public static string ImageAdded="Resim Ekleme Başarılı";
        public static string ImageDeleted="Resim Silindi";
        public static string ImageUpdated="Resim Güncelleme Başarılı";
        public static string CarNotAvaible = "Araç kiralanmaya uygun değildir.";
        public static string AddRentalMessage = "Araç kiralama kaydı alındı";
        public static string UserAdded="Kullanıcı Eklendi";
        public static string UserNotFound="Kullanıcı Bulunamadı";
        public static string UserRegistered = "Kayıt Olundu";
        public static string PasswordError="Parola Hatası";
        public static string SuccessfulLogin = "Giriş Başarılı";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Token Oluşturuldu";
        public static string RentalDeleted= "Araç Kira Kaydı Silindi";
        public static string GetRentalsMessage="Araçlar Listelendi";
        public static string RentalUpdated="Araç Güncelleme İşlemi Başarıyla Gerçekleşti";
        public static string CardAdded ="Kartınız Kaydedilmiştir";
        public static string RentalSummary="Kiralama Özeti";
        public static string GoToRent="Kiralamaya Yönlendiriliyorsunuz";
        public static string CarListedByFilter="Araçlar Filtreye Göre Listelendi";
        public static string AuthorizationDenied="Erişim Reddedildi";
        public static string BrandUpdated="Marka Güncellendi";
        public static string BrandDeleted="Marka Silindi";
        public static string BrandAdded="Marka Eklendi";
        public static string ColorAdded="Renk Eklendi";
        public static string ColorDeleted="Renk Silindi";
        public static string ColorUpdated="Renk Güncellendi";
        public static string ErrorColorId="Renk Id sıfır olamaz";
        public static string ErrorDailyPrice="Günlük ücret sıfır TL olamaz";
        public static string ErrorDailyPriceForBrandId="Eğer Markanız Mercedes ise günlük ücret 250 TL veya üzeri olmalı";

        public static string PasswordHasBeenChanged="Şifreniz Değiştirildi";
    }
}
