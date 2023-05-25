using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStorage.DAL.ModelExtension.Vehicle.Factory;

public static class VehicleFactory
{
    public static DataModel.Vehicle Create()
    {
        return new DataModel.Vehicle();
    }
}
