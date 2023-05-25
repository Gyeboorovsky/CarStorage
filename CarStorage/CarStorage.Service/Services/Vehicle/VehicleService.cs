using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStorage.Common.Extensions;
using CarStorage.DAL.DataModel;
using CarStorage.DAL.ModelExtension.Vehicle;
using CarStorage.Repository;
using CarStorage.Service.Infrastructure;
using CarStorage.Service.Validation;
using FluentValidation;

namespace CarStorage.Service;

public class VehicleService : ServiceBase<Vehicle, IVehicleRepository>, IVehicleService
{
    protected VehicleValidator? _validator;
    protected IBodyTypeService _bodyTypeService;

    public VehicleService(
        CarStorageContext ctx,
        IBodyTypeService bodyTypeService,
        IVehicleRepository repository)
        : base(ctx, repository)
    {
        _bodyTypeService = bodyTypeService;
    }

    public async Task<Vehicle> AddVehicle(Vehicle entity)
    {
        _validator = new VehicleValidator(_bodyTypeService);
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
