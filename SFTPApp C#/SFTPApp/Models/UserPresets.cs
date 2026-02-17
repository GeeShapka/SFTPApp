using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFTPApp.Models
{
    /*
	 * FILE : UserPresets.cs
	 * PROJECT : $safeprojectname$
	 * PROGRAMMER : George Shapka
	 * FIRST VERSION : 2/14/2026 9:38:45 PM
	 */
    public class UserPresets
	{
		public static string UserPresetsFilePath = "UserPresets.xml";
		public List<UserPreset> Presets { get; set; } = new List<UserPreset>();


		/// <summary>
		/// loads user presets
		/// </summary>
		/// <returns></returns>
		public static UserPresets InitializeUserPresets()
		{
			UserPresets? userPresets;
			try
            {
				//if the file does not exist, create it and add an empty UserPresets object to it
                if (!File.Exists(UserPresets.UserPresetsFilePath))
                {
                    FileStream fs = File.Create(UserPresets.UserPresetsFilePath);
                    fs.Close();

                    Serializer.SerializeUserPresets(new UserPresets(), UserPresets.UserPresetsFilePath);
                }
                userPresets = Serializer.DeserializeUserPresets(UserPresets.UserPresetsFilePath);
				if(userPresets.Presets.Count == 0)
				{
					userPresets.Presets.Add(new UserPreset());
					userPresets.Presets[0].PresetName = "Preset 1";
				}
				return userPresets;
            }
			catch (Exception ex)
			{
				throw;
			}

		}



		public void AddPreset(UserPreset preset)
		{
			Presets.Add(preset);
		}


		public void EditPreset(Guid id, UserPreset newPreset)
		{
			UserPreset? temp = null;
			foreach(UserPreset preset in Presets)
			{
				if (preset.Id == id)
				{
					temp = preset; 
					break;
				}
			}
			if(temp == null)
			{
				return;
			}
			Presets.Remove(temp);
			Presets.Add(newPreset);
		}

		public ObservableCollection<string> GetPresetNames()
		{
            ObservableCollection<string> names = new ObservableCollection<string>();
			foreach(UserPreset preset in Presets)
			{
				names.Add(preset.PresetName);
			}
			return names;
		}
    }//end of UserPresets

}//end of SFTPApp.Models