using FluentValidation;
using HomeCinema.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeCinema.Web.Infrastructure.Validators
{
    public class ArticleViewModelValidator : AbstractValidator<ArticleViewModel>
    {
        public ArticleViewModelValidator()
        {
            RuleFor(article => article.MainArticleID).GreaterThan(0)
                .WithMessage("انتخاب یک گروه کالا");
            RuleFor(article => article.Code).NotEmpty().Length(1, 100)
                .WithMessage("انتخاب یک کد کالا");
            RuleFor(article => article.Name).NotEmpty().Length(1, 500);
        }
    }
}