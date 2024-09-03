using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.Validation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kullanıcı adını boş geçemezsiniz.");
            RuleFor(x => x.SurName).NotEmpty().WithMessage("Kullanıcı Soyadını boş geçemezsiniz.");
            RuleFor(x => x.Gmail).NotEmpty().WithMessage("Kullanıcı maili boş geçemezsiniz.");
            RuleFor(x => x.Name).MaximumLength(20).MinimumLength(2).WithMessage("Ad 3 karakter ile 20 karakter arasında olmalı!!");
            RuleFor(x => x.Password)
                .NotEmpty().MinimumLength(8).MaximumLength(20).WithMessage("Şifreniz en az 8 en fazla 20 karakter olmalıdır.")
                .Matches("[A-Z]").WithMessage("Şifreniz en az bir büyük harf içermelidir.")
                .Matches("[a-z]").WithMessage("Şifreniz en az bir küçük harf içermelidir.")
                .Matches("[0-9]").WithMessage("Şifreniz en az bir rakam içermelidir.")
                .Matches("[^a-zA-Z0-9]").WithMessage("Şifreniz en az bir özel karakter içermelidir."); 

            RuleFor(x => x.SurName).MaximumLength(30).MinimumLength(2).WithMessage("Soyadı 3 karakter ile 20 karakter arasında olmalı!!");
            RuleFor(x => x.Gmail).MaximumLength(40).MinimumLength(2).WithMessage("Gmailiniz 3 karakter ile 40 karakter arasında olmalı!!");
            RuleFor(x => x.Gmail).EmailAddress().WithMessage("Email Adresinizi giriniz.");
        }
    }
}
