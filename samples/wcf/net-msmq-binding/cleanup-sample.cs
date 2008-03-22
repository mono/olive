using System;
using System.Messaging;

public class Setup
{
	public static void Main ()
	{
		MessageQueue.Delete (".\\Private$\\monowcftest");
	}
}

