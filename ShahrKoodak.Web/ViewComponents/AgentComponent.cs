using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShahrKoodak.Core.Services.Interfaces;

namespace ShahrKoodak.Web.ViewComponents
{
    public class AgentComponent:ViewComponent
    {
        private IAgentService _agentService;

        public AgentComponent(IAgentService agentService)
        {
            _agentService = agentService;
        }
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("Agent", _agentService.GetAllAgent()));
        }
    }
}
