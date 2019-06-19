using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;

namespace tslight
{
	/// Class with program entry point.
	internal sealed class Program
	{   
        /// Program entry point.
        [STAThread]
		private static void Main(string[] args)
		{
            //HMI
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
           
        }
		
	}
}
