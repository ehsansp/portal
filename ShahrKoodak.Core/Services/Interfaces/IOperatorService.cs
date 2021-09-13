using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using PortalBuilder.Core.DTOs.Operator;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services.Interfaces
{
    public interface IOperatorService
    {
        List<ShowOperatorForAdminViewModel> getOperatorForAdminViewModels();
        List<ShowOperatorRoleForAdminViewModel> getOperatorRoleForAdminViewModels();
        int AddOperator(Operator opOperator, IFormFile imgBank);
        int AddOperatorRole(OperatorRole operatorRole);
        Operator GetLandingById(int operatorId);
        OperatorRole GetOperatorRoleById(int operatorRoleId);
        int UpdateOperator(Operator oOperator, IFormFile imgArticle);
        int UpdateOperatorRole(OperatorRole operatorRole);
    }
}
