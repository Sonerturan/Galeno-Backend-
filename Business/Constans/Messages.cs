using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constans
{
    //magic string yapısı oluşturduk
    public static class Messages
    {
        public static string Added = "Başarıyle Eklendi Eklendi";
        public static string Updated = "Güncelleme İşlemi Başarılı";
        public static string Deleted = "Silme İşlemi Başarılı";
        public static string NameInvalid = "Geçersiz Nesne Adı";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string Listed = "Listeleme İşlemi Başarılı";
        public static string CountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir";
        public static string NameAlreadyExists = "Bu isimde zaten bir nesne var";

        public static string CheckIfCategoryLimitExceded = "Kategori limiti aşıldığı için yeni ürün eklenemiyor";

        public static string AuthorizationDenied = "Yetkiniz yok."; 

        public static string UserRegistered = "Kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        internal static string PasswordError="Parola hatası";

        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut";

        public static string AccessTokenCreated = "Erişim Token'i oluşturuldu";
    }
}
