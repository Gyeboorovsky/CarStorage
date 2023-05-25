using CarStorage.DAL.DataModel;
using CarStorage.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStorage.Repository
{
    public class BodyTypeRepository : RepositoryBase<CarStorageContext, DAL.DataModel.BodyType>, IBodyTypeRepository
    {
        public BodyTypeRepository(CarStorageContext ctx) : base(ctx)
        {

        }
    }
}
