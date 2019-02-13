using ES.Services.DataAccess.Model.QueryModel.Authentication;
using ES.Services.DataTransferObjects.Response.Authentication;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ES.ExceptionAttributes
{
    public static class Helper
    {
        private static string Secret = System.Configuration.ConfigurationManager.AppSettings.Get("Token");
        public static int TokenExpirationMins = System.Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings.Get("TokenExpirationMinutes"));
        public static string GeneratePassword(int length) //length of salt    
        {
            const string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            var randNum = new Random();
            var chars = new char[length];
            var allowedCharCount = allowedChars.Length;
            for (var i = 0; i <= length - 1; i++)
            {
                chars[i] = allowedChars[Convert.ToInt32((allowedChars.Length) * randNum.NextDouble())];
            }
            return new string(chars);
        }
        public static string EncodePassword(string pass, string salt) //encrypt password    
        {
            byte[] bytes = Encoding.Unicode.GetBytes(pass);
            byte[] src = Encoding.Unicode.GetBytes(salt);
            byte[] dst = new byte[src.Length + bytes.Length];
            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);
            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            //return Convert.ToBase64String(inArray);    
            return EncodePasswordMd5(Convert.ToBase64String(inArray));
        }
        public static string EncodePasswordMd5(string pass) //Encrypt using MD5    
        {
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;
            //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)    
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(pass);
            encodedBytes = md5.ComputeHash(originalBytes);
            //Convert encoded bytes back to a 'readable' string    
            return BitConverter.ToString(encodedBytes);
        }
        public static string GenerateToken(CustomUserInformationQueryModel usr)
        {
            var symmetricKey = Convert.FromBase64String(Secret);
            var tokenHandler = new JwtSecurityTokenHandler();

            var now = DateTime.UtcNow;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                        {
                            new Claim(ClaimTypes.Name, usr.LoginName),
                            new Claim(ClaimTypes.GivenName, usr.FullName),
                            //new Claim(ClaimTypes.Role,usr.CRMRoleNames.First()),
                            new Claim(ClaimTypes.SerialNumber, usr.UserId.ToString()),
                            new Claim(ClaimTypes.Upn,"ERPSYSTEM")

                        }),

                Expires = now.AddMinutes(Convert.ToInt32(TokenExpirationMins)),

                SigningCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(symmetricKey), Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);

            return token;
        }

        public static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null)
                    return null;

                var symmetricKey = Convert.FromBase64String(Secret);

                var validationParameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey),
                    //RoleClaimType = System.Security.Claims.ClaimTypes.Role
                };

                SecurityToken securityToken;
                var principal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);

                return principal;
            }
            catch (SecurityTokenExpiredException secEx)
            {
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static string CurrentFiniancialYear()
        {
            int month = System.DateTime.Now.Month;
            var currentYear = Convert.ToString(DateTime.UtcNow.Year.ToString().Substring(2, 2));
            if (month > 3)
            {
                currentYear = Convert.ToString(Convert.ToInt16(currentYear)+1);

            }
            return currentYear;
        }

        public static string userIdToekn()
        {
            var identity = HttpContext.Current.User.Identity as ClaimsIdentity;
            var clientId = string.Empty;
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                clientId = claims.First(claim => claim.Type.ToLower() == ClaimTypes.SerialNumber).Value;
            }
            return clientId;
        }
    }
}
