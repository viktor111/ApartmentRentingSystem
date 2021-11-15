namespace ApartmentRentingSystem.Domain.Exceptions
{
    public class InvalidApartmentAdException : BaseDomainException
    {
        public InvalidApartmentAdException()
        {
        }

        public InvalidApartmentAdException(string error)
        {
            this.Error = error;
        }
    }
}