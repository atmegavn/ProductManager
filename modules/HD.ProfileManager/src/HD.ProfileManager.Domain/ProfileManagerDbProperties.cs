namespace HD.ProfileManager;

public static class ProfileManagerDbProperties
{
    public static string DbTablePrefix { get; set; } = null;

    public static string DbSchema { get; set; } = "HRM";

    public const string ConnectionStringName = "Default";
}
