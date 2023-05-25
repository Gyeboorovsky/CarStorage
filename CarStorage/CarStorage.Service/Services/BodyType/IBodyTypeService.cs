using CarStorage.DAL.DataModel;
using CarStorage.Service.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStorage.Service;

public interface IBodyTypeService : IServiceBase<BodyType>
{
    Task<BodyType> AddBodyType(BodyType entity);
}
