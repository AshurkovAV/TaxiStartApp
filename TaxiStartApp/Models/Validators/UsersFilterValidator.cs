using FluentValidation;
using TaxiStartApp.Models.User;

namespace TaxiStartApp.Models.Validators
{
    public class UsersFilterValidator : AbstractValidator<UsersFilterModel>
    {
        public UsersFilterValidator()
        {
            RuleFor(x => x.FilterName).NotEmpty().WithMessage("Поле 'Название фильтра' обязательно для заполнения");
            

        }
    }
}
