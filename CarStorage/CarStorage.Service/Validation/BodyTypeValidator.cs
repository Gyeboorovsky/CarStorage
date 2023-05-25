using CarStorage.DAL.DataModel;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CarStorage.Service.Validation;

public class BodyTypeValidator : AbstractValidator<BodyType>
{
    protected IBodyTypeService _bodyTypeService;
    public BodyTypeValidator(IBodyTypeService bodyTypeService)
    {
        _bodyTypeService = bodyTypeService;

        RuleSet("PostBodyType", () => {
            RuleFor(x => x.Name).NotNull().WithMessage("Field cannot be empty");
            RuleFor(x => x.Name).MustAsync(IsInDictionaryAlready).WithMessage("Field cannot be empty");
            RuleFor(x => x.Desription).NotNull().WithMessage("Field cannot be empty");
        });
    }
    private async Task<bool> IsInDictionaryAlready(string name, CancellationToken cancellation)
    {
        var bodyTypesDictionary = await _bodyTypeService.GetAllAsync();
        var isInDictionary = bodyTypesDictionary.Select(x => x.Name).Contains(name);
        return isInDictionary;
    }
}
