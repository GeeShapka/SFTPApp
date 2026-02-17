using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFTPApp.Models
{
    /*
	 * FILE : UserPreset.cs
	 * PROJECT : $safeprojectname$
	 * PROGRAMMER : George Shapka
	 * FIRST VERSION : 2/14/2026 9:32:25 PM
	 */
    public class UserPreset
	{
		public Guid Id { get; }
		public string PresetName { get; set; } = "Preset 1";
		public string UserName { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public string IpAddress { get; set; } = string.Empty;
		public List<string> RemoteFilePaths { get; set; } = new List<string>();

		public UserPreset()
		{
			Id = Guid.NewGuid();
		}
		public UserPreset(string presetName, string username, string password, string ipAddress)
		{
			Id = Guid.NewGuid();
			PresetName = presetName;
			UserName = username;
			Password = password;
			IpAddress = ipAddress;
        }
    }//end of UserPreset

}//end of SFTPApp.Models