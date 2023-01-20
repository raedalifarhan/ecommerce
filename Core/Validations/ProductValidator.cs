
using Core.Entities;
using FluentValidation;

namespace Core.Validations
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Name)
            .NotNull()
            .Length(5, 255)
            .Must(beValidName);
        }

        private bool beValidName(string name)
        {
            return name.All(char.IsLetter);
        }
    }
}