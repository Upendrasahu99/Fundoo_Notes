﻿using CommonLayer.Model;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface IUserRepo
    {
        public UserEntity UserRegister(UserRegModel model);
        public string UserLogin(UserLogModel model);
        public string ForgotPassword(ForgotPasswordModel model);
        public bool ResetPassword(ResetModel resetModel, string email);
    }
}
