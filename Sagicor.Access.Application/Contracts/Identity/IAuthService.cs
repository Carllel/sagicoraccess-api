using Sagicor.Access.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sagicor.Access.Application.Contracts.Identity;

public interface IAuthService
{
    Task<AuthResponse> Login(AuthRequest request);
    Task<AuthResponse> RefreshToken(RefreshTokenRequest request);
    Task<RegistrationResponse> Register(RegistrationRequest request);

}
