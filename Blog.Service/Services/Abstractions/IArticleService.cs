﻿using Blog.Entity.DTOs.Articles;
using Blog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Services.Abstractions
{
	public interface IArticleService
	{
		Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync();
		Task<ArticleDto> GetArticleWithCategoryNonDeletedAsync(Guid articleId);
		Task CreateArticleAsync(ArticleAddDto articleAddDto);
		Task UpdateArticleAysnc(ArticleUpdateDto articleUpdateDto);
		Task SafeDeleteArticleAsync(Guid articleId);
	}
}