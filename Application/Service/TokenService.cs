using Application.Service.Abstraction;
using Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using SharedKernel.Constants;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Application.Service;

public class IdentityTokenClaimService : ITokenClaimsService
{
    public IdentityTokenClaimService()
    {
    }

   
    public string GetTokenAsync(AuthenticationInfo authenticationInfo)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(AuthConstants.JWT_SECRET_KEY);
        var claims = new List<Claim> { new Claim(ClaimTypes.Name, authenticationInfo.UserID.ToString()) };

        claims.Add(new Claim(ClaimTypes.Sid, authenticationInfo.UserName ?? string.Empty));
        claims.Add(new Claim(ClaimTypes.Role, authenticationInfo.PRole ?? string.Empty));
        claims.Add(new Claim(ClaimTypes.Email, authenticationInfo.Email ?? string.Empty));


        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims.ToArray()),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}


