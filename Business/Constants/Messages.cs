using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string BrandAdded = "Marka ekleme islemi basarili.";
        public static string BrandListed = "Marka listeleme islemi basarili.";
        public static string RantalAddingError = "Araba teslim edilmedigi icin kiralanamaz.";
        public static string RantalAdded = "Kiralama basarili";
        public static string CarAdded = "Araba eklendi.";
        public static string CarImageLimitExceeded="Bir arabanin en fazla bes fotografi olabilir.";
        public static string AuthorizationDenied="Yetkiniz yok";
        public static string UserRegistered ="Kayit oldu.";
        public static string UserNotFound ="Kullanici bulunamadi.";
        public static string PasswordError="Parola hatasi";
        public static string SuccessfulLogin="Basarili giris";
        public static string UserAlreadyExists="Kullanici mevcut.";
        public static string AccessTokenCreated="Token olusturuldu";
        public static string RentalAdded;
        public static string RentalDeleted;
        public static string RentalUpdated;
        public static string RentalCarAvailable;
        public static string RentalCarNotAvailable;
        public static string UserDeleted;
        public static string UsersListed;
        public static string UserAdded;
        public static string UserUpdated;
        public static string UserListed;
    }
}
