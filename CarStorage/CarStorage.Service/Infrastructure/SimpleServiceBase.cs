using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStorage.Service.Infrastructure;

/// <summary>
/// Base class for Services
/// </summary>
public class SimpleServiceBase : ISimpleServiceBase
{
    private readonly DbContext _dbContext;

    public SimpleServiceBase(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
}
