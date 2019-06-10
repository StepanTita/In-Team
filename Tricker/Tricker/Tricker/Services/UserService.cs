using System;
using System.Collections.Generic;
using System.Text;
using Tricker.Models;

namespace Tricker.Services
{
	public class UserService
	{
		private static UserService _instance;

		public static UserService Instance
		{
			get
			{
				if (_instance == null)
					_instance = new UserService();

				return _instance;
			}
		}

		public User GetProfile(int userId)
		{

			return new User
			{
				Login = GetUserLogin(userId),
				Picture = GetUserImage(userId),
				Name = GetUserName(userId),
				Email = GetUserEmail(userId),
				Password = GetUserPassword(userId),
				Birthday = GetUserBirthday(userId),
				Type = GetUserType(userId),
				Statistics = GetUserStatistics(userId),
				Garbages = GetUserGarbages(userId),
				Posts = GetUserPosts(userId),
				Chats = GetUserChats(userId),
				Subscribers = GetUserSubscribers(userId),
				Gallery = GetUserGallery(userId)
			};
		}

		// LOAD FROM DB!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
		private List<GalleryItem> GetUserGallery(int userId)
		{
			return new List<GalleryItem>
				 {
					 new GalleryItem { GalleryItemType = GalleryItemType.Medium, Picture = "sevilla01" },
					 new GalleryItem { GalleryItemType = GalleryItemType.Medium, Picture = "sevilla02" },
					 new GalleryItem { GalleryItemType = GalleryItemType.Big, Picture = "sevilla03" },
					 new GalleryItem { GalleryItemType = GalleryItemType.Default, Picture = "sevilla04" },
					 new GalleryItem { GalleryItemType = GalleryItemType.Default, Picture = "sevilla05" },
					 new GalleryItem { GalleryItemType = GalleryItemType.Default, Picture = "sevilla06" },
					 new GalleryItem { GalleryItemType = GalleryItemType.Default, Picture = "sevilla07" }
				 };
		}

		private List<Subscriber> GetUserSubscribers(int userId)
		{
			User us1 = new User();
			us1.Name = "Miguel";
			us1.Picture = "miguel";

			User us2 = new User();
			us2.Name = "David";
			us2.Picture = "david";

			User us3 = new User();
			us3.Name = "Rui";
			us3.Picture = "rui";

			User us4 = new User();
			us4.Name = "Matthew";
			us4.Picture = "matthew";

			return new List<Subscriber>
				 {
					 new Subscriber(us1),
					 new Subscriber(us2),
					 new Subscriber(us3),
					 new Subscriber(us4)
				 };
		}

		private List<Chat> GetUserChats(int userId)
		{
			return new List<Chat>();
		}

		private List<Post> GetUserPosts(int userId)
		{
			return new List<Post>();
		}

		private List<Garbage> GetUserGarbages(int userId)
		{
			return new List<Garbage>();
		}

		private Statistics GetUserStatistics(int userId)
		{
			return new Statistics();
		}

		private string GetUserType(int userId)
		{
			return "abracadabra";
		}

		private DateTime GetUserBirthday(int userId)
		{
			return DateTime.Now;
		}

		private string GetUserPassword(int userId)
		{
			return "kek";
		}

		private string GetUserEmail(int userId)
		{
			return "lol";
		}

		private string GetUserName(int userId)
		{
			return "Petrushka";
		}

		private string GetUserImage(int userId)
		{
			return "javier";
		}

		private string GetUserLogin(int userId)
		{
			return "petya228";
		}
	}
}
