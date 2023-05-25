using CarStorage.DAL.DataModel;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CarStorage.Service.Validation;

public class VehicleValidator : AbstractValidator<Vehicle>
{
    protected IBodyTypeService _bodyTypeService;
    public VehicleValidator(IBodyTypeService bodyTypeService)
    {
        _bodyTypeService = bodyTypeService;

        RuleSet("PostVehicle", () => {
            RuleFor(x => x.ProductionYear).NotNull().WithMessage("Field cannot be empty");
            RuleFor(x => x.Model).NotEmpty().WithMessage("Field cannot be empty");
            RuleFor(x => x.RegistrationNumber).NotEmpty().WithMessage("Field cannot be empty");
            RuleFor(x => x.Brand).NotEmpty().WithMessage("Field cannot be empty");
            RuleFor(x => x.VIN).NotEmpty().WithMessage("Field cannot be empty");
            RuleFor(x => x.BodyTypeId).NotNull().WithMessage("Field cannot be empty");
            RuleFor(x => x.BodyTypeId).MustAsync(IsInDictionary).WithMessage("Field must be a BodyType dictionary value");
        });
    }

    private async Task<bool> IsInDictionary (int id, CancellationToken cancellation)
    {
        var bodyTypesDictionary = await _bodyTypeService.GetAllAsync();
        var isInDictionary = bodyTypesDictionary.Select(x => x.Id).Contains(id);
        return isInDictionary;
    }
}
