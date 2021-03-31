using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using ShahrKoodak.Core.Convertors;
using ShahrKoodak.Core.DTOs.Banner;
using ShahrKoodak.Core.Generator;
using ShahrKoodak.Core.Security;
using ShahrKoodak.Core.Services.Interfaces;
using ShahrKoodak.DataLayer.Context;
using ShahrKoodak.DataLayer.Entities.Slider;

namespace ShahrKoodak.Core.Services
{
    public class SliderService : ISliderService
    {
        private ShahrContext _context;

        public SliderService(ShahrContext context)
        {
            _context = context;
        }

        public int AddSlider(Slider slider, IFormFile imgCourse)
        {
            slider.SliderImageName = "no-photo.jpg";
            //ToDo Check Image

            if (imgCourse != null && imgCourse.IsImage())
            {
                slider.SliderImageName = NameGenerator.GenerateUniqeCode() + Path.GetExtension(imgCourse.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/image", slider.SliderImageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgCourse.CopyTo(stream);
                }
                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/thumb", slider.SliderImageName);

                imgResizer.Image_resize(imagePath, thumbPath, 150);
            }



            _context.Add(slider);
            _context.SaveChanges();
            return slider.SliderId;
        }

        public LeftBanner GetLeftBannerById(int leftId)
        {
            return _context.LeftBanner.Find(leftId);
        }

        public void UpdateSlider(Slider slider, IFormFile imgCourse)
        {
            if (imgCourse != null && imgCourse.IsImage())
            {
                if (slider.SliderImageName != "no-photo.jpg")
                {
                    string deleteImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/image", slider.SliderImageName);
                    if (File.Exists(deleteImagePath))
                    {
                        File.Delete(deleteImagePath);
                    }
                    string deleteThumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/thumb", slider.SliderImageName);
                    if (File.Exists(deleteThumbPath))
                    {
                        File.Delete(deleteThumbPath);
                    }
                }

                slider.SliderImageName = NameGenerator.GenerateUniqeCode() + Path.GetExtension(imgCourse.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/image",
                    slider.SliderImageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgCourse.CopyTo(stream);
                }

                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/thumb",
                    slider.SliderImageName);

                imgResizer.Image_resize(imagePath, thumbPath, 150);
            }
            _context.Slider.Update(slider);
            _context.SaveChanges();
        }

        public Slider GetSliderById(int sliderId)
        {
            return _context.Slider.Find(sliderId);
        }

        public List<ShowSliderForAdminViewModel> GetSlidersForAdmin()
        {
            return _context.Slider.Select(c => new ShowSliderForAdminViewModel()
            {
                SliderId = c.SliderId,
                ImageName = c.SliderImageName,
                Title = c.Text1
            }).ToList();
        }

        public void UpdateLeftBanner(LeftBanner leftBanner, IFormFile imgCourse)
        {
            if (imgCourse != null && imgCourse.IsImage())
            {
                if (leftBanner.ImageName != "no-photo.jpg")
                {
                    string deleteImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/image", leftBanner.ImageName);
                    if (File.Exists(deleteImagePath))
                    {
                        File.Delete(deleteImagePath);
                    }
                    string deleteThumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/thumb", leftBanner.ImageName);
                    if (File.Exists(deleteThumbPath))
                    {
                        File.Delete(deleteThumbPath);
                    }
                }

                leftBanner.ImageName = NameGenerator.GenerateUniqeCode() + Path.GetExtension(imgCourse.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/image",
                    leftBanner.ImageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgCourse.CopyTo(stream);
                }

                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/thumb",
                    leftBanner.ImageName);

                imgResizer.Image_resize(imagePath, thumbPath, 150);
            }
            _context.LeftBanner.Update(leftBanner);
            _context.SaveChanges();
        }

        public RightBanner GetRightBannerById(int rightId)
        {
            return _context.RightBanner.Find(rightId);
        }

        public void UpdateRightBanner(RightBanner rightBanner, IFormFile imgCourse)
        {
            if (imgCourse != null && imgCourse.IsImage())
            {
                if (rightBanner.ImageName != "no-photo.jpg")
                {
                    string deleteImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/image", rightBanner.ImageName);
                    if (File.Exists(deleteImagePath))
                    {
                        File.Delete(deleteImagePath);
                    }
                    string deleteThumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/thumb", rightBanner.ImageName);
                    if (File.Exists(deleteThumbPath))
                    {
                        File.Delete(deleteThumbPath);
                    }
                }

                rightBanner.ImageName = NameGenerator.GenerateUniqeCode() + Path.GetExtension(imgCourse.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/image",
                    rightBanner.ImageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgCourse.CopyTo(stream);
                }

                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/thumb",
                    rightBanner.ImageName);

                imgResizer.Image_resize(imagePath, thumbPath, 150);
            }
            _context.RightBanner.Update(rightBanner);
            _context.SaveChanges();
        }

        public MiddleBanner GetMiddleBannerById(int middleId)
        {
            return _context.MiddleBanner.Find(middleId);
        }

        public void UpdateMiddleBanner(MiddleBanner middleBanner, IFormFile imgCourse)
        {
            if (imgCourse != null && imgCourse.IsImage())
            {
                if (middleBanner.ImageName != "no-photo.jpg")
                {
                    string deleteImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/image", middleBanner.ImageName);
                    if (File.Exists(deleteImagePath))
                    {
                        File.Delete(deleteImagePath);
                    }
                    string deleteThumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/thumb", middleBanner.ImageName);
                    if (File.Exists(deleteThumbPath))
                    {
                        File.Delete(deleteThumbPath);
                    }
                }

                middleBanner.ImageName = NameGenerator.GenerateUniqeCode() + Path.GetExtension(imgCourse.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/image",
                    middleBanner.ImageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgCourse.CopyTo(stream);
                }

                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/thumb",
                    middleBanner.ImageName);

                imgResizer.Image_resize(imagePath, thumbPath, 150);
            }
            _context.MiddleBanner.Update(middleBanner);
            _context.SaveChanges();
        }

        public List<Slider> GetAllSlider()
        {
            return _context.Slider.ToList();
        }

        public LeftBanner2 GetLeftBanner2ById(int leftId)
        {
            return _context.LeftBanner2s.Find(leftId);
        }

        public RightBanner2 GetRightBanner2ById(int rightId)
        {
            return _context.RightBanner2s.Find(rightId);
        }

        public ButtomBanner GetbuttomBannerById(int ButtomId)
        {
            return _context.ButtomBanners.Find(ButtomId);
        }

        public void UpdateLeftBanner2(LeftBanner2 leftBanner, IFormFile imgCourse)
        {
            if (imgCourse != null && imgCourse.IsImage())
            {
                if (leftBanner.ImageName != "no-photo.jpg")
                {
                    string deleteImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/image", leftBanner.ImageName);
                    if (File.Exists(deleteImagePath))
                    {
                        File.Delete(deleteImagePath);
                    }
                    string deleteThumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/thumb", leftBanner.ImageName);
                    if (File.Exists(deleteThumbPath))
                    {
                        File.Delete(deleteThumbPath);
                    }
                }

                leftBanner.ImageName = NameGenerator.GenerateUniqeCode() + Path.GetExtension(imgCourse.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/image",
                    leftBanner.ImageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgCourse.CopyTo(stream);
                }

                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/thumb",
                    leftBanner.ImageName);

                imgResizer.Image_resize(imagePath, thumbPath, 150);
            }
            _context.LeftBanner2s.Update(leftBanner);
            _context.SaveChanges();
        }

        public void UpdateButtomBanner(ButtomBanner buttomBanner, IFormFile imgCourse)
        {
            if (imgCourse != null && imgCourse.IsImage())
            {
                if (buttomBanner.ImageName != "no-photo.jpg")
                {
                    string deleteImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/image", buttomBanner.ImageName);
                    if (File.Exists(deleteImagePath))
                    {
                        File.Delete(deleteImagePath);
                    }
                    string deleteThumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/thumb", buttomBanner.ImageName);
                    if (File.Exists(deleteThumbPath))
                    {
                        File.Delete(deleteThumbPath);
                    }
                }

                buttomBanner.ImageName = NameGenerator.GenerateUniqeCode() + Path.GetExtension(imgCourse.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/image",
                    buttomBanner.ImageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgCourse.CopyTo(stream);
                }

                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/thumb",
                    buttomBanner.ImageName);

                imgResizer.Image_resize(imagePath, thumbPath, 150);
            }
            _context.ButtomBanners.Update(buttomBanner);
            _context.SaveChanges();
        }

        public void UpdateRightBanner2(RightBanner2 rightBanner, IFormFile imgCourse)
        {
            if (imgCourse != null && imgCourse.IsImage())
            {
                if (rightBanner.ImageName != "no-photo.jpg")
                {
                    string deleteImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/image", rightBanner.ImageName);
                    if (File.Exists(deleteImagePath))
                    {
                        File.Delete(deleteImagePath);
                    }
                    string deleteThumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/thumb", rightBanner.ImageName);
                    if (File.Exists(deleteThumbPath))
                    {
                        File.Delete(deleteThumbPath);
                    }
                }

                rightBanner.ImageName = NameGenerator.GenerateUniqeCode() + Path.GetExtension(imgCourse.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/image",
                    rightBanner.ImageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgCourse.CopyTo(stream);
                }

                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/product/thumb",
                    rightBanner.ImageName);

                imgResizer.Image_resize(imagePath, thumbPath, 150);
            }
            _context.RightBanner2s.Update(rightBanner);
            _context.SaveChanges();
        }
    }
}
