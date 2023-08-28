namespace eCommerceApp.Models;

public  class ProductSize
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int SizeId { get; set; }

    public DateTime Created { get; set; }

    public DateTime Updated { get; set; }

    public virtual Product Product { get; set; }

    public virtual Size Size { get; set; }
}
