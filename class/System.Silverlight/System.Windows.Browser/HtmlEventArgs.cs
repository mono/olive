using System;

namespace System.Windows.Browser
{
	public class HtmlEventArgs
	{
		HtmlElement source_element;
		int client_x, client_y, offset_x, offset_y;
		bool alt, ctrl, shift;
		int mouse_button, key_code, char_code;
		string event_type;

		public HtmlEventArgs (HtmlElement sourceElement,
				      int clientX, int clientY,
				      int offsetX, int offsetY,
				      bool altKey, bool ctrlKey, bool shiftKey,
				      int mouseButton, int keyCode, int charCode,
				      string eventType)
		{
		}

		public HtmlElement SourceElement {
			get { return source_element; }
		}

		public string EventType {
			get { return event_type; }
		}

		public int ClientX {
			get { return client_x; }
		}

		public int ClientY {
			get { return client_y; }
		}

		public int OffsetX {
			get { return offset_x; }
		}

		public int OffsetY {
			get { return offset_y; }
		}

		public bool AltKey {
			get { return alt; }
		}

		public bool CtrlKey {
			get { return ctrl; }
		}

		public bool ShiftKey {
			get { return shift; }
		}

		public int MouseButton {
			get { return mouse_button; }
		}

		public int KeyCode {
			get { return key_code; }
		}

		public int CharCode {
			get { return char_code; }
		}
	}
}

