using System;
using lrms.Application.DTOs;
using lrms.Application.Interfaces;
using lrms.Domain.Aggregates;
using lrms.Infra.Data.Interfaces;

namespace lrms.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<UserOutputDTO?> Insert(UserInsertDTO dto)
    {
        UserAggregate aggregate = new(dto.Name,
                                      dto.Email,
                                      dto.Password,
                                      dto.CreatedBy);

        bool isOk = await _repository.Insert(aggregate);

        if (isOk)
        {
            return new UserOutputDTO
            {
                Id = aggregate.Id,
                Name = aggregate.Name,
                Email = aggregate.Email,
                Password = aggregate.Password,
            };
        }

        return null;
    }

    public async Task<LoginOutputDTO?> Login(LoginInputDTO dto)
    {
        UserAggregate? aggregate = await _repository.Login(dto.Email, dto.Password);

        if (aggregate == null) return null;

        return new LoginOutputDTO
        {
            Id = aggregate.Id,
            Name = aggregate.Name
        };
    }
}
