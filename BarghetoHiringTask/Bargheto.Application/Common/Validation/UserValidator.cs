using Bargheto.Application.DataTransferObjects.UserManagement;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bargheto.Application.Common.Validation
{
    public class UserValidator : AbstractValidator<UserInputDto>
    {
        public UserValidator()
        {
            RuleFor(u => u.FullName).NotEmpty().WithMessage("FullName can not be empty")
                .MaximumLength(90).WithMessage("The legth of the FullName can not exceed 90 characters");

            RuleFor(u => u.Password).Equal(u => u.ConfirmPassword).WithMessage("The both Password and Confirm Password must be equal");
        }
    }
}
