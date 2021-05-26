using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace onlineShopSolution.ViewModel.System.Users
{
    //validate cho LoginRequest
    public class LoginRequestValidator: AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            //tuong duong dat(Annotion) Required ben LoginRequest
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.")
                                    .MinimumLength(6).WithMessage("Password is at least 6 characters.");
        }
    }
}
