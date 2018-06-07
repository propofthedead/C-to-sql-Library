using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlLibrary;

namespace CsharpToSqlLibrary
{
	class Program
	{
		static void Main(string[] args)
		{
			UsersController UserCtrl= new UsersController(@"DESKTOP-7KOO68T\SQLEXPRESS","prs");
			IEnumerable<User> users = UserCtrl.List();
			foreach (User user in users) {
				Console.WriteLine($"{user.Firstname} {user.Lastname}");
			}
			User tuser = UserCtrl.Get(5);
			if (tuser == null) {
				Console.WriteLine("User not found");
			} else {
				Console.WriteLine($"{tuser.Firstname} {tuser.Lastname}");
			}
			User newUser = new User();
			newUser.Username = "raphbaryle";
			newUser.Password = "youmay";
			newUser.Firstname = "disgaea";
			newUser.Lastname = "hellschool";
			newUser.Phone = "513-489-3145";
			newUser.Email = "blach @ adad";
			newUser.IsReviewer = true;
			newUser.IsAdmin = false;
			UserCtrl.Create(newUser);
			IEnumerable<User> newusers = UserCtrl.List();
			foreach (User user in newusers) {
				Console.WriteLine($"{user.Firstname} {user.Lastname}");
			}
			UserCtrl.CloseConnection();
		}
	}
}
