using FluentValidation;
using Sagicor.Access.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagicor.Access.Application.Features.PLCategory.Commands.CreatePLCategory
{
    public class CreatePLCategoryCommandValidator : AbstractValidator<CreatePLCategoryCommand>
    {
        private readonly IPLCategoryRepository _pLCategoryRepository;

        public CreatePLCategoryCommandValidator(IPLCategoryRepository pLCategoryRepository)
        {
            this._pLCategoryRepository = pLCategoryRepository;

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(10).WithMessage("{PropertyName} must be fewer than 10 characters");

            RuleFor(q => q)
                .MustAsync(PLCategoryDescriptionUnique)
                .WithMessage("PL Category description already exists");
        }

        private Task<bool> PLCategoryDescriptionUnique(CreatePLCategoryCommand command, CancellationToken token)
        {
            return _pLCategoryRepository.IsPLCategoryDescriptionUnique(command.Description);
        }
    }
}
