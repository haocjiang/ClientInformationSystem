using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IClientService
    {
        Task<List<ClientResponseModel>> GetAllClients();
        Task<ClientResponseModel> GetClientDetails(int id);
        Task<ClientResponseModel> AddClient(ClientRequestModel model);
        Task<ClientResponseModel> UpdateClient(int id, ClientRequestModel model);
        Task DeleteClient(int id);

    }
}
