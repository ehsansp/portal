using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShahrKoodak.Core.DTOs.Feature;
using ShahrKoodak.Core.Services.Interfaces;
using ShahrKoodak.DataLayer.Context;
using ShahrKoodak.DataLayer.Entities.Product;

namespace ShahrKoodak.Core.Services
{
    public class FeatureService : IFeatureService
    {
        private ShahrContext _context;

        public FeatureService(ShahrContext context)
        {
            _context = context;
        }

        public int AddFeature(ProductFeature feature)
        {
            _context.ProductFeatures.Add(feature);
            _context.SaveChanges();
            return feature.FeatureId;
        }

        public void AddFeaturesToGroup(int featureId, List<int> group)
        {
            foreach (var p in group)
            {
                _context.FeatureGroups.Add(new FeatureGroup()
                {
                    ProductGroupId = p,
                    FeatureId = featureId
                });
            }

            _context.SaveChanges();
        }

        public int AddProduct(Feature feature)
        {
            _context.Add(feature);
            _context.SaveChanges();
            return feature.FeatureId;
        }

        public void DeleteOrderDetail(ProductFeature product)
        {
            _context.Entry(product).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var orderDetail = GetFeatureProductById(productId);
            DeleteOrderDetail(orderDetail);
        }

        public void EditEpisode(ProductFeature feature)
        {
            _context.ProductFeatures.Update(feature);
            _context.SaveChanges();
        }

        public List<ProductGroup> GetAllGroups()
        {
            return _context.ProductGroup.ToList();
        }

        public List<ShowFeatureForAdminViewModel> GetBrandsForAdmin()
        {
            return _context.Features.Select(c => new ShowFeatureForAdminViewModel()
            {
                FeatureId = c.FeatureId,
                Title = c.FeatureTitle
            }).ToList();
        }

        public Feature GetFeatureById(int featureId)
        {
            return _context.Features.Find(featureId);
        }

        public ProductFeature GetFeatureProductById(int FPID)
        {
            return _context.ProductFeatures.Find(FPID);
        }

        public List<SelectListItem> GetGroupForManageProduct(int id)
        {
            int? q = 0;
            q = _context.Product.Find(id).SubGroup;
            return _context.FeatureGroups.Where(r=>r.ProductGroupId==q)
                .Select(g => new SelectListItem()
                {
                    Text = g.Feature.FeatureTitle,
                    Value = g.FeatureId.ToString()
                }).ToList();
        }

        public List<ShowProductFeatureForAdminViewModel> GetListProductFeatures(int courseId)
        {



            return _context.ProductFeatures.Where(e => e.ProductId == courseId).Select(e => new ShowProductFeatureForAdminViewModel()
            {
                FeatureId =e.FeatureId,
                Value = e.Value,
                ProductId = e.ProductId,
                Title = e.Feature.FeatureTitle,
                PFID = e.PF_ID
            }).ToList();
        }

        public List<int> ProductFeature(int featureId)
        {
            return _context.FeatureGroups
                .Where(r => r.FeatureId == featureId)
                .Select(r => r.ProductGroupId).ToList();
        }

        public void UpdateFeature(Feature feature)
        {
            _context.Features.Update(feature);
            _context.SaveChanges();
        }

        public void UpdatePermissionsRole(int featureId, List<int> groups)
        {
            _context.FeatureGroups.Where(p => p.FeatureId == featureId)
                .ToList().ForEach(p => _context.FeatureGroups.Remove(p));

            AddFeaturesToGroup(featureId, groups);
        }
    }
}
