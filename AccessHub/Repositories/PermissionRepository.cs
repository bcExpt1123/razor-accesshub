using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccessHub.Models;

namespace AccessHub.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly ConcurrentDictionary<Guid, Permission> _permissions;

        public PermissionRepository()
        {
            _permissions = new ConcurrentDictionary<Guid, Permission>();
        }

        public Task<Permission?> GetByIdAsync(Guid id)
        {
            _permissions.TryGetValue(id, out var permission);
            return Task.FromResult(permission);
        }

        public Task<IEnumerable<Permission>> GetAllAsync()
        {
            return Task.FromResult(_permissions.Values.AsEnumerable());
        }

        public Task<PaginatedResult<Permission>> GetPaginatedAsync(PaginationParams paginationParams)
        {
            var query = _permissions.Values.AsEnumerable();
            var totalCount = query.Count();

            var items = query
                .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
                .Take(paginationParams.PageSize)
                .ToList();

            var result = new PaginatedResult<Permission>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = paginationParams.PageNumber,
                PageSize = paginationParams.PageSize
            };

            return Task.FromResult(result);
        }

        public Task<Permission> CreateAsync(Permission permission)
        {
            if (permission.Id == Guid.Empty)
            {
                permission.Id = Guid.NewGuid();
            }

            permission.CreatedAt = DateTime.UtcNow;
            permission.UpdatedAt = DateTime.UtcNow;

            if (!_permissions.TryAdd(permission.Id, permission))
            {
                throw new InvalidOperationException("Failed to create permission. The ID might already exist.");
            }

            return Task.FromResult(permission);
        }

        public async Task<Permission?> UpdateAsync(Permission permission)
        {
            var existingPermission = await GetByIdAsync(permission.Id);
            if (existingPermission == null)
            {
                return null;
            }

            permission.CreatedAt = existingPermission.CreatedAt;
            permission.UpdatedAt = DateTime.UtcNow;

            _permissions.TryUpdate(permission.Id, permission, existingPermission);
            return permission;
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            return Task.FromResult(_permissions.TryRemove(id, out _));
        }

        public Task<Permission?> GetByNameAsync(string name)
        {
            var permission = _permissions.Values
                .FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            return Task.FromResult(permission);
        }
    }
} 