﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.AccountAggregate
{
    public class CheckUserPermissionAddCommandModel
    {
      
        public string Token { get; set; } = null!;
        public string Title { get; set; } = null!;
    }
}