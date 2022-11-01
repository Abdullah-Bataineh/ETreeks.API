using ETreeks.CORE.Data;
using ETreeks.CORE.Repository;
using ETreeks.CORE.Service;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ETreeks.INFRA.Service
{
    public class JWTService : IJWTService
    {
        private readonly IJWTRepository _reposiytory;
        public JWTService(IJWTRepository reposiytory)
        {
            _reposiytory = reposiytory;
        }

        public string Auth(Login login)
        {

            var result = _reposiytory.Auth(login);
            if (result == null)
            {
                return null;
            }
            else
            {

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AbuShehab Saadeh Shalabieh Bataineh"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var claims = new List<Claim>
    {
        new Claim("ID", result.User_Id.ToString()),
        new Claim("Roleid", result.Role_Id.ToString())
    };
                var tokeOptions = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddSeconds(10),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return tokenString;

            }


        }
    }
}
