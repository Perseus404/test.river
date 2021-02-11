using System.Threading.Tasks;
using TestingAssement.UserApi.Models;

namespace TestingAssement.UserApi
{
    public interface IUserApiCaller
    {
        Task<UsersApiResponse> GetUserDetails(string id);
    }
}