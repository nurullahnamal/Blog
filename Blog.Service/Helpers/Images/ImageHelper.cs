﻿using Blog.Entity.DTOs.Images;
using Blog.Entity.Enum;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Helpers.Images
{
	public class ImageHelper : IImageHelper
	{
		private readonly IWebHostEnvironment webHostEnvironment;
		private readonly string wwwRoot;
		private const string imgFolder = "images";
		private const string articleImagesFolder = "article-images";
		private const string userImagesFolder = "user-images";

		public ImageHelper(IWebHostEnvironment webHostEnvironment)
		{
			this.webHostEnvironment = webHostEnvironment;
			wwwRoot = webHostEnvironment.WebRootPath;
		}

		private string ReplaceInvalidChars(string fileName)
		{
			return fileName.Replace("İ", "I")
				 .Replace("ı", "i")
				 .Replace("Ğ", "G")
				 .Replace("ğ", "g")
				 .Replace("Ü", "U")
				 .Replace("ü", "u")
				 .Replace("ş", "s")
				 .Replace("Ş", "S")
				 .Replace("Ö", "O")
				 .Replace("ö", "o")
				 .Replace("Ç", "C")
				 .Replace("ç", "c")
				 .Replace("é", "")
				 .Replace("!", "")
				 .Replace("'", "")
				 .Replace("^", "")
				 .Replace("+", "")
				 .Replace("%", "")
				 .Replace("/", "")
				 .Replace("(", "")
				 .Replace(")", "")
				 .Replace("=", "")
				 .Replace("?", "")
				 .Replace("_", "")
				 .Replace("*", "")
				 .Replace("æ", "")
				 .Replace("ß", "")
				 .Replace("@", "")
				 .Replace("€", "")
				 .Replace("<", "")
				 .Replace(">", "")
				 .Replace("#", "")
				 .Replace("$", "")
				 .Replace("½", "")
				 .Replace("{", "")
				 .Replace("[", "")
				 .Replace("]", "")
				 .Replace("}", "")
				 .Replace(@"\", "")
				 .Replace("|", "")
				 .Replace("~", "")
				 .Replace("¨", "")
				 .Replace(",", "")
				 .Replace(";", "")
				 .Replace("`", "")
				 .Replace(".", "")
				 .Replace(":", "")
				 .Replace(" ", "");
		}

		public void Delete(string imageName)
		{
			var fileToDelete=Path.Combine($"{wwwRoot}/{imgFolder}/{imageName}");
			if (File.Exists(fileToDelete)) 
				File.Delete(fileToDelete);

		
		}

		public async Task<ImageUploadedDto> Upload(string name, IFormFile imageFile, ImageType imageType, string folderName = null)
		{
			if (imageFile == null)
				throw new ArgumentNullException(nameof(imageFile), "Yüklemek için geçerli bir dosya seçilmedi.");

			folderName ??= imageType == ImageType.User ? userImagesFolder : articleImagesFolder;
			if (!Directory.Exists($"{wwwRoot}/{imgFolder}/{folderName}"))
				Directory.CreateDirectory($"{wwwRoot}/{imgFolder}/{folderName}");

			string oldFileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
			string fileExtension = Path.GetExtension(imageFile.FileName);

			name = ReplaceInvalidChars(name);

			DateTime dateTime = DateTime.Now;
			string newFileName = $"{name}_{dateTime.Microsecond}{fileExtension}";
			var path = Path.Combine($"{wwwRoot}/{imgFolder}/{folderName}", newFileName);
			await using var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);

			await imageFile.CopyToAsync(stream);
			await stream.FlushAsync();

			string message = imageType == ImageType.User
				? $"{newFileName} isimli kullanıcı resmi başarılı bir şekilde eklenmiştir"
				: $"{newFileName} Makale resmi başarılı bir şekilde eklenmiştir";

			return new ImageUploadedDto()
			{
				FullName = $"{folderName}/{newFileName}",
			};
		}

	}
}
