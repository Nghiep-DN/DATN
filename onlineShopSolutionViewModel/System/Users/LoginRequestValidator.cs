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
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Vui lòng nhập tài khoản.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Vui lòng nhập mật khẩu.")
                                    .MinimumLength(6).WithMessage("Mật khẩu ít nhất 6 ký tự, bao gồm cả ký tự đặc biệt chữ hoa và số.");
        }
    }
}
