using Supliex.Domain.Dtos.Account;
using Supliex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supliex.Application.Common.Interface.Iservices
{
    public interface IAuthService
    {
        string CreateToken(ApplicationUser user);
        Task<NewUserDto> Login(LoginDto user);
        Task<NewUserDto> RefreshToken(RefreshTokenDto model);
        Task<bool> RegisterUser(RegisterDto user);


    }
}
