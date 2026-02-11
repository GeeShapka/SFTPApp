using Renci.SshNet;
using Renci.SshNet.Sftp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFTPApp.Models
{
    /*
	 * FILE : NetworkWorker.cs
	 * PROJECT : $safeprojectname$
	 * PROGRAMMER : George Shapka
	 * FIRST VERSION : 2/10/2026 7:36:32 PM
	 */
    public class NetworkWorker
    {
		private SftpClient _sftpClient;

		public NetworkWorker(string ipAddress, string username, string password)
		{
			try
            {
                _sftpClient = new SftpClient(ipAddress, username, password);
                if (_sftpClient == null)
                {
                    throw new Exception("Could not create the SFTP client");
                }
				_sftpClient.Connect();
            }
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public IEnumerable<ISftpFile> GetCurrentDirectory()
		{
			return _sftpClient.ListDirectory(_sftpClient.WorkingDirectory);
		}
    }//end of NetworkWorker

}//end of SFTPApp.Models