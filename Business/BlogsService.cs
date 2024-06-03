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
    public class BlogsService : BaseService
    {
        public AllBlogs GetBlogs(string keyword = null)
        {
            var request = "blogs";

            if (!string.IsNullOrEmpty(keyword))
            {
                request += $"?keyword={keyword}";
            }

            var restRequest = new RestRequest(request);

            var user = Preferences.Default.Get("user", "");

            var deserializedUser = JsonConvert.DeserializeObject<User>(user);

            restRequest.AddHeader("Authorization", "Bearer " + deserializedUser.Token);

            var data = Client.Get<AllBlogs>(restRequest);

            return data;
        }

        public bool DelteBlog(int id)
        {
            var restRequest = new RestRequest($"blogs/{id}", Method.Delete);

            var user = Preferences.Default.Get("user", "");

            var deserializedUser = JsonConvert.DeserializeObject<User>(user);

            restRequest.AddHeader("Authorization", "Bearer " + deserializedUser.Token);

            var data = Client.Delete(restRequest);

            return data.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    }
}
