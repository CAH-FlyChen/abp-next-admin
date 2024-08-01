namespace Zion.System;

public static class SystemDbProperties
{
    public static string DbTablePrefix { get; set; } = "AppSystem";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "System";
}
