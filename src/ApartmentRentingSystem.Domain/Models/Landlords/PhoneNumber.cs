namespace ApartmentRentingSystem.Domain.Models.Landlords
{
    using System.Text.RegularExpressions;
    using Common;
    using Exceptions;
    
    using static ModelConstants.PhoneNumber;

    public class PhoneNumber : ValueObject
    {
        internal PhoneNumber(string countryCode, string number)
        {
            this.Validate(countryCode, number);
            
            if (!Regex.IsMatch(countryCode, CountryCodeRegularExpression))
            {
                throw new InvalidPhoneNumberException("Country Code must start with a '+' and contain only digits afterwards.");
            }
            
            this.Number = number;
            this.CountryCode = countryCode;
        }

        public string CountryCode { get; }

        public string Number { get; }

        private void Validate(string countryCode, string number)
        {
            this.ValidateNumber(number);
            this.ValidateCountryCode(countryCode);
        }

        private void ValidateNumber(string phoneNumber)
        {
            Guard.ForStringLength<InvalidPhoneNumberException>(
                phoneNumber,
                MinPhoneNumberLength,
                MaxPhoneNumberLength,
                nameof(PhoneNumber));
        }
        private void ValidateCountryCode(string countryCode)
        {
            Guard.ForStringLength<InvalidPhoneNumberException>(
                countryCode,
                MinCountryCodeLength,
                MaxCountryCodeLength,
                nameof(PhoneNumber));
        }
    }
}