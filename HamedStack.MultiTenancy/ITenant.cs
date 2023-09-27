// ReSharper disable UnusedMember.Global
namespace HamedStack.MultiTenancy;

/// <summary>
/// Represents an entity which can be associated with a tenant using a specific type of identifier.
/// </summary>
/// <typeparam name="TId">The type of the identifier for the tenant.</typeparam>
public interface ITenant<TId>
{
    /// <summary>
    /// Gets or sets the tenant identifier.
    /// </summary>
    /// <value>The identifier for the tenant.</value>
    TId TenantId { get; set; }
}

/// <summary>
/// Represents an entity associated with a tenant using a <see cref="Guid"/> as an identifier.
/// </summary>
public interface ITenant : ITenant<Guid>
{
}