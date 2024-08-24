using System;
using lrms.Application.DTOs;

namespace lrms.Application.Interfaces;

public interface IClientService
{
    Task<StandardReponse> Insert(ClientInsertDTO Dto);
}
