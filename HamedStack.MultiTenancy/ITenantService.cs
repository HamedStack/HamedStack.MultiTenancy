// ReSharper disable UnusedMember.Global
namespace HamedStack.MultiTenancy;

/// <summary>
/// Provides methods for interacting with tenant-related services.
/// </summary>
public interface ITenantService
{
    /// <summary>
    /// Retrieves the database provider associated with the tenant.
    /// </summary>
    /// <returns>The name of the database provider.</returns>
    string? GetDatabaseProvider();

    /// <summary>
    /// Retrieves the connection string associated with the tenant.
    /// </summary>
    /// <returns>The connection string.</returns>
    string? GetConnectionString();

    /// <summary>
    /// Retrieves information about the tenant.
    /// </summary>
    /// <returns>An instance of the <see cref="Tenant"/> class representing the tenant.</returns>
    Tenant? GetTenant();

    /// <summary>
    /// Sets the tenant context for the current request or operation based on the provided tenant ID. 
    /// </summary>
    /// <param name="tenantId">The unique identifier of the tenant to be set in context.</param>
    void SetTenant(string tenantId);

}