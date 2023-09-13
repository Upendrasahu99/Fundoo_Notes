using CommonLayer.Model;
using RepoLayer.Context;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepoLayer.Service
{
    public class UserRepo : IUserRepo
    {
        private readonly FundooContext fundooContext;
        public UserRepo(FundooContext fundooContext)
        {
            this.fundooContext = fundooContext;
        }

        public UserEntity UserRegister(UserRegModel model)
        {
            try
            {
                UserEntity user = fundooContext.users.SingleOrDefault(u => u.Email == model.Email);
                if (user == null)
                {
                    UserEntity newUser = new UserEntity();
                    newUser.FirstName = model.FirstName;
                    newUser.LastName = model.LastName;
                    newUser.Email = model.Email;
                    newUser.Password = EncryptPassword(model.Password);
                    fundooContext.users.Add(newUser);
                    fundooContext.SaveChanges();
                    if(newUser != null)
                    {
                        return newUser;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Password Encryption
        public string EncryptPassword(string password)
        {
            if (password != null)
            {
                byte[] storePassword = ASCIIEncoding.ASCII.GetBytes(password);
                string encyptedPassword = Convert.ToBase64String(storePassword);
                return encyptedPassword;
            }
            else
            {
                return null;
            }
        }

        //Password Decryption
        public string DecryptPassword(string Password)
        {
            if(Password != null)
            {
                byte[] encryptedPassword = Convert.FromBase64String(Password);
                string decryptedPassword = ASCIIEncoding.ASCII.GetString(encryptedPassword);
                return decryptedPassword;
            }
            else
            {
                return null;
            }
        }
    }
}
