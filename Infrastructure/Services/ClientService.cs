using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<ClientResponseModel> AddClient(ClientRequestModel model)
        {
            var client = new Client
            {
                Name = model.Name,
                Email = model.Email,
                Phones = model.Phones,
                Address = model.Address,
                AddedOn = model.AddedOn
            };

            var newClient = await _clientRepository.AddAsync(client);

            var newClientInfo = new ClientResponseModel
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                Phones = client.Phones,
                Address = client.Address,
                AddedOn = client.AddedOn
            };

            return newClientInfo;
        }

        public async Task DeleteClient(int id)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            await _clientRepository.DeleteAsync(client);
        }

        public async Task<List<ClientResponseModel>> GetAllClients()
        {
            var clients = await _clientRepository.ListAllAsync();
            List<ClientResponseModel> clientList = new List<ClientResponseModel>();
            foreach (var client in clients)
            {
                clientList.Add(new ClientResponseModel
                {
                    Id = client.Id,
                    Name = client.Name,
                    Email = client.Email,
                    Phones = client.Phones,
                    Address = client.Address,
                    AddedOn = client.AddedOn
                });
            }
            return clientList;
        }

        public async Task<ClientResponseModel> GetClientDetails(int id)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            var clientDetails = new ClientResponseModel
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                Phones = client.Phones,
                Address = client.Address,
                AddedOn = client.AddedOn
            };
            return clientDetails;
        }

        public async Task<ClientResponseModel> UpdateClient(int id, ClientRequestModel model)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            client.Name = model.Name;
            client.Email = model.Email;
            client.Phones = model.Phones;
            client.Address = model.Address;
            client.AddedOn = model.AddedOn;

            var clientDetails = new ClientResponseModel
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                Phones = client.Phones,
                Address = client.Address,
                AddedOn = client.AddedOn
            };
            var updatedClient = await _clientRepository.UpdateAsync(client);
            return clientDetails;
        }
    }
}
