namespace Zion.Product;

public static class ProductDbProperties
{
    public static string DbTablePrefix { get; set; } = "App_Product_";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "Product";
}
