// ReSharper disable ClassNeverInstantiated.Global

namespace HamedStack.MultiTenancy;

/// <summary>
/// Represents information about a tenant.
/// </summary>
public class Tenant
{
    /// <summary>
    /// Gets or sets the name of the tenant.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the Tenant ID.
    /// </summary>
    public string? TenantId { get; set; }

    /// <summary>
    /// Gets or sets the connection string associated with the tenant.
    /// </summary>
    public string? ConnectionString { get; set; }
}