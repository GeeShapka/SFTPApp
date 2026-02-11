namespace SFTPApp.Models
{
    /*
	* FILE : FileInfo.cs
	* PROJECT :
	* PROGRAMMER : George Shapka
	* FIRST VERSION : 2/3/2026 1:47:32 PM
	*/

    /*
	* NAME : FileInfo
	* PURPOSE :
	*/
    public class RemoteFileInfo
    {
        //properties
        public string Name { get; }
        public string IsDirectory { get; }

        //end of properties

        //constructors
        public RemoteFileInfo(string name, string isDirectory)
        {
            Name = name;
            IsDirectory = isDirectory;
        }

        //end of constructors

        //methods


        //end of methods
    }//end of FileInfo
}