using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
   public static class Messages
    {
        public static string CarAdded = "Araç eklendi";
        internal static string CarDeleted="Araç Silindi";
        internal static string ErrorBrandId="Aracın BrandId sıfır olamaz";
        internal static string GetSuccess="Listeleme tamamlandı";
        internal static string GetError = "Ürünler Listelenirken bir hata oluştu";
        internal static string MaintenanceTime = "Sistem bakım saati.Lütfen 24.00 dan sonra deneyiniz";
        internal static string CarUpdated="Araç güncellendi";
    }
}
