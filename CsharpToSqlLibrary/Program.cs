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
			UserCtrl.CloseConnection();
		}
	}
}
