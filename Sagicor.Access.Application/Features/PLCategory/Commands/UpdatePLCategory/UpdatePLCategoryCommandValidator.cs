using FluentValidation;
using Sagicor.Access.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagicor.Access.Application.Features.PLCategory.Commands.UpdatePLCategory
{
    public class UpdatePLCategoryCommandValidator : AbstractValidator<UpdatePLCategoryCommand>
    {
        private readonly IPLCategoryRepository _pLCategoryRepository;

        public UpdatePLCategoryCommandValidator(IPLCategoryRepository pLCategoryRepository)
        {
            this._pLCategoryRepository = pLCategoryRepository;

            RuleFor(p => p.Id)
            .NotNull()
            .MustAsync(PLCategoryMustExist);

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(10).WithMessage("{PropertyName} must be fewer than 10 characters");
        }

        private async Task<bool> PLCategoryMustExist(Guid id, CancellationToken arg2)
        {
            var plCategory = await _pLCategoryRepository.GetByIdAsync(id);
            return plCategory != null;
        }
    }
}
