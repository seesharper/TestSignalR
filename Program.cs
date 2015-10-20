using System;
using Microsoft.AspNet.SignalR;
using Owin;
using Microsoft.Owin.Hosting;

namespace TestSignalR
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			WebApp.Start<Startup>("localhost:5001");
			Console.WriteLine ("Hello World!");
			Console.ReadLine ();
		}
	}


	public class MainHub : Hub
	{
		public void Send(string name, string message)
		{
			// Call the broadcastMessage method to update clients.
			Clients.All.broadcastMessage(name, message);

		}
	}


	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			app.MapSignalR();
		}


	}

}
