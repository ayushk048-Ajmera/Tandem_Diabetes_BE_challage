﻿using Newtonsoft.Json;

namespace Tandem_Diabetes_BE_challenge.DTOs
{
    public class UserDTO
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }
    }
}
