using System;
using lrms.Application.DTOs;

namespace lrms.Application.Interfaces;

public interface IUserService
{
    Task<LoginOutputDTO?> Login(LoginInputDTO dto);
    Task<UserInsertDTO?> Insert(UserInsertDTO dto);
}
