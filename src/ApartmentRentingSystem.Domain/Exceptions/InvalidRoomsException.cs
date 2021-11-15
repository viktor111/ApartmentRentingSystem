namespace ApartmentRentingSystem.Domain.Exceptions
{
    public class InvalidRoomsException : BaseDomainException
    {
        public InvalidRoomsException()
        {
        }

        public InvalidRoomsException(string error)
        {
            this.Error = error;
        }
    }
}