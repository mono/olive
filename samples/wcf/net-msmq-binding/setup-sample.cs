using System;
using System.Messaging;

public class Setup
{
	public static void Main ()
	{
		string path = ".\\Private$\\monowcftest";
		if (!MessageQueue.Exists (path))
			MessageQueue.Create (path);
	}
}

