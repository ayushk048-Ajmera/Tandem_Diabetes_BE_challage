using Newtonsoft.Json;

namespace Tandem_Diabetes_BE_challenge.Entities
{
    public class User
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "middleName")]
        public string MiddleName { get; set; }
        
        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }
        
        [JsonProperty(PropertyName = "phoneNumber")]
        public string PhoneNumber { get; set; }
        
        [JsonProperty(PropertyName = "emailAddress")]
        public string EmailAddress { get; set; }

    }
}
