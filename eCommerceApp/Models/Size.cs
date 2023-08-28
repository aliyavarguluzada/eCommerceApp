namespace eCommerceApp.Models;

public  class Size
{
    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Updated { get; set; }

    public virtual ICollection<ProductSize> ProductSizes { get; set; } = new List<ProductSize>();
}
