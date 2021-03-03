using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_to_SQL
{
	public static class CONSOLE
	{
		/// <summary> Displays a message in a given color, then adds a backslash </summary>
		/// <param name="color"> color of the message </param>
		/// <param name="message"> message to be displayed </param>
		public static void WriteLine(ConsoleColor color, string message)
		{
			Console.ForegroundColor = color;
			Console.WriteLine(message);
			Console.ResetColor();
		}
	}
}