
using Blog.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Blog.Entity.Entities
{
	public class User:IdentityUser<Guid>,IEntityBase
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public Guid ImageId { get; set; } = Guid.Parse("7e46c417-a3c7-435e-96bf-e95cda06bb8a");
		public Image Image { get; set; }
		public ICollection<Article>Articles { get; set; }
	}
}
