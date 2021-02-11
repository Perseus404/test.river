using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace TestingAssement.UserApi.Models
{
    public class UsersApiResponse
    {
        public UsersApiResponse(UserDetails userDetails, HttpResponseMessage responseDetails, long time)
        {
            UserDetails = userDetails;
            ResponseDetails = responseDetails;
            Time = time;
        }

        public UserDetails UserDetails { get; }
        public HttpResponseMessage ResponseDetails { get;}
        public long Time { get;}
    }
}
