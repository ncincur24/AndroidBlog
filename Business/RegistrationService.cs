using AndroidBlog.Business.DTO;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidBlog.Business
{
    public class RegistrationService : BaseService
    {
        public bool RegisterUser(RegistrationDTO user)
        {
            var restRequest = new RestRequest("users", Method.Post);

            var userJson=JsonConvert.SerializeObject(user);
            restRequest.AddJsonBody(userJson);
            var response = Client.Post(restRequest);
            return response.StatusCode == System.Net.HttpStatusCode.Created;
        }
    }
}
