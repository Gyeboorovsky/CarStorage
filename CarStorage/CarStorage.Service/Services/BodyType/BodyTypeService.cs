using CarStorage.Common.Extensions;
using CarStorage.DAL.DataModel;
using CarStorage.DAL.ModelExtension.BodyType;
using CarStorage.Repository;
using CarStorage.Service.Infrastructure;
using CarStorage.Service.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStorage.Service;

public class BodyTypeService : ServiceBase<BodyType, IBodyTypeRepository>, IBodyTypeService
{
    protected BodyTypeValidator? _validator;
    public BodyTypeService(
        CarStorageContext ctx,
        IBodyTypeRepository repository)
        : base(ctx, repository)
    {

    }

    public async Task<BodyType> AddBodyType(BodyType entity)
    {
        _validator = new BodyTypeValidator(this);
        var validationResult = await _validator.ValidateAsync(entity, options => { options.IncludeRuleSets("PostVehicle"); });

        if (validationResult.IsValid)
        {
            await _repository.AddAsync(entity);
        }
        else
        {
            entity.Errors.CopyValidationResultToErrors(validationResult);
        }
        return entity;
    }
}
