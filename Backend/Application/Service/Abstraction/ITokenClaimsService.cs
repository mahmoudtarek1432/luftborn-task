﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Abstraction
{
    public interface ITokenClaimsService
    {
        string GetTokenAsync(AuthenticationInfo authenticationInfo);
    }
}
