using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShahrKoodak.Core.DTOs.Product;
using ShahrKoodak.Core.DTOs.User;
using ShahrKoodak.DataLayer.Entities.Product;

namespace ShahrKoodak.Core.Services.Interfaces
{
    public interface IProductService
    {
        Tuple<List<ShowProductListItemViewModel>, int> GetArticle(int username,int pageId = 1, int take = 0, int cid = 0);

        List<ProductGroup> GetAllGroup();
        Package GetPackageById(int episodeId);
        ProductVizhegi GetVizhegiById(int episodeId);
        int AddGroup(ProductGroup group, IFormFile imgGroup);
        ProductGroup GetById(int groupId);
        int UpdateGroup(ProductGroup group, IFormFile imgGroup);

        List<ShowProductForAdminViewModel> GetProductsForAdmin(string filterProduct = "",
            string filterProductGroup = "");
        
        List<SelectListItem> GetGroupForManageProduct();
        List<SelectListItem> GetSubGroupForManageCourse(int groupId);
        List<SelectListItem> GetRelationCourse1();
        int AddProduct(product product, IFormFile imgCourse, IFormFile courseDemo);
        void AddAd(string username, InformationAdViewModel profile);
        void EditAd(InformationAdViewModel profile);
        product GetProductById(int productId);
        InformationAdViewModel GetProductById2(int productId,InformationAdViewModel profile);
        List<product> GetProductByUserId(string username);
        ProductGroup GetGroupById(int productId);
        List<SelectListItem> GetRelationCourse2();
        List<SelectListItem> GetRelationCourse3();
        void UpdateProduct(product product, IFormFile imgCourse, IFormFile courseDemo);
        Tuple<List<ShowProductListItemViewModel>, int> GetProduct(int pageId = 1, string filter = "", string getType = "all",
            string orderByType = "date", int startPrice = 0, int endPrice = 0, List<int> selectedGroups = null, int take = 0, int cid = 0);
        List<ShowProductListItemViewModel> GetPopularProduct();
        product GetProductForShow(int productId);
        bool CheckExistFile(string fileName);
        int AddEpisode(ProductEpisode episode, IFormFile episodeFile);
        int AddPackage(Package episode, IFormFile episodeFile);
        int AddSharayet(ProductSharayet episode);
        int AddVizhegi(ProductVizhegi episode);
        List<ProductEpisode> GetListEpisodeProduct(int courseId);
        List<Package> GetListPackageProduct(int courseId);
        List<ProductVizhegi> GetListVizhegi(int courseId);
        List<ProductSharayet> GetListSharayet(int courseId);

        Tuple<List<ShowFeatureViewModel>, int> GetCourseComment(int courseId);
        List<ShowFeatureViewModel> ShowFeature(int productId);
        void DeleteProduct(int productId);
        void DeleteGroup(int productId);

        void DeleteOrderDetail(product product);
        void DeleteGroup(ProductGroup product);
        void EditPackage(Package episode, IFormFile episodeFile);
        void EditVizhegi(ProductVizhegi episode);


    }
}
