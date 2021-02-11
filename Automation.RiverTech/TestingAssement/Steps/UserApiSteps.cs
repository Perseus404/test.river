using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TestingAssement.Steps.Models;
using TestingAssement.UserApi;
using TestingAssement.UserApi.Models;
using Xunit;

namespace TestingAssement.Steps
{
    [Binding]
    public class UserApiSteps
    {

        private readonly ScenarioContext _scenarioContext;
        private readonly IUserApiCaller _userApiCaller;

        public UserApiSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _userApiCaller = new UserApiCaller();
        }

        [When(@"'Users/(.*)' endpoint is invoked")]
        public async Task WhenEndpointIsInvoked(string endpoint)
        {
            var response = await _userApiCaller.GetUserDetails(endpoint);
            _scenarioContext.Add($"{endpoint}.{Keys.HttpStatus}", (int)response.ResponseDetails.StatusCode);
            _scenarioContext.Add($"{endpoint}.{Keys.UsersResponse}", response.UserDetails);
        }
        
        [Then(@"the http status code for 'Users/(.*)' endpoint was '(\d+)'")]
        public void ThenTheHttpStatusCodeIs(string endpoint, int expectedStatusCode)
        {
           var statusCode = _scenarioContext.Get<int>($"{endpoint}.{Keys.HttpStatus}");
           Assert.Equal(expectedStatusCode, statusCode);
        }

        [Then(@"the details for 'Users/(.*)' were correct")]
        public void ThenTheDetailsForWereCorrect(string request)
        {
            var userResponse = _scenarioContext.Get<UserDetails>($"{request}.{Keys.UsersResponse}");

            Assert.Equal(1, userResponse.Id);
            Assert.Equal("-37.3159", userResponse.Address.Geo.Lat);
            Assert.Equal("81.1496", userResponse.Address.Geo.Lng);
            Assert.Equal("Leanne Graham", userResponse.Name);
            Assert.Equal("1-770-736-8031 x56442", userResponse.Phone);
            Assert.Equal("harness real-time e-markets", userResponse.Company.Bs);
            Assert.Equal("Multi-layered client-server neural-net", userResponse.Company.CatchPhrase);
            Assert.Equal("Gwenborough", userResponse.Address.City);
            Assert.Equal("Romaguera-Crona", userResponse.Company.Name);
            Assert.Equal("Sincere@april.biz", userResponse.Email);
            Assert.Equal("Kulas Light", userResponse.Address.Street);
            Assert.Equal("Apt. 556", userResponse.Address.Suite);
            Assert.Equal("hildegard.org", userResponse.Website);
            Assert.Equal("92998-3874", userResponse.Address.Zipcode);
            Assert.Equal("Bret", userResponse.Username);
        }
        
        [Then(@"the details for 'Users/(.*)' were the following:")]
        public void ThenTheDetailsForWereTheFollowing(string request, Table table)
        {
            var user = table.CreateInstance<User>();
            
            // No Assert.Multiple on Xunit ? :(
         
            var userResponse = _scenarioContext.Get<UserDetails>($"{request}.{Keys.UsersResponse}");

            Assert.Equal(user.Id, userResponse.Id);
            Assert.Equal(user.Lat, userResponse.Address.Geo.Lat);
            Assert.Equal(user.Lng, userResponse.Address.Geo.Lng);
            Assert.Equal(user.Name, userResponse.Name);
            Assert.Equal(user.Phone, userResponse.Phone);
            Assert.Equal(user.Bs, userResponse.Company.Bs);
            Assert.Equal(user.CatchPhrase, userResponse.Company.CatchPhrase);
            Assert.Equal(user.City, userResponse.Address.City);
            Assert.Equal(user.CompanyName, userResponse.Company.Name);
            Assert.Equal(user.Email, userResponse.Email);
            Assert.Equal(user.Street, userResponse.Address.Street);
            Assert.Equal(user.Suite, userResponse.Address.Suite);
            Assert.Equal(user.Website, userResponse.Website);
            Assert.Equal(user.Zipcode, userResponse.Address.Zipcode);
            Assert.Equal(user.Username, userResponse.Username);

        }
    }
}
