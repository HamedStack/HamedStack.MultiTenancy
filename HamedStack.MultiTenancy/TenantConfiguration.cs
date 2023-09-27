namespace HamedStack.MultiTenancy;

/// <summary>
/// Represents tenant database configuration settings.
/// </summary>
public class TenantConfiguration
{
    /// <summary>
    /// Gets or sets the database provider.
    /// </summary>
    public string? DatabaseProvider { get; set; }

    /// <summary>
    /// Gets or sets the connection string used for the database.
    /// </summary>
    public string? ConnectionString { get; set; }
}