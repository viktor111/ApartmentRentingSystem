namespace ApartmentRentingSystem.Domain.Exceptions
{
    public class InvalidLandlordException : BaseDomainException
    {
        public InvalidLandlordException()
        {
        }

        public InvalidLandlordException(string error)
        {
            this.Error = error;
        }
    }
}