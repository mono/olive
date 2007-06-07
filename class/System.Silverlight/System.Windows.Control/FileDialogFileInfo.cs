using System;
using System.IO;

namespace System.Windows.Hosting
{
	public class FileDialogFileInfo
	{
		string name, path;

		internal FileDialogFileInfo (string name, string path)
		{
			this.name = name;
			this.path = path;
		}

		[MonoTODO]
		public Stream OpenRead ()
		{
			return File.OpenRead (path);
		}

		[MonoTODO]
		public TextReader OpenText ()
		{
			return File.OpenText (path);
		}

		[MonoTODO]
		public string Name {
			get { return name; }
		}
	}
}
