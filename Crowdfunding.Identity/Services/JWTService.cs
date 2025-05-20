using Crowdfunding.Identity.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Identity.Services
{
    public class JWTService
    {
        private readonly JwtTokenConfig _backendJwtTokenConfig;
        private readonly byte[] _backendSecret;

        public JWTService(JwtTokenConfig backendJwtTokenConfig)
        {
            _backendJwtTokenConfig = backendJwtTokenConfig;
            _backendSecret = Encoding.ASCII.GetBytes(_backendJwtTokenConfig.Secret);
        }
        public JWTService() { }

        public string ReadClaimByExp(string token)
        {
            if (token.Contains("Bearer"))
                token = token.Split(' ')[1];
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var s = jwtSecurityToken.Claims.First(claim => claim.Type == "exp").Value;
            var longresult = Convert.ToInt64(s);
            var result = DateTimeOffset.FromUnixTimeSeconds(longresult).AddHours(8).ToString("yyyy/MM/dd HH:mm:ss");
            return result;
        }
        public DateTime ReadClaimByDtExp(string token)
        {
            if (token.Contains("Bearer"))
                token = token.Split(' ')[1];
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var s = jwtSecurityToken.Claims.First(claim => claim.Type == "exp").Value;
            var longresult = Convert.ToInt64(s);
            var result = DateTimeOffset.FromUnixTimeSeconds(longresult).AddHours(8).DateTime;
            return result;
        }

        public Claim[] ReadClaims(string token)
        {
            if (token.Contains("Bearer"))
                token = token.Split(' ')[1];
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var result = jwtSecurityToken.Claims.ToArray();
            return result;
        }


        public (ClaimsPrincipal, JwtSecurityToken) DecodeJwtToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new SecurityTokenException("Invalid token");
            }

            if (token.Contains("Bearer"))
                token = token.Split(' ')[1];

            var principal = new JwtSecurityTokenHandler()
                .ValidateToken(token,
                    new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = _backendJwtTokenConfig.Issuer,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(_backendSecret), // new SymmetricSecurityKey(_frontendSecret),
                        ValidAudience = _backendJwtTokenConfig.Audience,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    },
                    out var validatedToken);
            return (principal, validatedToken as JwtSecurityToken);
        }

        public string GenerateTokens(Claim[] claims, DateTime now, bool isRefresh = false)
        {
            JwtSecurityToken jwtToken = GenerateBackendToken(claims, now);

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return accessToken;
        }
        private JwtSecurityToken GenerateFrontendToken(Claim[] claims, DateTime now, bool isRefresh = false)
        {
            int expirationMinute = 1440;
            if (isRefresh)
            {
                expirationMinute = 1440;
            }
            var jwtToken = new JwtSecurityToken(
                _backendJwtTokenConfig.Issuer,
                _backendJwtTokenConfig.Audience ?? string.Empty,
                claims,
                expires: now.AddMinutes(expirationMinute),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(_backendSecret), SecurityAlgorithms.HmacSha256Signature));
            return jwtToken;

        }
        private JwtSecurityToken GenerateBackendToken(Claim[] claims, DateTime now)
        {
            int expirationMinute = 1440;

            var jwtToken = new JwtSecurityToken(
                _backendJwtTokenConfig.Issuer,
                _backendJwtTokenConfig.Audience ?? string.Empty,
                claims,
                expires: now.AddMinutes(expirationMinute),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(_backendSecret), SecurityAlgorithms.HmacSha256Signature));
            return jwtToken;
        }

        public String ReadClaim(JWTClaimEnum key, string token)
        {
            if (token.Contains("Bearer"))
                token = token.Split(' ')[1];
            String name = key.ToString();
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            String value = jwtSecurityToken.Claims.First(claim => claim.Type == name).Value;
            return value;
        }

        public string GenerateServiceTokens(Claim[] claims)
        {
            var jwtToken = new JwtSecurityToken(
                _backendJwtTokenConfig.Issuer,
                _backendJwtTokenConfig.Audience ?? string.Empty,
                claims,
                expires: DateTime.Now.AddYears(99),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(_backendSecret), SecurityAlgorithms.HmacSha256Signature));
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return accessToken;
        }

        public string GenerateTokenByAccount(GenearteTokenDTO genearteTokenDto)
        {

            var claims = new Claim[]
                {
                    new Claim("UserId", genearteTokenDto.UserId),
                    new Claim("Name",genearteTokenDto.Name),
                    new Claim("Email", genearteTokenDto.Email),
                    new Claim("MobilePhone",genearteTokenDto.Mobile),
                };

            var token = GenerateTokens(claims, DateTime.Now);

            return token;
        }
    }
}
