namespace HamedStack.MultiTenancy;

/// <summary>
/// Represents settings related to tenants.
/// </summary>
public class TenantSettings
{
    /// <summary>
    /// Gets or sets the default configuration.
    /// </summary>
    public TenantConfiguration Defaults { get; set; } = null!;

    /// <summary>
    /// Gets or sets the list of tenants.
    /// </summary>
    public List<Tenant> Tenants { get; set; } = null!;
}