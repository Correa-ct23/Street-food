using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Blogs_Of_The_U.Domain.Core.Attributes;
using The_Blogs_Of_The_U.Domain.Core.Ports;
using The_Blogs_Of_The_U.Domain.Entities;

namespace The_Blogs_Of_The_U.Domain.Services
{
    [DomainService]
    public class RolesService
    {
        private readonly IMySqlRepositoryClient _IMySqlRepositoryClient;

        public RolesService(IMySqlRepositoryClient mySqlRepositoryClient)
        {
            _IMySqlRepositoryClient = mySqlRepositoryClient;
        }

        public async Task<List<Roles>> GetAllRoles()
        {
            List<Roles> roles = null;
            try
            {
                roles = await _IMySqlRepositoryClient.GetAllRoles();
            }
            catch (Exception e)
            {
                throw new Exception($"Error en GetAllRoles: {e.Message}");
            }

            return roles;
        }

        public async Task<bool> CreateRole(Roles role)
        {

            try
            {
                return await _IMySqlRepositoryClient.CreateRole(role);
            }
            catch (Exception e)
            {
                throw new Exception($"Error en GetAllRoles: {e.Message}");
            }
        }


    }
}
