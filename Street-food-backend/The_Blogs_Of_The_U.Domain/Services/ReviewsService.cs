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
    public class ReviewsService
    {
        private readonly IMySqlRepositoryClient _IMySqlRepositoryClient;

        public ReviewsService(IMySqlRepositoryClient mySqlRepositoryClient)
        {
            _IMySqlRepositoryClient = mySqlRepositoryClient;
        }

        public async Task<List<Reviews>> GetAllReviews()
        {
            List<Reviews> reviews = null;
            try
            {
                reviews = await _IMySqlRepositoryClient.GetAllReviews();
            }
            catch (Exception e)
            {
                throw new Exception($"Error en GetAllReviews: {e.Message}");
            }

            return reviews;
        }
    }
}