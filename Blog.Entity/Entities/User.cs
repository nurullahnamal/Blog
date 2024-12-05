
using Microsoft.AspNetCore.Identity;

namespace Blog.Entity.Entities
{
	public class User:IdentityUser<Guid>
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public Guid ImageId { get; set; } = Guid.Parse("4028094A-6692-442E-8952-555355BDAF74");
		public Image Image { get; set; }
		public ICollection<Article>Articles { get; set; }
	}
}
