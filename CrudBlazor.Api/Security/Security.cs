using CrudBlazor.Api.ORM.DAO;

using DefineLIBCore.JWT;
using System.Security.Claims;

namespace CrudBlazor.Api.Security
{
    public class Security(UserDAO dao)
    {
        readonly UserDAO dao = dao;
        public string CreateToken(ulong userID)
        {
            string token = String.Empty;

            var usuario = dao.FindByID(userID);


            if (usuario != null)
            {
                var build = new JWTBuild(Core.Configuration.JwtPrivateKey);
                var jwtToken = build
                    .AddClaim(ClaimTypes.Name, usuario.Id.ToString())
                    .AddClaim(ClaimTypes.GivenName, usuario.Name)
                    .AddRoles(usuario.Roles.ToArray())
                    .Create(TimeSpan.FromMinutes(30));

                if (!string.IsNullOrEmpty(jwtToken))
                    token = $"bearer {jwtToken}";
            }
            return token;
        }
    }
}
