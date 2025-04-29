using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Blogs_Of_The_U.Domain.Core.Attributes;
using The_Blogs_Of_The_U.Domain.Core.Ports;
using The_Blogs_Of_The_U.Domain.Entities;
using static System.Collections.Specialized.BitVector32;

namespace The_Blogs_Of_The_U.Domain.Services
{
    [DomainService]
    public class SectionsService
    {
        private readonly IMySqlRepositoryClient _IMySqlRepositoryClient;

        public SectionsService(IMySqlRepositoryClient mySqlRepositoryClient) {
            _IMySqlRepositoryClient= mySqlRepositoryClient;
        }

        public async Task<List<Sections>> GetAllSections() {
            List<Sections> sections=null;
            try
            {
                sections = await _IMySqlRepositoryClient.GetAllSections();
            }
            catch (Exception e) {
                throw new Exception($"Error en GetAllSections: {e.Message}");
            }

            return sections;
        }

        public async Task<bool> AddSection(Sections sections)
        {
            try
            {
                bool isInserted = await _IMySqlRepositoryClient.CreateSection(sections);
                return isInserted;
            }
            catch (Exception e)
            {
                throw new Exception($"Error al insertar el servicio: {e.Message}");
            }
        }

    }
}
