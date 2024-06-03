using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidBlog.Business
{
    public class BaseService
    {
        public virtual string BaseUrl => "http://localhost:5015/api/";
        public RestClient Client { get; }

        public BaseService()
        {
            Client = new RestClient(BaseUrl);
        }
    }
}
