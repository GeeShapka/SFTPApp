using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SFTPApp.Models
{
    /*
	 * FILE : UserCommunication.cs
	 * PROJECT : $safeprojectname$
	 * PROGRAMMER : George Shapka
	 * FIRST VERSION : 2/10/2026 7:50:52 PM
	 */
    internal class UserCommunication
    {
		public static void DisplayError(string message)
		{
			MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			return;
		}
    }//end of UserCommunication

}//end of SFTPApp.Models