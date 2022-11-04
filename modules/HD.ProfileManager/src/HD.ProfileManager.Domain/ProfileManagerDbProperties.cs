namespace HD.ProfileManager;

public static class ProfileManagerDbProperties
{
    public static string DbTablePrefix { get; set; } = "ProfileManager";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "ProfileManager";
}
