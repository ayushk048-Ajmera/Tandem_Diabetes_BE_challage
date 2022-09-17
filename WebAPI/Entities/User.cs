using Newtonsoft.Json;

namespace Tandem_Diabetes_BE_challenge.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string EmailAddress { get; set; }

    }
}
