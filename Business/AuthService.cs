using RestSharp;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidBlog.Business
{
    public class AuthService : BaseService
    {
        private class TokenResponse
        {
            public string Token { get; set; }
        }

        public User Auth(string email, string password)
        {
            RestRequest request = new RestRequest("auth", Method.Post);

            request.AddJsonBody(new { email, password });

            var response = Client.Execute<TokenResponse>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return null;

            var claims = new JwtSecurityTokenHandler().ReadJwtToken(response.Data.Token);

            var mail = claims.Claims.FirstOrDefault(x => x.Type == "Email").Value;
            var userId = claims.Claims.FirstOrDefault(x => x.Type == "Id").Value;
            var role = claims.Claims.FirstOrDefault(x => x.Type == "RoleId").Value;
            var exp = claims.Claims.FirstOrDefault(x => x.Type == "exp").Value;

            DateTime expirationDate = double.Parse(exp).ToDateTime();

            return new User
            {
                Email = email,
                Id = Int32.Parse(userId),
                Token = response.Data.Token,
                LoginExpiration = expirationDate,
                Role = role
            };
        }
    }  
}
