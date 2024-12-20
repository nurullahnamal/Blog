﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Extensions
{
	public static class FluentValidationExtensions
	{
		public static void AddToModelState(this ValidationResult result)
		{
			foreach (var error in result.ErrorMessage)
			{
				error.ToString();
			}
		}
		public static void AddToIdentityModelState(this IdentityResult result, ModelStateDictionary modelState)
		{
			foreach (var error in result.Errors)
			{
				modelState.AddModelError("", error.Description);
			}
		}



	}
}
