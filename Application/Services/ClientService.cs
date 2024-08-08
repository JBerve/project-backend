using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Continuum.Application.Interfaces;
using Continuum.Core.Entities;
using Continuum.Core.Interfaces;

namespace Continuum.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ClientService(IClientRepository clientRepository, IUnitOfWork unitOfWork)
        {
            _clientRepository = clientRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            return await _clientRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            return await _clientRepository.GetAllAsync();
        }

        public async Task AddClientAsync(Client client)
        {
            await _clientRepository.AddAsync(client);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateClientAsync(Client client)
        {
            _clientRepository.UpdateAsync(client);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteClientAsync(int id)
        {
            await _clientRepository.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }
    }
}