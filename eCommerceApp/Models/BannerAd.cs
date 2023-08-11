namespace eCommerceApp.Models
{
    public class BannerAd
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int BannerStatusId { get; set; }

        public int CategoryId { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime? Created { get; set; }

        public DateTime? Updated { get; set; }
    }
}
