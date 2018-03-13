using Microsoft.IdentityModel.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Security.Claims;
using System.Web.Http.Filters;
using System.Security.Principal;
using ES.ExceptionAttributes;

namespace ES.Shared.Services.Filters
{
    public class JwtAuthenticationAttribute : Attribute, IAuthenticationFilter
    {

        public string Realm { get; set; }
        public bool AllowMultiple => false;

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var request = context.Request;
            var authorization = request.Headers.Authorization;

            if (authorization == null || authorization.Scheme != "Bearer")
            {
                context.ErrorResult = new AuthenticationFailureResult("Authorization has been denied for this request.", request);
                return;
            }

            if (string.IsNullOrEmpty(authorization.Parameter))
            {
                context.ErrorResult = new AuthenticationFailureResult("Missing Jwt Token", request);
                return;
            }

            var token = authorization.Parameter;
            var principal = await AuthenticateJwtToken(token);

            if (principal == null)
                context.ErrorResult = new AuthenticationFailureResult("Invalid token", request);

            else
                context.Principal = principal;
        }



        private static bool ValidateToken(string token, out List<System.Security.Claims.Claim> userClaims)
        {
            userClaims = new List<System.Security.Claims.Claim>();

            var simplePrinciple = Helper.GetPrincipal(token);
            if (simplePrinciple == null)
            {
                return false;
            }
            var identity = simplePrinciple.Identity as System.Security.Claims.ClaimsIdentity;

            if (identity == null)
                return false;

            if (!identity.IsAuthenticated)
                return false;
            //var usernameClaim = identity.FindFirst(ClaimTypes.Name);
            //username = usernameClaim?.Value;
            //we consider the token valid if it is 
            //1) Decryptable via our private key
            //2) Contains content that is resolvable to an identity principal
            //3) Has a username associated with it.   (This is just a test for structural correctness)
            if (!identity.HasClaim(p => p.Type == System.Security.Claims.ClaimTypes.Name))
                return false;
            userClaims.AddRange(identity.Claims);
            return true;
        }

        protected Task<IPrincipal> AuthenticateJwtToken(string token)
        {
            List<System.Security.Claims.Claim> userClaims;

            if (ValidateToken(token, out userClaims))
            {

                var identity = new System.Security.Claims.ClaimsIdentity(userClaims, "Jwt");
                IPrincipal user = new System.Security.Claims.ClaimsPrincipal(identity);

                return Task.FromResult(user);
            }

            return Task.FromResult<IPrincipal>(null);
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            Challenge(context);
            return Task.FromResult(0);
        }

        private void Challenge(HttpAuthenticationChallengeContext context)
        {
            string parameter = null;

            if (!string.IsNullOrEmpty(Realm))
                parameter = "realm=\"" + Realm + "\"";

            context.ChallengeWith("Bearer", parameter);
        }
    }
}