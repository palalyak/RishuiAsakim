﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public interface ITokenValidationService
    {
        Task ValidateTokenAsync(string token);
    }
}
