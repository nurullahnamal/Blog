﻿using Blog.Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.FluentValidations
{
	public class ArticleValidator:AbstractValidator<Article>
	{
		public ArticleValidator()
		{
			RuleFor(x => x.Title).NotEmpty().NotNull().MinimumLength(3).MaximumLength(123).WithName("Başlık");

			RuleFor(y=>y.Content).NotEmpty().NotNull().MinimumLength(3).MaximumLength(123).WithName("İçerik");
			
		}
	}
}
