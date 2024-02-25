﻿using Gotoair.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gotoair.DataAccess.Repository.IRepository
{
    public interface IAirplaneStateRepository : IRepository<AirplaneState>
    {
        void Update(AirplaneState obj);
    }
}
