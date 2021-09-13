using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using PortalBuilder.Core.DTOs.Notification;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services.Interfaces
{
    public interface INotificationService
    {
        List<ShowNotificationForAdminViewModel> getNotificationForAdminViewModels();
        int AddNotification(Notification notification, IFormFile imgBank);
        Notification GetNotificationById(int notificationId);
        int UpdateNotification(Notification notification, IFormFile imgArticle);
    }
}
