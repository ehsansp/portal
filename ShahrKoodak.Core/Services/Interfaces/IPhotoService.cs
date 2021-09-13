using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using PortalBuilder.Core.DTOs.Photo;
using PortalBuilder.Models;

namespace PortalBuilder.Core.Services.Interfaces
{
    public interface IPhotoService
    {
        List<ShowPhotoForAdminViewModel> getPhotoForAdminViewModels();
        List<ShowPhotoGalleryForAdminViewModel> getPhotoGalleryForAdminViewModels();
        int AddPhoto(Photo photo);
        int AddGallery(PhotoGallery gallery, IFormFile imgBank);
        Photo GetPhotoById(int photoId);
        PhotoGallery GetGalleryById(int galleryId);
        int UpdatePhoto(Photo photo);
        int UpdateGallery(PhotoGallery gallery, IFormFile imgArticle);
    }
}
