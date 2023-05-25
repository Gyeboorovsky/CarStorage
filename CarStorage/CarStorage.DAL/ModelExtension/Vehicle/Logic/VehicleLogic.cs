using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStorage.Common;
using CarStorage.Common.Model;
using FluentValidation.Results;

namespace CarStorage.DAL.DataModel;

public partial class Vehicle : IEntity
{
    private ErrorCollection? _errors;

    public ErrorCollection Errors
    {
        get
        {
            if(_errors == null)
            {
                _errors = new ErrorCollection();
            }
            return _errors;
        }
    }

    public bool IsValid
    {
        get
        {
            return !Errors.Any();
        }
    }

    public bool IsSedan()
    {
        return this.BodyTypeId == (int)Common.BodyType.Sedan;
    }
}
