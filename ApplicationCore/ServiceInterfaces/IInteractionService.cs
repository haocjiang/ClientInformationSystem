using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IInteractionService
    {
        Task<List<InteractionResponseModel>> GetAllInteractions();
        Task<InteractionResponseModel> GetInteractionDetails(int id);
        Task<List<InteractionResponseModel>> GetInteractionByClient(int id);
        Task<List<InteractionResponseModel>> GetInteractionByEmployee(int id);
        Task<InteractionResponseModel> AddInteraction(InteractionRequestModel model);
        Task<InteractionResponseModel> UpdateInteraction(int id, InteractionRequestModel model);
        Task DeleteInteraction(int id);
    }
}
