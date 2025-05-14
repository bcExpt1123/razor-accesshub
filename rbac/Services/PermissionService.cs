using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccessHub.Models;
using AccessHub.Repositories;

namespace AccessHub.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionService(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository ?? throw new ArgumentNullException(nameof(permissionRepository));
        }

        public async Task<Permission?> GetPermissionByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Permission ID cannot be empty.", nameof(id));
            }

            return await _permissionRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Permission>> GetAllPermissionsAsync()
        {
            return await _permissionRepository.GetAllAsync();
        }

        public async Task<PaginatedResult<Permission>> GetPaginatedPermissionsAsync(PaginationParams paginationParams)
        {
            if (paginationParams == null)
            {
                throw new ArgumentNullException(nameof(paginationParams));
            }

            return await _permissionRepository.GetPaginatedAsync(paginationParams);
        }

        public async Task<Permission> CreatePermissionAsync(Permission permission)
        {
            if (permission == null)
            {
                throw new ArgumentNullException(nameof(permission));
            }

            if (string.IsNullOrWhiteSpace(permission.Name))
            {
                throw new ArgumentException("Permission name cannot be empty.", nameof(permission));
            }

            // Check if permission name is unique
            if (!await IsPermissionNameUniqueAsync(permission.Name))
            {
                throw new InvalidOperationException($"Permission with name '{permission.Name}' already exists.");
            }

            // Ensure a new ID is generated
            permission.Id = Guid.NewGuid();
            
            return await _permissionRepository.CreateAsync(permission);
        }

        public async Task<Permission?> UpdatePermissionAsync(Permission permission)
        {
            if (permission == null)
            {
                throw new ArgumentNullException(nameof(permission));
            }

            if (string.IsNullOrWhiteSpace(permission.Name))
            {
                throw new ArgumentException("Permission name cannot be empty.", nameof(permission));
            }

            // Check if permission exists
            var existingPermission = await _permissionRepository.GetByIdAsync(permission.Id);
            if (existingPermission == null)
            {
                return null;
            }

            // Check if the new name is unique (excluding the current permission)
            if (!await IsPermissionNameUniqueAsync(permission.Name, permission.Id))
            {
                throw new InvalidOperationException($"Permission with name '{permission.Name}' already exists.");
            }

            return await _permissionRepository.UpdateAsync(permission);
        }

        public async Task<bool> DeletePermissionAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Permission ID cannot be empty.", nameof(id));
            }

            return await _permissionRepository.DeleteAsync(id);
        }

        public async Task<Permission?> GetPermissionByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Permission name cannot be empty.", nameof(name));
            }

            return await _permissionRepository.GetByNameAsync(name);
        }

        public async Task<bool> IsPermissionNameUniqueAsync(string name, Guid? excludeId = null)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Permission name cannot be empty.", nameof(name));
            }

            var existingPermission = await _permissionRepository.GetByNameAsync(name);
            
            if (existingPermission == null)
            {
                return true;
            }

            // If we're updating an existing permission, check if the found permission is the same one
            if (excludeId.HasValue && existingPermission.Id == excludeId.Value)
            {
                return true;
            }

            return false;
        }
    }
} 