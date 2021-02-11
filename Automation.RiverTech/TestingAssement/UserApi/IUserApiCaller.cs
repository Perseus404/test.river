using System.Threading.Tasks;
using TestingAssessment.UserApi.Models;

namespace TestingAssessment.UserApi
{
    public interface IUserApiCaller
    {
        Task<UsersApiResponse> GetUserDetails(string id);
    }
}