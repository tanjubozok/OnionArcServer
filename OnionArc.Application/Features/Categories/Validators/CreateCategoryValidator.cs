﻿using FluentValidation;
using OnionArc.Application.Features.Categories.Commands;

namespace OnionArc.Application.Features.Categories.Validators;

public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Category name is required.")
            .MinimumLength(3).WithMessage("Category name must be at least 3 characters long.")
            .MaximumLength(100).WithMessage("Category name must not exceed 100 characters.");
    }
}