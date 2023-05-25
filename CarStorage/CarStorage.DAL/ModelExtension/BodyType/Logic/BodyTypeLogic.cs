using CarStorage.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStorage.DAL.DataModel;

public partial class BodyType 
{
    private ErrorCollection? _errors;

    public ErrorCollection Errors
    {
        get
        {
            if (_errors == null)
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
}
