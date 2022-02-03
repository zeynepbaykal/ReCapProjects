using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        //For Car
        public static string CarAdded = "Ürün eklendi";
        public static string CarNameInvalid = "ürün eklenmedi,isim geçersiz";
        public static string CarDelete = "Ürün silindi";
        public static string CarListed = "ürünler listelendi";
        public static string MaintenanceTime = "sistem bakımda";
        public static string CarUpdated = "Ürün güncellendi";

        ////For User
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserNameInvalid = "Kullanıcı eklenmedi,isim geçersiz";
        public static string UserDelete = "Kullanıcı silindi";
        public static string UserListed = "Kullanıcı listelendi";
        public static string UserUpdated = "Kullanıcı güncellendi";


        //For Customer
        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerNameInvalid = "Müşteri eklenmedi,isim geçersiz";
        public static string CustomerDelete = "Müşteri silindi";
        public static string CustomerListed = "Müşteri listelendi";
        public static string CustomerUpdated = "Müşteri güncellendi";

        //For Rental
        public static string RetalAdded = "Müşteri eklendi";
        public static string RentalDelete = "Müşteri silindi";
        public static string RentalListed = "Müşteri listelendi";
        public static string RentalUpdated = "Müşteri güncellendi";

        //For CarImage
        public static string CarImageAdded = "Araç fotoğrafı eklendi";
        public static string CarImageUpdated = "Araç fotoğrafı güncellendi";
        public static string CarImageDeleted = "Araç fotoğrafı silindi";
        public static string CarImageCountOfCarError = "Aracın fotoğrafları maksimum sayıdadır";
        public static string CarImagesListed = "Araç fotoğrafları listelendi";

        //jwt
        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Kullanıcı parola hatası.";
        public static string UserRegistered = "Kulanıcı kayıt oldu.";
        internal static string SuccessfulLogin = "Kullanıcı başarılı giriş yaptı.";
        internal static string UserAlreadyExists = "Kullanıcı mevcut";
        internal static string AccessTokenCreated = "Token oluşturuldu.";

        public static string CarDetailsReceived = "Araç detayları getirildi";

    }
}
