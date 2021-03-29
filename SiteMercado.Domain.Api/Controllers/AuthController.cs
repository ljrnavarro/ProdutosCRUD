using Bazinga.AspNetCore.Authentication.Basic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SiteMercado.Domain.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// Passar os dados de login no reader
        /// </summary>
        /// <returns></returns>
        [Route("login")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Login()
        {
            //Fazendo a autenticação vai API Externa = "https://dev.sitemercado.com.br/api/login"
            bool retornoLogin = false;
            using (var client = new HttpClient())
            {
                string headerAutorization = HttpContext.Request.Headers["Authorization"].ToString();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", headerAutorization.Replace("Basic", ""));
                var ret = await client.PostAsync("https://dev.sitemercado.com.br/api/login", null);
                string responseBody = await ret.Content.ReadAsStringAsync();
                var userObj = JObject.Parse(responseBody);
                retornoLogin = Convert.ToString(userObj["success"]).ToLower().Equals("true");
            }

            if (!retornoLogin)
                return Unauthorized();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "User"),
                    new Claim(ClaimTypes.Role, "User")
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token_tmp = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(token_tmp);
            return Ok(new { token = token });
        }
    }
}
