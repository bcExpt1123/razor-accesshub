using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccessHub.Models;

namespace AccessHub.Services
{
    public interface IPermissionService
    {
        Task<Permission?> GetPermissionByIdAsync(Guid id);
        Task<IEnumerable<Permission>> GetAllPermissionsAsync();
        Task<PaginatedResult<Permission>> GetPaginatedPermissionsAsync(PaginationParams paginationParams);
        Task<Permission> CreatePermissionAsync(Permission permission);
        Task<Permission?> UpdatePermissionAsync(Permission permission);
        Task<bool> DeletePermissionAsync(Guid id);
        Task<Permission?> GetPermissionByNameAsync(string name);
        Task<bool> IsPermissionNameUniqueAsync(string name, Guid? excludeId = null);
    }
} 