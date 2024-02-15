using SistemaGestionData.Interfaces;
using Entities.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionData.Repositories;

namespace SistemaGestionBusiness.Services
{
    public class UserService
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public Usuario? GetUserById(int id)
        {
            return _userRepository.GetById(id); 
        }

        public IEnumerable<Usuario> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public bool AddUser(Usuario user)
        {
            try
            {

                if (_userRepository.Add(user))
                {
                    Console.WriteLine($"Adding User: {user.FullDataUser()}");
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the User:", ex);
            }
        }

        public int DeleteUser(int id)
        {
            if (id != -1)
            {
                int resultDeleteUser = _userRepository.Delete(id);
                Console.WriteLine(resultDeleteUser);
                return resultDeleteUser;
            }
            else
            {
                throw new Exception("Could not delete user");
            }
        }

        public bool UpdateUser(int id, Usuario user)
        {
            try
            {
                if (id != -1)
                {
                    if (_userRepository.Update(id, user))
                    {
                        Console.WriteLine(user.FullDataUser());
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the user:", ex);
            }
        }

    }
}
