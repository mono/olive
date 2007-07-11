using System;

namespace System.Windows.Browser
{
	public class HtmlTimer
	{
		public HtmlTimer ()
		{
		}

		[MonoTODO]
		public bool Enabled {
			set { /* nothing yet*/ }
			get { return false; }
		}

		int interval;
		[MonoTODO]
		public int Interval {
			set { interval = value; }
			get { return interval; }
		}

		[MonoTODO]
		public void Start ()
		{
		}

		[MonoTODO]
		public void Stop ()
		{
		}

		[MonoTODO]
		public override string ToString ()
		{
			return base.ToString ();
		}

		protected virtual void OnTick (EventArgs e)
		{
			if (Tick != null)
				Tick (this, e);
		}

		[MonoTODO]
		public event EventHandler Tick;
	}
}

