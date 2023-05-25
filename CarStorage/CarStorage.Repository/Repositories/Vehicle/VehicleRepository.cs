using CarStorage.DAL.DataModel;
using CarStorage.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStorage.Repository
{
    public class VehicleRepository : RepositoryBase<CarStorageContext, DAL.DataModel.Vehicle>, IVehicleRepository
    {
        public VehicleRepository(CarStorageContext ctx) :  base(ctx)
        {

        }
    }
}
