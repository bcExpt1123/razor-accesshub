using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccessHub.Models;

namespace AccessHub.Repositories
{
    public interface IPermissionRepository
    {
        Task<Permission?> GetByIdAsync(Guid id);
        Task<IEnumerable<Permission>> GetAllAsync();
        Task<PaginatedResult<Permission>> GetPaginatedAsync(PaginationParams paginationParams);
        Task<Permission> CreateAsync(Permission permission);
        Task<Permission?> UpdateAsync(Permission permission);
        Task<bool> DeleteAsync(Guid id);
        Task<Permission?> GetByNameAsync(string name);
    }
} 