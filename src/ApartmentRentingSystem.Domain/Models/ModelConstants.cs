namespace ApartmentRentingSystem.Domain.Models
{
    public class ModelConstants
    {
        public class Common
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 20;
            public const int MinEmailLength = 3;
            public const int MaxEmailLength = 50;
            public const int MaxUrlLength = 2048;
            public const int Zero = 0;
        }
        
        public class ApartmentAds
        {
            public const int MinTitleLength = 5;
            public const int MaxTitleLength = 50;
            public const int MinAddressLength = 5;
            public const int MaxAddressLength = 300;
            public const int MinDescriptionLength = 10;
            public const int MaxDescriptionLength = 1000;
            public const decimal MinPrice = 0;
            public const decimal MaxPrice = 1000000;
            public const int MinSquareMeters = 1;
            public const int MaxSquareMeters = 10000;
        }
        
        public class Rooms
        {
            public const int MinNumberOfRooms = 1;
            public const int MaxNumberOfRooms = 10;
            public const int MinNumberOfBathrooms = 1;
            public const int MaxNumberOfBathrooms = 10;
            public const int MinNumberOfBedrooms = 1;
            public const int MaxNumberOfBedrooms = 10;
            public const int MinNumberOfBalconies = 1;
            public const int MaxNumberOfBalconies = 10;
        }

        public class PhoneNumber
        {
            public const int MinCountryCodeLength = 1;
            public const int MaxCountryCodeLength = 10;
            public const int MinPhoneNumberLength = 5;
            public const int MaxPhoneNumberLength = 20;
            public const string CountryCodeRegularExpression = @"\+[0-9]*";
        }

        
    }
}