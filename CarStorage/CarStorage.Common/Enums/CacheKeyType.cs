using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStorage.Common.Enums;

public enum CacheKeyType
{
    AllVehicles = 1
}

public static class CacheKeyTypeExtensions
{
    public static string AsString(this CacheKeyType cacheKeyType)
    {
        return cacheKeyType switch
        {
            CacheKeyType.AllVehicles => "All vehicles",
            _ => string.Empty
        };
    }
}
