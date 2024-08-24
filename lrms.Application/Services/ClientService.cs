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
    private readonly IUserRepository _user;
    private readonly IMapper<ClientEntity, ClientAggregate> _mapper;

    public ClientService(IClientRepository repository, IMapper<ClientEntity, ClientAggregate> mapper, IUserRepository user)
    {
        _repository = repository;
        _mapper = mapper;
        _user = user;
    }

    public Task<StandardReponse> Insert(ClientInsertDTO Dto)
    {
        throw new NotImplementedException();
    }
}
