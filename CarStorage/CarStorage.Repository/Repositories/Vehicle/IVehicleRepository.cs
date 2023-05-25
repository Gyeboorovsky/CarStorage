﻿using CarStorage.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStorage.Repository
{
    public interface IVehicleRepository : IRepository<DAL.DataModel.Vehicle>
    {
    }
}
