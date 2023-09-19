using BusinessLayer.Interface;
using CommonLayer.Model;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepo userRepo;
        public UserBusiness(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
        }

        //UserRegister
        public UserEntity UserRegister(UserRegModel model)
        {
            try
            {
                return userRepo.UserRegister(model);
            }
            catch (Exception)
            {

                throw;
            };
        }

        //UserLogin
        public string UserLogin(UserLogModel model)
        {
            try
            {
                return userRepo.UserLogin(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Forgot Password
        public string ForgotPassword(ForgotPasswordModel model)
        {
            try
            {
                return userRepo.ForgotPassword(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
