using BusinessLogicLayer.IService;
using DataAccessLayer.IRepositories;
using DomainLayer.Models;
using DomainLayer.Models.BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        //Constructor of the UserService class
        //Require a IUserRepository object when creating the CategoryService class
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User? CreateUser(User user, out string message)
        {
            if (string.IsNullOrWhiteSpace(user.Username))
            {
                message = "Userame cannot be empty";
                return null;
            }

            if (string.IsNullOrWhiteSpace(user.Email))
            {
                message = "Email Cannot be empty";
                return null;
            }

            User result = _userRepository.CreateUser(user);
            message = "Successful";
            return result;
        }



        public bool DeleteUser(int id, out string message)
        {
            if (id <= 0)
            {
                message = "Invalid";
                return false;
            }

            User? UserData = _userRepository.GetUser(id);

            if (UserData == null)
            {
                message = "Return a Number";
                return false;
            }

            _userRepository.DeleteUser(UserData);
            message = "Deleted Successfully";
            return true;

        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public User? GetUser(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            return _userRepository.GetUser(id);
        }

        public User? GetUserByRole(string role, out string message)
        {
            if (string.IsNullOrWhiteSpace(role))
            {
                message = "Username is Required";
                return null;
            }
            // fetch role first to check if role is valid 
            User result = _userRepository.GetUserByRole(role);

            if (result == null)
            {
                message = "User role not found";
                return null;
            }

            message = "Successfully fetched users";
            return result;
        }

        public User? UpdateUser(User user, out string message)
        {
            if (user.Id <= 0)
            {
                message = "Invalid Id";
                return null;
            }

            if (string.IsNullOrWhiteSpace(user.Username))
            {
                message = "Username is Required";
                return null;
            }

            if (string.IsNullOrWhiteSpace(user.Email))
            {
                message = "Name is Required";
                return null;
            }

            User? updatedUSer = _userRepository.Update(user);

            if (updatedUSer is null)
            {
                message = "User not found";
                return null;
            }

            message = "Successfully Upated user";
            return updatedUSer;
        }
    }
}
