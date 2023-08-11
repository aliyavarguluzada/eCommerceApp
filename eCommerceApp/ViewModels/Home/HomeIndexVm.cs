using eCommerceApp.DTOs.BannerAds;
using eCommerceApp.DTOs.Sliders;

namespace eCommerceApp.ViewModels.Home
{
    public class HomeIndexVm
    {
        public List<SliderHomeIndexDto> Sliders { get; set; }
        public List<BannerHomeIndexDto> BannerAds { get; set; }
    }
}
