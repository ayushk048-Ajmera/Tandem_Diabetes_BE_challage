namespace Tandem_Diabetes_BE_challenge.DTOs
{
    public class UserResponseDTO
    {
        public Guid userId { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }
    }
}
