using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SFTPApp.Models
{
    /*
	 * FILE : Serializer.cs
	 * PROJECT : $safeprojectname$
	 * PROGRAMMER : George Shapka
	 * FIRST VERSION : 2/14/2026 9:42:25 PM
	 */
    internal class Serializer
	{
        /// <summary>
        /// serializes user presets to xml file
        /// </summary>
        /// <param name="userPresets"></param>
        /// <param name="filePath"></param>
        public static void SerializeUserPresets(UserPresets userPresets, string filePath)
        {
            try
            {
                File.WriteAllText(filePath, string.Empty);
                XmlSerializer serializer = new XmlSerializer(typeof(UserPresets));
                using(StreamWriter sw = new StreamWriter(filePath))
                {
                    serializer.Serialize(sw, userPresets);
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return;
        }



        /// <summary>
        /// deserialized user presets from xml file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static UserPresets DeserializeUserPresets(string filePath)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(UserPresets));
                using (StreamReader sr = new StreamReader(filePath))
                {
                    return (UserPresets)serializer.Deserialize(sr);
                }
            }
            catch(Exception e)
            {
                throw;
            }
        }


    }//end of Serializer

}//end of SFTPApp.Models