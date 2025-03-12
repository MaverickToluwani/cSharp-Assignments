using BusinessLogicLayer.IService;
using DataAccessLayer.IRepositories;
using DataAccessLayer.UnitOfWorkFolder;
using DomainLayer.Models;
using DomainLayer.Models.BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class UserService : IUserService
    {
        //private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        //Constructor of the UserService class
        //Require a IUserRepository object when creating the CategoryService class
        public UserService(IUnitOfWork unitOfWork)
        {
            //_userRepository = userRepository;
            _unitOfWork = unitOfWork;
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

            //User result = _userRepository.CreateUser(user);
            User result = _unitOfWork.userRepository.CreateUser(user);
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

            User? UserData = _unitOfWork.userRepository.GetUser(id);

            if (UserData == null)
            {
                message = "Return a Number";
                return false;
            }

            _unitOfWork.userRepository.DeleteUser(UserData);

            message = "Deleted Successfully";
            return true;

        }

        public List<User> GetAllUsers()
        {
            return _unitOfWork.userRepository.GetAllUsers();
        }

        public User? GetUser(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            return _unitOfWork.userRepository.GetUser(id);
        }

        public User? GetUserByRole(string role, out string message)
        {
            if (string.IsNullOrWhiteSpace(role))
            {
                message = "Username is Required";
                return null;
            }
            // fetch role first to check if role is valid 
            User? result = _unitOfWork.userRepository.GetUserByRole(role);

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

            User? updatedUSer = _unitOfWork.userRepository.Update(user);

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
