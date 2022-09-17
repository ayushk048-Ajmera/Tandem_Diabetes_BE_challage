using System.Net.Http.Json;
using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Tandem_Diabetes_BE_challenge.DTOs;

namespace TestProject
{

    [TestClass]
    public class APITests
    {
        private HttpClient httpClient;
        private string randomNum;

        public APITests()
        {
            WebApplicationFactory<Program> webApplicationFactory = new WebApplicationFactory<Program>();
            httpClient = webApplicationFactory.CreateDefaultClient();
            Random random = new Random();
            randomNum = random.Next(99).ToString();
        }

        [TestMethod]
        public async Task ShouldCreateUser()
        {
            UserDTO userDTO = new UserDTO
            {
                FirstName = $"first {randomNum}",
                LastName = $"Last {randomNum}",
                MiddleName = $"Middle {randomNum}",
                PhoneNumber = "123456789",
                EmailAddress = $"{randomNum}@xyz.com"
            };
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsJsonAsync<UserDTO>("/api/users", userDTO);
            Assert.AreEqual(httpResponseMessage.StatusCode, HttpStatusCode.Created);
        }



        [TestMethod]
        public async Task ShouldNotCreateUser()
        {
            Random random = new Random();
            var randomNub = random.Next(99);
            UserDTO userDTO = new UserDTO
            {
                FirstName = $"Fake first {randomNub}",
                LastName = $"Fake Last {randomNub}",
                MiddleName = $"Fake Middle {randomNub}",
                PhoneNumber = "123456789",
                EmailAddress = null
            };
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsJsonAsync<UserDTO>("/api/users", userDTO);



            Assert.AreEqual(httpResponseMessage.StatusCode, HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public async Task GetAllUsers()
        {
            List<UserResponseDTO> users = await httpClient.GetFromJsonAsync<List<UserResponseDTO>>("/api/users");
            bool isExist = users.Any(u => u.EmailAddress.Equals("ayush@xtz.com"));
            Assert.IsTrue(isExist);
            Assert.IsTrue(users.Count > 0);
        }

        [TestMethod]
        public async Task ShouldGetUserByEmail()
        {
            string email = "ayush@xtz.com";
            List<UserResponseDTO> users = await httpClient.GetFromJsonAsync<List<UserResponseDTO>>($"/api/users?email={email}");
            bool isExist = users.Any(u => u.EmailAddress.Equals(email));
            Assert.IsTrue(isExist);
        }


        [TestMethod]
        public async Task ShouldNotGetUserByEmail()
        {
            string email = $"{randomNum}";
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"/api/users?email={email}");
            Assert.AreEqual(httpResponseMessage.StatusCode, HttpStatusCode.BadRequest);
        }
    }
}