using System;
using System.Collections.Generic;
using System.Text;

namespace Tricker.Models
{
	public class Subscriber : User
	{
		public Subscriber(User user)
		{
			this.Name = user.Name;
			this.Picture = user.Picture;
		}
	}
}
