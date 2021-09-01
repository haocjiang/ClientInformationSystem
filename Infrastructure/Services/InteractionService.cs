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
    public class InteractionService : IInteractionService
    {
        private readonly IInteractionRepository _interactionRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IEmployeeRepository _employeeRepository;
        public InteractionService(IInteractionRepository interactionRepository, IClientRepository clientRepository, IEmployeeRepository employeeRepository)
        {
            _interactionRepository = interactionRepository;
            _clientRepository = clientRepository;
            _employeeRepository = employeeRepository;
        }
        public async Task<InteractionResponseModel> AddInteraction(InteractionRequestModel model)
        {
            var interaction = new Interaction
            {
                ClientId = model.ClientId,
                EmpId = model.EmpId,
                IntType = model.IntType,
                IntDate = model.IntDate,
                Remarks = model.Remarks
            };
            var newInteraction = await _interactionRepository.AddAsync(interaction);
            var interactionModel = new InteractionResponseModel
            {
                Id = newInteraction.Id,
                ClientId = newInteraction.ClientId,
                EmpId = newInteraction.EmpId,
                IntType = newInteraction.IntType,
                IntDate = newInteraction.IntDate,
                Remarks = newInteraction.Remarks
            };
            return interactionModel;
        }

        public async Task DeleteInteraction(int id)
        {
            var interaction = await _interactionRepository.GetByIdAsync(id);
            await _interactionRepository.DeleteAsync(interaction);
        }

        public async Task<List<InteractionResponseModel>> GetAllInteractions()
        {
            var interaction = await _interactionRepository.ListAllAsync();
            var interactionList = new List<InteractionResponseModel>();
            foreach (var interact in interaction)
            {
                interactionList.Add(new InteractionResponseModel
                {
                    Id = interact.Id,
                    ClientId = interact.ClientId,
                    EmpId = interact.EmpId,
                    IntType = interact.IntType,
                    IntDate = interact.IntDate,
                    Remarks = interact.Remarks
                });
            }
            return interactionList;
        }

        public async Task<InteractionResponseModel> GetInteractionDetails(int id)
        {
            var interaction = await _interactionRepository.GetByIdAsync(id);
            var interactionModel = new InteractionResponseModel
            {
                Id = interaction.Id,
                ClientId = interaction.ClientId,
                EmpId = interaction.EmpId,
                IntType = interaction.IntType,
                IntDate = interaction.IntDate,
                Remarks = interaction.Remarks
            };
            return interactionModel;
        }

        public async Task<List<InteractionResponseModel>> GetInteractionByClient(int id)
        {
            var interactions = await _interactionRepository.GetInteractionByClient(id);
            List<InteractionResponseModel> interactionList = new List<InteractionResponseModel>();
            foreach (var interaction in interactions)
            {
                var model = new InteractionResponseModel();
                model.Id = interaction.Id;
                model.ClientId = interaction.ClientId;
                model.IntType = interaction.IntType;
                model.IntDate = interaction.IntDate;
                model.Remarks = interaction.Remarks;
                interactionList.Add(model);
            }
            return interactionList;
        }

        public async Task<List<InteractionResponseModel>> GetInteractionByEmployee(int id)
        {
            var interactions = await _interactionRepository.GetInteractionByEmployee(id);
            List<InteractionResponseModel> interactionList = new List<InteractionResponseModel>();
            foreach (var interaction in interactions)
            {
                var model = new InteractionResponseModel();
                model.Id = interaction.Id;
                model.ClientId = interaction.ClientId;
                model.IntType = interaction.IntType;
                model.IntDate = interaction.IntDate;
                model.Remarks = interaction.Remarks;
                interactionList.Add(model);
            }
            return interactionList;
        }

        public async Task<InteractionResponseModel> UpdateInteraction(int id, InteractionRequestModel model)
        {
            var interaction = await _interactionRepository.GetByIdAsync(id);
            interaction.ClientId = model.ClientId;
            interaction.EmpId = model.EmpId;
            interaction.IntType = model.IntType;
            interaction.IntDate = model.IntDate;
            interaction.Remarks = model.Remarks;

            var interactionDetails = new InteractionResponseModel
            {
                Id = interaction.Id,
                ClientId = interaction.ClientId,
                EmpId = interaction.EmpId,
                IntType = interaction.IntType,
                IntDate = interaction.IntDate,
                Remarks = interaction.Remarks
            };

            var updatedInteraction = await _interactionRepository.UpdateAsync(interaction);

            return interactionDetails;
        }
    }
}
