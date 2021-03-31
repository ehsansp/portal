using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using ShahrKoodak.Core.DTOs.Agent;
using ShahrKoodak.DataLayer.Entities.Agent;

namespace ShahrKoodak.Core.Services.Interfaces
{
    public interface IAgentService
    {
        int AddProduct(Agent agent);
        Agent GetAgentById(int agentId);
        void UpdateBrand(Agent agent);
        List<ShowAgentForAdminViewModel> GetAgentsForAdmin();
        List<Agent> GetAllAgent();


    }
}
