﻿namespace Blog.Web.ResultMessage
{
	public static class Message
	{
		public static class Article
		{
			public static string Add(string articleTitle)
			{
				return $" {articleTitle} İşlem Başarılı, Ekleme Yapıldı.";

			}
			public static string Update(string articleTitle)
			{
				return $" {articleTitle} İşlem Başarılı, Güncelleme Yapıldı.";

			}
			public static string Delete(string articleTitle)
			{
				return $" {articleTitle} İşlem Başarılı, Silme işlemi Yapıldı.";

			}
		}
	}
}