using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStorage.Repository.Infrastructure;

public abstract class SimpleRepositoryBase<TContext> : ISimpleRepositoryBase where TContext : DbContext
{
    protected readonly TContext _context;
    public SimpleRepositoryBase(TContext context)
    {
        this._context = context;
    }

    public Task<int> ExecuteProcedure(string sql, params SqlParameter[] sqlParameter)
    {
        throw new NotImplementedException();
    }
}
