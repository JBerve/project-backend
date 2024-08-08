using System.Collections.Generic;
using System.Threading.Tasks;
using Continuum.Core.Entities;

public interface IClientRepository
{
    Task<Client> GetByIdAsync(int id);
    Task<IEnumerable<Client>> GetAllAsync();
    Task AddAsync(Client client);
    Task UpdateAsync(Client client);
    Task DeleteAsync(int id);
}