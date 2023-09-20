using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepoLayer.Context;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace RepoLayer.Service
{
    public class UserRepo : IUserRepo
    {
        private readonly FundooContext fundooContext;
        private readonly IConfiguration configuration;
        public UserRepo(FundooContext fundooContext, IConfiguration configuration)
        {
            this.fundooContext = fundooContext;
            this.configuration = configuration;
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

        //User Login
        public string UserLogin(UserLogModel model)
        {
            try
            {
                UserEntity user = fundooContext.users.SingleOrDefault(u => u.Email == model.Email && u.Password == EncryptPassword(model.Password));
                if(user != null)
                {
                    string JwtToken = GenerateJwtToken(user.Email, user.UserId);
                    return JwtToken;
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

        //JWT Token Generation
        public string GenerateJwtToken(string Email, long UserID)
        {
            try
            {
                var claims = new List<Claim>
                {
                    new Claim("UserID", UserID.ToString()),
                    new Claim(ClaimTypes.Email, Email)
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Secretkey"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    claims: claims,
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds
                    );
                return new JwtSecurityTokenHandler().WriteToken(token);
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
                UserEntity user = fundooContext.users.SingleOrDefault(u => u.Email == model.Email);
                if (user != null)
                {
                    string token = GenerateJwtToken(user.Email, user.UserId);
                    MsmqModel msmqModel = new MsmqModel(model.Email);
                    msmqModel.MessageSender(token);
                    return token;
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

        //Reset Password
        public bool ResetPassword(ResetModel resetModel, string email)
        {
            try
            {
                UserEntity user = fundooContext.users.SingleOrDefault(u => u.Email == email);
                if (user != null && resetModel.NewPassword == resetModel.ConfirmPassword)
                {
                    user.Password = EncryptPassword(resetModel.NewPassword);
                    fundooContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
