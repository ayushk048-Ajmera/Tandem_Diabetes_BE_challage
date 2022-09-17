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

        public APITests()
        {
            WebApplicationFactory<Program> webApplicationFactory = new WebApplicationFactory<Program>();
            httpClient = webApplicationFactory.CreateDefaultClient();
        }

        private async Task<HttpResponseMessage> CreateUser()
        {
            Random random = new Random();
            var randomNum = random.Next(99);

            UserDTO userDTO = new UserDTO
            {
                FirstName = $"first {randomNum}",
                LastName = $"Last {randomNum}",
                MiddleName = $"Middle {randomNum}",
                PhoneNumber = "123456789",
                EmailAddress = $"{randomNum}@xyz.com"
            };
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsJsonAsync<UserDTO>("/api/users", userDTO);
            return httpResponseMessage;
        }

        [TestMethod]
        public async Task ShouldCreateUser()
        {
            HttpResponseMessage httpResponseMessage = await CreateUser();

            Assert.AreEqual(httpResponseMessage.StatusCode, HttpStatusCode.Created);
        }



        [TestMethod]
        public async Task ShouldThrowEmailRequiredException()
        {
            Random random = new Random();
            var randomNum = random.Next(99);
            UserDTO userDTO = new UserDTO
            {
                FirstName = $"Fake first {randomNum}",
                LastName = $"Fake Last {randomNum}",
                MiddleName = $"Fake Middle {randomNum}",
                PhoneNumber = "123456789",
                EmailAddress = null
            };
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsJsonAsync("/api/users", userDTO);

            Assert.AreEqual(httpResponseMessage.StatusCode, HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public async Task ShouldGetAllUsers()
        {
            HttpResponseMessage httpResponseMessage = await CreateUser();
            UserDTO createdUser = await httpResponseMessage.Content.ReadFromJsonAsync<UserDTO>();
            List<UserResponseDTO> users = await httpClient.GetFromJsonAsync<List<UserResponseDTO>>("/api/users");
            bool exists = users.Any(u => u.EmailAddress.Equals(createdUser.EmailAddress));

            Assert.IsTrue(exists);
            Assert.IsTrue(users.Count > 0);
        }

        [TestMethod]
        public async Task ShouldGetUserByEmail()
        {
            HttpResponseMessage httpResponseMessage = await CreateUser();
            UserDTO createdUser = await httpResponseMessage.Content.ReadFromJsonAsync<UserDTO>();
            UserResponseDTO  user = await httpClient.GetFromJsonAsync<UserResponseDTO> ($"/api/users?email={createdUser.EmailAddress}");

            Assert.AreEqual(user.EmailAddress, createdUser.EmailAddress);
        }


        [TestMethod]
        public async Task ShouldGetBadEmailException()
        {
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"/api/users?email=32324535");

            Assert.AreEqual(httpResponseMessage.StatusCode, HttpStatusCode.BadRequest);
        }
    }
}