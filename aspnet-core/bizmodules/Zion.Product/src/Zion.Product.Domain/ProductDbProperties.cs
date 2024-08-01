namespace Zion.Product;

public static class ProductDbProperties
{
    public static string DbTablePrefix { get; set; } = "AppProduct";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "Product";
}
