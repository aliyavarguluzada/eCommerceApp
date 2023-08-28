namespace eCommerceApp.Models;

public  class ProductPhoto
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string Image { get; set; }

    public bool IsMain { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Updated { get; set; }

    public virtual Product Product { get; set; }
}
