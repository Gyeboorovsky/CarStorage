using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace CarStorage.Repository.Infrastructure;

public interface ISimpleRepositoryBase
{
    Task<int> ExecuteProcedure(string sql, params SqlParameter[] sqlParameter);
}
