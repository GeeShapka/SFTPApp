using Renci.SshNet;
using Renci.SshNet.Common;
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

		public NetworkWorker(string ipAddress, string username, string password, TimeSpan timeout)
		{
			try
            {
                _sftpClient = new SftpClient(ipAddress, username, password);
                if (_sftpClient == null)
                {
                    throw new Exception("Could not create the SFTP client");
                }
				_sftpClient.OperationTimeout = timeout;
				_sftpClient.Connect();
            }
			catch(Exception ex)
			{
				throw;
			}
		}

		/// <summary>
		/// gets the current working directory
		/// </summary>
		/// <returns></returns>
		public IEnumerable<ISftpFile> GetCurrentDirectory()
		{
			return _sftpClient.ListDirectory(_sftpClient.WorkingDirectory);
		}

		/// <summary>
		/// disconnects from the remote machine
		/// </summary>
		public void Disconnect()
		{
			try
            {
                if (_sftpClient != null && _sftpClient.IsConnected)
                {
                    _sftpClient.Disconnect();
                }
            }
			catch (Exception ex)
			{
				throw;
			}
		}
    }//end of NetworkWorker

}//end of SFTPApp.Models