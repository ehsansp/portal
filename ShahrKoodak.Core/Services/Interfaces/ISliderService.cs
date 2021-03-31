using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using ShahrKoodak.Core.DTOs.Banner;
using ShahrKoodak.DataLayer.Entities.Slider;

namespace ShahrKoodak.Core.Services.Interfaces
{
    public interface ISliderService
    {
        List<ShowSliderForAdminViewModel> GetSlidersForAdmin();
        int AddSlider(Slider slider, IFormFile imgCourse);
        Slider GetSliderById(int sliderId);
        LeftBanner GetLeftBannerById(int leftId);
        LeftBanner2 GetLeftBanner2ById(int leftId);
        RightBanner GetRightBannerById(int rightId);
        RightBanner2 GetRightBanner2ById(int rightId);
        ButtomBanner GetbuttomBannerById(int ButtomId);
        MiddleBanner GetMiddleBannerById(int middleId);
        void UpdateSlider(Slider slider, IFormFile imgCourse);
        void UpdateLeftBanner(LeftBanner leftBanner, IFormFile imgCourse);
        void UpdateLeftBanner2(LeftBanner2 leftBanner, IFormFile imgCourse);
        void UpdateMiddleBanner(MiddleBanner middleBanner, IFormFile imgCourse);
        void UpdateButtomBanner(ButtomBanner buttomBanner, IFormFile imgCourse);
        void UpdateRightBanner(RightBanner rightBanner, IFormFile imgCourse);
        void UpdateRightBanner2(RightBanner2 rightBanner, IFormFile imgCourse);
        List<Slider> GetAllSlider();


    }
}
