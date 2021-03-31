using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShahrKoodak.Core.Convertors;
using ShahrKoodak.Core.DTOs.Product;
using ShahrKoodak.Core.DTOs.User;
using ShahrKoodak.Core.Generator;
using ShahrKoodak.Core.Security;
using ShahrKoodak.Core.Services.Interfaces;
using ShahrKoodak.DataLayer.Context;
using ShahrKoodak.DataLayer.Entities.Product;

namespace ShahrKoodak.Core.Services
{
    public class ProductService : IProductService
    {
        private ShahrContext _context;
        private IUserService _userService;

        public ProductService(ShahrContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
            
        }
        public Tuple<List<ShowProductListItemViewModel>, int> GetArticle(int username,int pageId = 1, int take = 0, int cid = 0)
        {
            var result = _context.Product.Where(c=>c.UserId==username);

            if (take == 0)
                take = 8;



            int skip = (pageId - 1) * take;

            int pageCount = result.Select(c => new ShowProductListItemViewModel()
            {
                ProductId = c.ProductId,
                GroupTitle = c.ProductGroup.GroupTitle,
                ImageName = c.ProductImageName,
                StarNumber = c.StarNumber,
                CG = c.SubGroup.Value,
                Title = c.ProductTitle,
                Title2 = c.ProductTitle2,
                Address = c.ShortDescription,
                Mantaghe = c.Mantaghe,
                ShortDescription = c.ProductDescription,
                Tel = c.Tel1,
                PriceType = c.PriceType,
                Price = c.Price,
                CreateDate = c.CreateDate,
                Counter = c.Counter
            }).Count() / take;

            var query = result.Select(c => new ShowProductListItemViewModel()
            {
                ProductId = c.ProductId,
                GroupTitle = c.ProductGroup.GroupTitle,
                ImageName = c.ProductImageName,
                StarNumber = c.StarNumber,
                CG = c.SubGroup.Value,
                Title = c.ProductTitle,
                Title2 = c.ProductTitle2,
                Address = c.ShortDescription,
                Mantaghe = c.Mantaghe,
                ShortDescription = c.ProductDescription,
                Tel = c.Tel1,
                PriceType = c.PriceType,
                Price = c.Price,
                CreateDate = c.CreateDate,
                Counter = c.Counter
            }).Skip(skip).Take(take).ToList();

            if (cid > 0)
            {

                return Tuple.Create(query.OrderByDescending(c => c.CreateDate).Where(c => c.ProductId == cid).ToList(), pageCount);
            }

            return Tuple.Create(query.OrderByDescending(c => c.CreateDate).ToList(), pageCount);
        }
        public void AddAd(string username, InformationAdViewModel profile)
        {
            var user = _userService.GetUserByUserName(username);
            var store = _userService.getStoreByUserId(user.UserId);
            var product=new product();

            if (profile.ProductImage != null)
            {
                string imagePath = "";
               

                profile.ImageName = NameGenerator.GenerateUniqeCode() + Path.GetExtension(profile.ProductImage.FileName);
                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/image", profile.ImageName);
                product.ProductImageName = profile.ImageName;
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    profile.ProductImage.CopyTo(stream);
                }
            }
            else
            {
                profile.ImageName = "nophoto.jpg";
            }
            product.CreateDate=DateTime.Now;
            product.Counter = 0;
            product.TypeAdId = 1;
            product.GroupId = profile.GroupId;
            product.SubGroup = profile.SubGroup;
            product.ProductTitle = profile.ProductName;
            product.PriceType = profile.PriceType;
            product.UserId = user.UserId;
            product.Price = profile.Price;
            product.ProductDescription = profile.Description;
            product.IsShowTel = profile.IsShowMobile;

            _context.Add(product);
            _context.SaveChanges();
        }

        public void EditAd(InformationAdViewModel profile)
        {
            var store = GetProductById(profile.ProductId);

            if (profile.ProductImage != null)
            {
                string imagePath = "";
                if (profile.ImageName != "store-banner.jpg")
                {
                    imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/image", profile.ImageName);
                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath);
                    }
                }

                profile.ImageName = NameGenerator.GenerateUniqeCode() + Path.GetExtension(profile.ProductImage.FileName);
                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/image", profile.ImageName);
                store.ProductImageName = profile.ImageName;
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    profile.ProductImage.CopyTo(stream);
                }
            }
            else
            {
                profile.ImageName = "nophoto.jpg";
            }
           

            store.ProductTitle = profile.ProductName;
            store.SubGroup = profile.SubGroup;
            store.GroupId = profile.GroupId;
            store.TypeAdId = profile.TypeAdId;
            store.PriceType = profile.PriceType;
            store.Price = profile.Price;
            store.ProductDescription = profile.Description;
            _context.Update(store);
            _context.SaveChanges();
        }

        public int AddEpisode(ProductEpisode episode, IFormFile episodeFile)
        {
            episode.EpisodeFileName = NameGenerator.GenerateUniqeCode() + Path.GetExtension(episodeFile.FileName);

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/ProductEpisode", episode.EpisodeFileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                episodeFile.CopyTo(stream);
            }

            _context.ProductEpisodes.Add(episode);
            _context.SaveChanges();
            return episode.EpisodeId;
        }

        public int AddGroup(ProductGroup group, IFormFile imgGroup)
        {
            group.ImageName = "no-photo.jpg";
            //ToDo Check Image

            if (imgGroup != null && imgGroup.IsImage())
            {
                group.ImageName = NameGenerator.GenerateUniqeCode() + Path.GetExtension(imgGroup.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/image", group.ImageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgGroup.CopyTo(stream);
                }
                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/thumb", group.ImageName);

                imgResizer.Image_resize(imagePath, thumbPath, 150);
            }

            _context.ProductGroup.Add(group);
            _context.SaveChanges();
            return group.GroupId;
        }

        public int AddPackage(Package episode, IFormFile episodeFile)
        {
            episode.PackageImage = NameGenerator.GenerateUniqeCode() + Path.GetExtension(episodeFile.FileName);

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/ProductEpisode", episode.PackageImage);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                episodeFile.CopyTo(stream);
            }

            _context.Packages.Add(episode);
            _context.SaveChanges();
            return episode.PackageId;
        }

        public int AddProduct(product product, IFormFile imgCourse, IFormFile courseDemo)
        {
            product.CreateDate = DateTime.Now;
            product.IsActive = true;
            product.ProductImageName = "no-photo.jpg";
            //ToDo Check Image

            if (imgCourse != null && imgCourse.IsImage())
            {
                product.ProductImageName = NameGenerator.GenerateUniqeCode() + Path.GetExtension(imgCourse.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/image", product.ProductImageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgCourse.CopyTo(stream);
                }
                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/thumb", product.ProductImageName);

                imgResizer.Image_resize(imagePath, thumbPath, 150);
            }

            if (courseDemo != null)
            {
                product.DemoFileName = NameGenerator.GenerateUniqeCode() + Path.GetExtension(courseDemo.FileName);
                string demoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/demoes", product.DemoFileName);
                using (var stream = new FileStream(demoPath, FileMode.Create))
                {
                    courseDemo.CopyTo(stream);
                }
            }

            _context.Add(product);
            _context.SaveChanges();
            return product.ProductId;
        }

        public int AddSharayet(ProductSharayet episode)
        {
            _context.ProductSharayets.Add(episode);
            _context.SaveChanges();
            return episode.SharayetId;
        }

        public int AddVizhegi(ProductVizhegi episode)
        {
            _context.ProductVizhegis.Add(episode);
            _context.SaveChanges();
            return episode.VizhegiId;
        }

        public bool CheckExistFile(string fileName)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/ProductEpisode", fileName);
            return File.Exists(path);
        }

        public void DeleteGroup(int productId)
        {
            var orderDetail = GetGroupById(productId);
            DeleteGroup(orderDetail);
        }

        public void DeleteGroup(ProductGroup product)
        {
            _context.Entry(product).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void DeleteOrderDetail(product product)
        {
            _context.Entry(product).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var orderDetail = GetProductById(productId);
            DeleteOrderDetail(orderDetail);
        }

        public void EditPackage(Package episode, IFormFile episodeFile)
        {
            if (episodeFile != null)
            {
                string deleteFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/ProductEpisode", episode.PackageImage);
                File.Delete(deleteFilePath);

                episode.PackageImage = NameGenerator.GenerateUniqeCode() + Path.GetExtension(episodeFile.FileName);

                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/ProductEpisode", episode.PackageImage);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    episodeFile.CopyTo(stream);
                }

               
            }

            _context.Packages.Update(episode);
            _context.SaveChanges();
        }

        public void EditVizhegi(ProductVizhegi episode)
        {
            _context.ProductVizhegis.Update(episode);
            _context.SaveChanges();
        }

        public List<ProductGroup> GetAllGroup()
        {
            return _context.ProductGroup.Include(c => c.ProductGroups).ToList();
        }



        public ProductGroup GetById(int groupId)
        {
            return _context.ProductGroup.Find(groupId);
        }

        public Tuple<List<ShowFeatureViewModel>, int> GetCourseComment(int courseId)
        {

            int pageCount = _context.ProductFeatures.Where(c => c.ProductId == courseId).Count();
            if ((pageCount % 2) != 0)
            {
                pageCount += 1;
            }
            return Tuple.Create(
                _context.ProductFeatures.Select(d => new ShowFeatureViewModel()

                {
                    FeatureId = d.FeatureId,
                    Feature = d.Feature.FeatureTitle,
                    Value = d.Value,
                    ProductId = d.ProductId,
                    PRId = d.PF_ID
                }).ToList(), pageCount);
        }

        public ProductGroup GetGroupById(int productId)
        {
            return _context.ProductGroup.Find(productId);
        }

        public List<SelectListItem> GetGroupForManageProduct()
        {
            return _context.ProductGroup.Where(g => g.ParentId == null)
                .Select(g => new SelectListItem()
                {
                    Text = g.GroupTitle,
                    Value = g.GroupId.ToString()
                }).ToList();
        }

        public List<ProductEpisode> GetListEpisodeProduct(int courseId)
        {
            return _context.ProductEpisodes.Where(e => e.ProductId == courseId).ToList();
        }

        public List<Package> GetListPackageProduct(int courseId)
        {
            return _context.Packages.Where(e => e.ProductId == courseId).ToList();
        }

        public List<ProductSharayet> GetListSharayet(int courseId)
        {
            return _context.ProductSharayets.Where(e => e.ProductId == courseId).ToList();
        }

        public List<ProductVizhegi> GetListVizhegi(int courseId)
        {
            return _context.ProductVizhegis.Where(e => e.ProductId == courseId).ToList();
        }

        public Package GetPackageById(int episodeId)
        {
            return _context.Packages.Find(episodeId);
        }

        public List<ShowProductListItemViewModel> GetPopularProduct()
        {
            return _context.Product.Include(c => c.OrderDetails)
                .Where(c => c.OrderDetails.Any())
                .OrderByDescending(d => d.OrderDetails.Count)
                .Take(8)
                .Select(c => new ShowProductListItemViewModel()
                {
                    ProductId = c.ProductId,
                    ImageName = c.ProductImageName,
                    GroupTitle = c.ProductGroup.GroupTitle,
                    CG = c.SubGroup.Value,
                    Title = c.ProductTitle,
                })
                .ToList();
        }

        public Tuple<List<ShowProductListItemViewModel>, int> GetProduct(int pageId = 1, string filter = "", string getType = "all", string orderByType = "date", int startPrice = 0, int endPrice = 0, List<int> selectedGroups = null, int take = 0, int cid = 0)
        {
            if (take == 0)
                take = 18;

            IQueryable<product> result = _context.Product;

            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(c => (c.ProductTitle.Contains(filter) || c.Tags.Contains(filter)));
            }

            switch (getType)
            {
                case "all":
                    break;
                case "price":
                    {
                        result = result.Where(c => c.StarNumber != 0);
                        break;
                    }
                case "free":
                    {
                        result = result.Where(c => c.StarNumber == 0);
                        break;
                    }
            }

            switch (orderByType)
            {
                case "date":
                    {
                        result = result.OrderByDescending(c => c.CreateDate);
                        break;
                    }
                case "updateDate":
                    {
                        result = result.OrderByDescending(c => c.UpdateDate);
                        break;
                    }
            }

            if (startPrice > 0)
            {
                result = result.Where(c => c.StarNumber > startPrice);
            }

            if (endPrice > 0)
            {
                result = result.Where(c => c.StarNumber < endPrice);
            }

            if (cid > 0)
            {
                result = result.Where(c => c.ProductId == cid);
            }



            if (selectedGroups != null && selectedGroups.Any())
            {
                foreach (int groupId in selectedGroups)
                {
                    result = result.Where(c => c.GroupId == groupId || c.SubGroup == groupId);
                }
            }



            int skip = (pageId - 1) * take;

            int pageCount = result.Include(c => c.ProductEpisodes).Where(c=>c.IsActive).Include(e=>e.ProductGroup).Select(c => new ShowProductListItemViewModel()
            {
                ProductId = c.ProductId,
                GroupTitle = c.ProductGroup.GroupTitle,
                ImageName = c.ProductImageName,
                StarNumber = c.StarNumber,
                CG = c.SubGroup.Value,
                Title = c.ProductTitle,
                Title2 = c.ProductTitle2,
                Address = c.ShortDescription,
                Mantaghe = c.Mantaghe,
                ShortDescription = c.ProductDescription,
                Tel = c.Tel1,
                PriceType = c.PriceType,
                Price = c.Price,
                CreateDate = c.CreateDate,
                Counter = c.Counter
            }).Count() / take;

            var query = result.Include(c => c.ProductEpisodes).Where(c=>c.IsActive).Select(c => new ShowProductListItemViewModel()
            {
                ProductId = c.ProductId,
                GroupTitle = c.ProductGroup.GroupTitle,
                ImageName = c.ProductImageName,
                StarNumber = c.StarNumber,
                CG = c.SubGroup.Value,
                Title = c.ProductTitle,
                Title2 = c.ProductTitle2,
                Address = c.ShortDescription,
                Mantaghe = c.Mantaghe,
                ShortDescription = c.ProductDescription,
                Tel = c.Tel1,
                PriceType = c.PriceType,
                Price = c.Price,
                CreateDate = c.CreateDate,
                Counter = c.Counter
            }).Skip(skip).Take(take).ToList();

            return Tuple.Create(query, pageCount);
        }

        public product GetProductById(int productId)
        {
            return _context.Product.Find(productId);
        }

        public InformationAdViewModel GetProductById2(int productId,InformationAdViewModel profile)
        {
            var store = GetProductById(productId);
            var product = new product();

            if (profile.ProductImage != null)
            {
                string imagePath = "";


                profile.ImageName = NameGenerator.GenerateUniqeCode() + Path.GetExtension(profile.ProductImage.FileName);
                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/image", profile.ImageName);
                product.ProductImageName = profile.ImageName;
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    profile.ProductImage.CopyTo(stream);
                }
            }
            profile.ImageName = store.ProductImageName;
            profile.ProductId = store.ProductId;
            profile.GroupId = store.GroupId;
            profile.SubGroup = store.SubGroup;
            profile.ProductName = store.ProductTitle;
            profile.PriceType = store.PriceType;
            profile.Price = store.Price;
            profile.Description = product.ProductDescription;

            return profile;
        }

        public List<product> GetProductByUserId(string username)
        {
            var user = _userService.GetUserByUserName(username);
            return _context.Product.Where(c => c.UserId == user.UserId).ToList();
        }

        public product GetProductForShow(int productId)
        {
            return _context.Product.Include(c => c.ProductEpisodes)
                .Include(e => e.ProductFeatures)
                //.Include(c => c.UserProducts)
                .Include(g=>g.Packages)
                .Include(u=>u.ProductGroup)

                .FirstOrDefault(c => c.ProductId == productId);
        }

        public List<ShowProductForAdminViewModel> GetProductsForAdmin(string filterProduct = "",
            string filterProductGroup = "")
        {

            IQueryable<product> result = _context.Product;

            if (!string.IsNullOrEmpty(filterProduct))
            {
                result = result.Where(u => u.ProductTitle.Contains(filterProduct));
            }

            if (!string.IsNullOrEmpty(filterProductGroup))
            {
                result = result.Where(u => u.ProductGroup.GroupTitle.Contains(filterProductGroup));
            }






            return result.Select(c => new ShowProductForAdminViewModel()
            {
                ProductId = c.ProductId,
                ImageName = c.ProductImageName,
                Title = c.ProductTitle,
                EpisodeCount = c.ProductEpisodes.Count,
                ProductGroup = c.ProductGroup.GroupTitle,
                IsActive = c.IsActive
            }).ToList();
        }

        public List<SelectListItem> GetRelationCourse1()
        {
            return _context.Product
                .Select(u => new SelectListItem()
                {
                    Value = u.ProductId.ToString(),
                    Text = u.ProductTitle
                }).ToList();
        }

        public List<SelectListItem> GetRelationCourse2()
        {
            return _context.Product
                .Select(u => new SelectListItem()
                {
                    Value = u.ProductId.ToString(),
                    Text = u.ProductTitle
                }).ToList();
        }

        public List<SelectListItem> GetRelationCourse3()
        {
            return _context.Product
                .Select(u => new SelectListItem()
                {
                    Value = u.ProductId.ToString(),
                    Text = u.ProductTitle
                }).ToList();
        }

        public List<SelectListItem> GetSubGroupForManageCourse(int groupId)
        {
            return _context.ProductGroup.Where(g => g.ParentId == groupId)
                .Select(g => new SelectListItem()
                {
                    Text = g.GroupTitle,
                    Value = g.GroupId.ToString()
                }).ToList();
        }

        public ProductVizhegi GetVizhegiById(int episodeId)
        {
            return _context.ProductVizhegis.Find(episodeId);
        }

        public List<ShowFeatureViewModel> ShowFeature(int productId)
        {
            return _context.ProductFeatures.Where(c => c.ProductId == productId).Select(s => new ShowFeatureViewModel()
            {
                Value = s.Value,
                Feature = s.Feature.FeatureTitle,
                FeatureId = s.FeatureId,
                ProductId = s.ProductId,
                PRId = s.PF_ID
            }).ToList();
        }

        public int UpdateGroup(ProductGroup group, IFormFile imgGroup)
        {
            if (imgGroup != null && imgGroup.IsImage())
            {
                if (group.ImageName != "no-photo.jpg")
                {

                    string deleteImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/image", group.ImageName);
                    if (File.Exists(deleteImagePath))
                    {
                        File.Delete(deleteImagePath);
                    }

                    string deleteThumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/thumb", group.ImageName);
                    if (File.Exists(deleteThumbPath))
                    {
                        File.Delete(deleteThumbPath);
                    }

                }

                group.ImageName = NameGenerator.GenerateUniqeCode() + Path.GetExtension(imgGroup.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/image", group.ImageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgGroup.CopyTo(stream);
                }
                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/thumb", group.ImageName);

                imgResizer.Image_resize(imagePath, thumbPath, 150);
            }

            _context.ProductGroup.Update(group);
            _context.SaveChanges();
            return group.GroupId;
        }

        public void UpdateProduct(product product, IFormFile imgCourse, IFormFile courseDemo)
        {
            product.UpdateDate = DateTime.Now;

            if (imgCourse != null && imgCourse.IsImage())
            {
                if (product.ProductImageName != "no-photo.jpg")
                {
                    if (product.DemoFileName != null)
                    {
                        string deleteImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/image", product.ProductImageName);
                        if (File.Exists(deleteImagePath))
                        {
                            File.Delete(deleteImagePath);
                        }

                        string deleteThumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/thumb", product.ProductImageName);
                        if (File.Exists(deleteThumbPath))
                        {
                            File.Delete(deleteThumbPath);
                        }
                    }
                }

                product.ProductImageName = NameGenerator.GenerateUniqeCode() + Path.GetExtension(imgCourse.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/image", product.ProductImageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgCourse.CopyTo(stream);
                }
                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/thumb", product.ProductImageName);

                imgResizer.Image_resize(imagePath, thumbPath, 150);
            }

            if (courseDemo != null)
            {
                if (product.DemoFileName != null)
                {
                    string deleteDemoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/demoes", product.DemoFileName);
                    if (File.Exists(deleteDemoPath))
                    {
                        File.Delete(deleteDemoPath);
                    }
                }

                product.DemoFileName = NameGenerator.GenerateUniqeCode() + Path.GetExtension(courseDemo.FileName);
                string demoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/demoes", product.DemoFileName);
                using (var stream = new FileStream(demoPath, FileMode.Create))
                {
                    courseDemo.CopyTo(stream);
                }
            }

            _context.Product.Update(product);
            _context.SaveChanges();
        }
    }
}
