using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using TestingAssessment.UserApi.Models;

namespace TestingAssessment.UserApi
{
    public class UserApiCaller : IUserApiCaller
    {
        public async Task<UsersApiResponse> GetUserDetails(string id)
        {
            using var httpClient = new HttpClient();
            var timer = new Stopwatch();

            timer.Start();
            using var response = await httpClient.GetAsync($"https://jsonplaceholder.typicode.com/users/{id}");
            timer.Stop();
            string apiResponse = await response.Content.ReadAsStringAsync();

            var userDetails = JsonConvert.DeserializeObject<UserDetails>(apiResponse);

            return new UsersApiResponse(userDetails, response, timer.ElapsedMilliseconds);
        }
    }
}
