using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShahrKoodak.Core.DTOs.Feature;
using ShahrKoodak.DataLayer.Entities.Product;

namespace ShahrKoodak.Core.Services.Interfaces
{
    public interface IFeatureService
    {
        List<ShowFeatureForAdminViewModel> GetBrandsForAdmin();
        Feature GetFeatureById(int featureId);
        void UpdateFeature(Feature feature);
        int AddProduct(Feature feature);
        List<ShowProductFeatureForAdminViewModel> GetListProductFeatures(int courseId);
        List<SelectListItem> GetGroupForManageProduct(int id);
        int AddFeature(ProductFeature feature);
        ProductFeature GetFeatureProductById(int FPID);
        void EditEpisode(ProductFeature feature);
        void UpdatePermissionsRole(int featureId, List<int> groups);
        List<ProductGroup> GetAllGroups();
        void AddFeaturesToGroup(int featureId, List<int> group);
        List<int> ProductFeature(int featureId);
        void DeleteProduct(int productId);
        void DeleteOrderDetail(ProductFeature product);
    }
}
