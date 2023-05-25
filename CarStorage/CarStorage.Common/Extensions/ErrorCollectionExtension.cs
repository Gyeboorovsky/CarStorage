using CarStorage.Common.Model;
using System;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStorage.Common.Extensions;

public static class ErrorCollectionExtension
{
    public static void CopyValidationResultToErrors(this ErrorCollection entityErrors, ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
        {
            entityErrors.Add(error.ErrorMessage, error.PropertyName);
        }
    }
}
