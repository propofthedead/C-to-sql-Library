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
			newUser.Id = 10;
			newUser.Username = "raph";
			newUser.Password = "yoy";
			newUser.Firstname = "disgaea3";
			newUser.Lastname = "highschool";
			newUser.Phone = "513-489-3145";
			newUser.Email = "blach @ adad";
			newUser.IsReviewer = true;
			newUser.IsAdmin = false;
			newUser.Active = true;
			UserCtrl.Change(newUser);
			IEnumerable<User> newusers = UserCtrl.List();
			foreach (User user in newusers) {
				Console.WriteLine($"{user.Firstname} {user.Lastname}");
			}
			UserCtrl.CloseConnection();
		}
	}
}
