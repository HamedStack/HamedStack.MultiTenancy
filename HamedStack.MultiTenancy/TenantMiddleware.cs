using Microsoft.AspNetCore.Http;

namespace HamedStack.MultiTenancy;

/// <summary>
/// Middleware responsible for inspecting incoming HTTP requests to extract the 'x-tenant-id' header. 
/// Once extracted, it sets the tenant context using the <see cref="ITenantService"/>.
/// </summary>
public class TenantMiddleware
{
    private readonly RequestDelegate _next;

    /// <summary>
    /// Initializes a new instance of the <see cref="TenantMiddleware"/> class.
    /// </summary>
    /// <param name="next">The next middleware in the execution pipeline.</param>
    public TenantMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    /// <summary>
    /// Processes an individual HTTP request to check for the 'x-tenant-id' header and set the tenant context accordingly.
    /// </summary>
    /// <param name="context">The current HTTP context for the request being handled.</param>
    /// <param name="tenantService">The service responsible for managing tenant-specific details.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <remarks>
    /// It's expected that requests provide a 'x-tenant-id' header to identify the tenant context. If the header is present,
    /// the middleware will leverage the <see cref="ITenantService"/> to establish the tenant context for the duration of the request.
    /// </remarks>
    public async Task InvokeAsync(HttpContext context, ITenantService tenantService)
    {
        if (context.Request.Headers.TryGetValue("x-tenant-id", out var tenantId))
        {
            var tId = tenantId.FirstOrDefault();
            if (!string.IsNullOrEmpty(tId))
            {
                tenantService.SetTenant(tId);
            }
        }
        await _next(context);
    }
}