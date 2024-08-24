using System;
using lrms.Application.DTOs;
using lrms.Application.Interfaces;
using lrms.Domain.Aggregates;
using lrms.Infra.Data.Entities;
using lrms.Infra.Data.Interfaces;

namespace lrms.Application.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _repository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper<ClientEntity, ClientAggregate> _mapper;

    public ClientService(IClientRepository repository, IMapper<ClientEntity, ClientAggregate> mapper, IUserRepository user)
    {
        _repository = repository;
        _mapper = mapper;
        _userRepository = user;
    }

    public async Task<StandardReponse> Insert(ClientInsertDTO Dto)
    {
        var user = await _userRepository.FindById(Dto.CreatedBy);

        if (user == null)
        {
            return new StandardReponse
            {
                Message = "No user found",
                StatusCode = 404
            };
        }

        var aggregate = new ClientAggregate(Dto.Name, Dto.Email, Dto.Phone, user);

        var result = await _repository.Insert(aggregate);

        if (result == false)
        {
            return new StandardReponse
            {
                Message = "We cant create this Client",
                StatusCode = 500
            };
        }

        return new StandardReponse
        {
            Message = "OK",
            StatusCode = 201
        };
    }
}
