using AutoMapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using The_Blogs_Of_The_U.Domain.Core.Ports;
using The_Blogs_Of_The_U.Domain.Entities;
using The_Blogs_Of_The_U.Domain.Services;
using The_Blogs_Of_The_U.Infrastructure.Dtos;
using The_Blogs_Of_The_U.Infrastructure.MySqlDb.Helpers;
using The_Blogs_Of_The_U.Infrastructure.MySqlDb.Settings;
using static System.Collections.Specialized.BitVector32;


namespace The_Blogs_Of_The_U.Infrastructure.MySqlDb.Repository
{
    public class MySqlRepositoryClient : IMySqlRepositoryClient
    {
        private readonly IOptions<MySqlSettings> _configuration;
        private readonly DapperHelper _dapper;
        private readonly IMapper _mapper;
        public MySqlRepositoryClient(IOptions<MySqlSettings> configuration, IMapper mapper)
        {
            _configuration = configuration;
            _dapper = new DapperHelper(_configuration);
            _mapper = mapper;
        }

        public async Task<UserAcces> GetUserAcces(string email)
        {
            string qry = $"SELECT * FROM user_access WHERE EMAIL='{email}' limit 1";
            var userResult = await _dapper.QueryAsync<UserAcces>(qry);
            if (userResult == null || userResult.Count <= 0) return new UserAcces();

            return userResult.FirstOrDefault();
        }

        public async Task<UserAcces> GetUserAccesById(int id)
        {
            string qry = $"SELECT * FROM user_access WHERE ID='{id}'";
            var userResult = await _dapper.QueryAsync<UserAcces>(qry);
            if (userResult == null || userResult.Count <= 0) return new UserAcces();

            return userResult.FirstOrDefault();
        }


        public async Task<Users> ValidateUserAccess(UserAcces userAcces)
        {
            string qry = $"SELECT u.*  FROM users u JOIN user_access ua ON u.USER_ACCESS_ID=ua.ID WHERE EMAIL='{userAcces.Email}' AND PASSWORD='{userAcces.Password}'";
            var userResult = await _dapper.QueryAsync<UserDto>(qry);

            if (userResult == null || userResult.Count<=0) return null; 

            Users users = _mapper.Map<Users>(userResult.FirstOrDefault());
            users.Role = await GetRolUser(userAcces.Email);
            return users;
        }

        public async Task<List<Users>> GetMyClients(string providerId)
        {
            string qry = $"SELECT u.ID,u.USERNAME, ua.EMAIL, u.DOCUMENT  FROM users u JOIN user_access ua ON u.USER_ACCESS_ID=ua.ID JOIN Bookings b ON b.user_id=u.ID JOIN  Services s ON s.service_id=b.service_id JOIN Providers p ON p.provider_id=s.provider_id WHERE p.provider_id = '{providerId}'";
            var userResult = await _dapper.QueryAsync<UserDto>(qry);

            if (userResult == null || userResult.Count <= 0) return null;

            List<Users> users = _mapper.Map<List<Users>>(userResult.ToList());

            List<Task> tasks = new List<Task>();

            foreach (var item in users)
            {
                tasks.Add(Task.Run(async () =>
                {
                    item.Access = await GetUserAccesById(int.Parse(item.Id));
                }));
            }

            await Task.WhenAll(tasks);

            return users;
        }



        public async Task<int> CreateUserAccess(UserAcces userAcces)
        {
            string qry = @"INSERT INTO user_access (EMAIL, PASSWORD) 
                   VALUES (@EMAIL, @PASSWORD);";
            var parameters = new
            {
                EMAIL = userAcces.Email,
                PASSWORD = userAcces.Password,
            };

            var result = await _dapper.ExecuteAsync(qry, parameters);

            string selectQry = "SELECT LAST_INSERT_ID();";

            IReadOnlyList<int> lastInsertId = await _dapper.QueryAsync<int>(selectQry);

            return lastInsertId.FirstOrDefault();
        }

        public async Task<int> CreateUsers(Users users)
        {
            string qry = @"INSERT INTO users (USERNAME, DOCUMENT, STATUS, ROLE_ID, USER_ACCESS_ID)
                   VALUES (@USERNAME, @DOCUMENT, @STATUS, @ROLE_ID, @USER_ACCESS_ID)";
            var parameters = new
            {
                USERNAME = users.UserName,
                DOCUMENT = users.Document,
                STATUS = 1,
                ROLE_ID = users.RolId,
                USER_ACCESS_ID = users.UserAccesId
            };

            var result = await _dapper.ExecuteAsync(qry, parameters);

            string selectQry = "SELECT LAST_INSERT_ID();";

            IReadOnlyList<int> lastInsertId = await _dapper.QueryAsync<int>(selectQry);

            return lastInsertId.FirstOrDefault();
        }


        public async Task<List<Sections>> GetAllSections()
        {
            string qry = $"SELECT * FROM Sections";
            var sectionResult = await _dapper.QueryAsync<SectionsDto>(qry);

            if (sectionResult == null || !sectionResult.Any()) return null;

            return _mapper.Map<List<Sections>>(sectionResult);
        }

        public async Task<List<Roles>> GetAllRoles()
        {
            string qry = $"SELECT * FROM roles";
            var RolesResult = await _dapper.QueryAsync<RolesDto>(qry);

            if (RolesResult == null || !RolesResult.Any()) return null;

            return _mapper.Map<List<Roles>>(RolesResult);
        }

        public async Task<Roles> GetRolUser(string userEmail)
        {
            string qry = $"SELECT USERNAME, ua.EMAIL, r.ROLE_NAME, r.ID FROM users u JOIN roles r on u.ROLE_ID = r.ID JOIN user_access ua on u.USER_ACCESS_ID = ua.ID WHERE ua.EMAIL='{userEmail}'";
            var rolresult = await _dapper.QueryAsync<RolesDto>(qry);

            if (rolresult == null || !rolresult.Any()) return null;

            return _mapper.Map<Roles>(rolresult.FirstOrDefault());
        }

        public async Task<Roles> GetRolUserById(int id)
        {
            string qry = $"SELECT * FROM roles WHERE ID= '{id}'";
            var rolresult = await _dapper.QueryAsync<RolesDto>(qry);

            if (rolresult == null || !rolresult.Any()) return null;

            return _mapper.Map<Roles>(rolresult.FirstOrDefault());
        }


        public async Task<List<Users>> GetAllUsers() {
            string qry = "SELECT * FROM users";
            var result = await _dapper.QueryAsync<UserDto>(qry);

            if (result == null || !result.Any()) return null;

            List<Users> users = _mapper.Map<List<Users>>(result.ToList());
            List<Task> tasks = new List<Task>();

            foreach (var item in users)
            {
                tasks.Add(Task.Run(async () =>
                {
                    item.Access = await GetUserAccesById(item.UserAccesId);
                    item.Role = await GetRolUserById(item.RolId);
                }));
            }

            await Task.WhenAll(tasks);

            return users;

        }

        public async Task<bool> CreateRole(Roles role)
        {
            string qry = @"INSERT INTO roles (ROLE_NAME, DESCRIPTION)
                   VALUES (@ROLE_NAME , @DESCRIPTION)";
            var parameters = new
            {
                ROLE_NAME = role.RoleName,
                DESCRIPTION = role.Description
            };

            var result = await _dapper.ExecuteAsync(qry, parameters);
            return result > 0;
        }


        public async Task<bool> CreateSection (Sections sections)
        {
            string qry = @"INSERT INTO Sections (section_name, description)
                   VALUES (@section_name , @description)";
            var parameters = new
            {
                section_name = sections.SectionName,
                description= sections.Description
            };

            var result = await _dapper.ExecuteAsync(qry, parameters);
            return result > 0;
        }


        public async Task<bool> SetPassword(string email, string password)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("El correo electrónico y la contraseña no pueden estar vacíos.");
            }

            string qry = "UPDATE user_access SET password = @Password WHERE email = @Email";
            var parameters = new { Email = email, Password = password };

            int rowsAffected = await _dapper.ExecuteAsync(qry, parameters);

            return rowsAffected > 0;
        }


        public async Task<List<Reviews>> GetAllReviews()
        {
            string qry = $"select USERNAME, review_text, rating, review_date, service_name, provider_name from Reviews  join users on Reviews.user_id = users.ID join Services on Reviews.service_id = Services.service_id join Providers on Services.provider_id = Providers.provider_id";
            var reviewsresult = await _dapper.QueryAsync<ReviewsDto>(qry);
            Console.WriteLine($"reviewsresult Count: {reviewsresult?.Count}");

            if (reviewsresult == null || !reviewsresult.Any()) return null;

            return _mapper.Map<List<Reviews>>(reviewsresult);
        }


        public async Task<Sections> GetSectionById(string id)
        {
            string qry = $"SELECT * FROM Sections WHERE section_id= '{id}'";
            var sectionresult = await _dapper.QueryAsync<SectionsDto>(qry);

            if (sectionresult == null || !sectionresult.Any()) return null;

            return _mapper.Map<Sections>(sectionresult.FirstOrDefault());
        }

   

        public async Task<string> getParameters(string name) {
            string qry = $"SELECT value FROM parameters where name= '{name}'";
            var parametersResult = await _dapper.QueryAsync<string>(qry);
            if (parametersResult != null) return parametersResult.FirstOrDefault();

            return null;


        }


    }
}
