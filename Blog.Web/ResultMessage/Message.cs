namespace Blog.Web.ResultMessage
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

			}public static string UndoDelete(string articleTitle)
			{
				return $" {articleTitle} İşlem Başarılı, Geri Alma işlemi Yapıldı.";

			}
		}


		public static class Category
		{
			public static string Add(string categoryName)
			{
				return $" {categoryName} İşlem Başarılı, Ekleme Yapıldı.";

			}
			public static string Update(string categoryTitle)
			{
				return $" {categoryTitle} İşlem Başarılı, Güncelleme Yapıldı.";

			}
			public static string Delete(string articleTitle)
			{
				return $" {articleTitle} İşlem Başarılı, Silme işlemi Yapıldı.";

			}
			public static string UndoDelete(string articleTitle)
			{
				return $" {articleTitle} İşlem Başarılı, Geri Alma  işlemi Yapıldı.";

			}
		}
		public static class User
		{
			public static string Add(string userName)
			{
				return $" {userName} İşlem Başarılı, Ekleme Yapıldı.";

			}
			public static string Update(string userName)
			{
				return $" {userName} İşlem Başarılı, Güncelleme Yapıldı.";

			}
			public static string Delete(string userName)
			{
				return $" {userName} İşlem Başarılı, Silme işlemi Yapıldı.";

			}
		}

	}
}
