using System;
using System.Collections.Generic;
using System.Text;
using Tricker.Models;
using Tricker.Services;
using Xamarin.Forms;

namespace Tricker.PageModels
{
	public class PersonalPageModel : BindableObject
	{
		private User _profile;

		public PersonalPageModel()
		{
			int userId = GetUserId();
			Profile = UserService.Instance.GetProfile(userId);
		}

		private int GetUserId()
		{
			return 0;
		}

		public User Profile
		{
			get { return _profile; }
			set
			{
				_profile = value;
				OnPropertyChanged();
			}
		}
	}
}
