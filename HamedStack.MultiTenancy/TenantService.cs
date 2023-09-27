using Microsoft.Extensions.Options;

namespace HamedStack.MultiTenancy;

/// <summary>
/// Provides methods for managing and retrieving tenant-specific details. This service is utilized in conjunction with 
/// a middleware that inspects incoming HTTP requests for a 'x-tenant-id' header to determine the tenant context.
/// </summary>
public class TenantService : ITenantService
{
    private readonly TenantSettings _tenantSettings;
    private Tenant? _currentTenant;

    /// <summary>
    /// Initializes a new instance of the <see cref="TenantService"/> class.
    /// </summary>
    /// <param name="tenantSettings">The tenant-specific settings.</param>
    public TenantService(IOptions<TenantSettings> tenantSettings)
    {
        _tenantSettings = tenantSettings.Value;
    }

    /// <summary>
    /// Sets the current tenant based on the provided tenant ID. This is typically called by middleware after extracting 
    /// the 'x-tenant-id' from the HTTP header of incoming requests.
    /// </summary>
    /// <param name="tenantId">The unique identifier of the tenant.</param>
    /// <exception cref="Exception">Thrown when the provided tenant ID does not match any known tenant or if the connection string for the tenant is missing.</exception>
    public void SetTenant(string tenantId)
    {
        _currentTenant = _tenantSettings.Tenants.FirstOrDefault(a => a.TenantId == tenantId);

        if (_currentTenant == null)
            throw new Exception("Invalid Tenant!");

        if (string.IsNullOrEmpty(_currentTenant.ConnectionString))
        {
            SetDefaultConnectionStringToCurrentTenant();
        }
    }

    /// <summary>
    /// Internal method to assign the default connection string to the current tenant, in case the tenant-specific connection string is absent.
    /// </summary>
    private void SetDefaultConnectionStringToCurrentTenant()
    {
        if (_currentTenant != null)
        {
            _currentTenant.ConnectionString = _tenantSettings.Defaults.ConnectionString;
        }
    }

    /// <summary>
    /// Retrieves the database connection string associated with the current tenant context.
    /// </summary>
    /// <returns>The database connection string of the current tenant. Returns null if no tenant context has been set.</returns>
    public string? GetConnectionString()
    {
        return _currentTenant?.ConnectionString;
    }

    /// <summary>
    /// Retrieves the default database provider set in tenant settings.
    /// </summary>
    /// <returns>The name of the database provider. If not set in tenant settings, returns null.</returns>
    public string? GetDatabaseProvider()
    {
        return _tenantSettings.Defaults?.DatabaseProvider;
    }

    /// <summary>
    /// Fetches details about the tenant that's currently set in context.
    /// </summary>
    /// <returns>An instance of the <see cref="Tenant"/> class representing the current tenant context. Returns null if no tenant context has been set.</returns>
    public Tenant? GetTenant()
    {
        return _currentTenant;
    }
}