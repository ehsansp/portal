using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using ShahrKoodak.Core.Convertors;
using ShahrKoodak.Core.DTOs.Agent;
using ShahrKoodak.Core.Generator;
using ShahrKoodak.Core.Security;
using ShahrKoodak.Core.Services.Interfaces;
using ShahrKoodak.DataLayer.Context;
using ShahrKoodak.DataLayer.Entities.Agent;

namespace ShahrKoodak.Core.Services
{
    public class AgentService : IAgentService
    {
        private ShahrContext _context;

        public AgentService(ShahrContext context)
        {
            _context = context;
        }
        public int AddProduct(Agent agent)
        {
            _context.Add(agent);
            _context.SaveChanges();
            return agent.AgentId;

        }

        public Agent GetAgentById(int agentId)
        {
            return _context.Agents.Find(agentId);
        }

        public List<ShowAgentForAdminViewModel> GetAgentsForAdmin()
        {
            return _context.Agents.Select(c => new ShowAgentForAdminViewModel()
            {
                AgentId = c.AgentId,
                Name = c.AgentName,
                Location = c.AgentLocation
            }).ToList();
        }

        public List<Agent> GetAllAgent()
        {
            return _context.Agents.ToList();
        }

        public void UpdateBrand(Agent agent)
        {
            _context.Agents.Update(agent);
            _context.SaveChanges();
        }
    }
}
