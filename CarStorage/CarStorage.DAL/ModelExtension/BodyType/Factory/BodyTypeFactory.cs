using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStorage.DAL.ModelExtension.BodyType.Factory;

public static class BodyTypeFactory
{
    public static DataModel.BodyType Create()
    {
        return new DataModel.BodyType();
    }
}
