using AutoMapper;
using System.Transactions;
using The_Blogs_Of_The_U.Domain.Core.Attributes;
using The_Blogs_Of_The_U.Domain.Core.Ports;
using The_Blogs_Of_The_U.Domain.Entities;
using The_Blogs_Of_The_U.Domain.Enums;
using static The_Blogs_Of_The_U.Domain.Models.UserResponse;

namespace The_Blogs_Of_The_U.Domain.Services
{
    [DomainService]
    public class UserService
    {
        private readonly IMySqlRepositoryClient _IMySqlRepositoryClient;
        private readonly IMapper _mapper;
        private int RETRYCOUNT=3;

        public UserService(IMySqlRepositoryClient mySqlRepositoryClient, IMapper mapper)
        {
            _IMySqlRepositoryClient = mySqlRepositoryClient;
            _mapper = mapper;
        }

        public async Task<ResponseLogin> UserAccessValidation(UserAcces userAcces)
        {
            ResponseLogin responseLogin = null;

            if (userAcces == null || userAcces.Password.Length == 0 || userAcces.Password.Length == 0)
                throw new ArgumentNullException(nameof(userAcces));

            Users user = await _IMySqlRepositoryClient.ValidateUserAccess(userAcces);


            if (user != null)
            {

                responseLogin = new ResponseLogin
                {
                    User = user,
                    UserAcces = userAcces
                };
            }
            return responseLogin ?? new ResponseLogin();
        }

        public async Task<bool> PasswordRecovery(string email, string password)
        {
            if (email == null || email.Length == 0)
                throw new ArgumentNullException(nameof(email));

            UserAcces user = await _IMySqlRepositoryClient.GetUserAcces(email);
            if (user == null)
            {
                return false;
            }

            bool changes = await _IMySqlRepositoryClient.SetPassword(email, password);

            return changes;
        }


        public static string GeneratePassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }



        public async Task<Roles> GetuserRole(string userEmail)
        {
            Roles roles = null;
            try
            {
                roles = await _IMySqlRepositoryClient.GetRolUser(userEmail);
            }
            catch (Exception e)
            {
                throw new Exception($"Error en UserRolService: {e.Message}");
            }

            return roles;
        }


        public async Task<List<Users>> GetAllUsers()
        {
            try
            {
                List<Users> users = await _IMySqlRepositoryClient.GetAllUsers();
                return users;   
            }
            catch (Exception e)
            {
                throw new Exception($"Error en UserRolService: {e.Message}");
            }
        }
    }
}
