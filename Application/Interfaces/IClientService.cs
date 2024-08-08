using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Continuum.Core.Entities;

namespace Continuum.Application.Interfaces
{
    public interface IClientService
    {
        Task<Client> GetClientByIdAsync(int id);
        Task<IEnumerable<Client>> GetAllClientsAsync();
        Task AddClientAsync(Client client);
        Task UpdateClientAsync(Client client);
        Task DeleteClientAsync(int id);
    }
}