﻿
using Microsoft.AspNetCore.Identity;

namespace Blog.Entity.Entities
{
	public class User:IdentityUser<Guid>
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public Guid ImageId { get; set; }
		public Image Image { get; set; }
		public ICollection<Article>Articles { get; set; }
	}
}