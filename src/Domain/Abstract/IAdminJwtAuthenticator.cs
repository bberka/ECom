﻿using ECom.Domain.DTOs;
using ECom.Domain.DTOs.AdminDTOs;

namespace ECom.Domain.Abstract
{
    public interface IAdminJwtAuthenticator
    {
        public ResultData<AdminLoginResponse> Authenticate(LoginRequest model);

    }
}