using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Renci.SshNet;

public class SFTPServerInterface : MonoBehaviour
{
    
    private string _serverUri;
    private string _direction = "/home/mmints/unity-webservice/";

    public SFTPServerInterface(string serverUri)
    {
        _serverUri = serverUri;
    }

    public void UploadFile(string pathToFile, string userName, string password)
    {
        var connectionInfo = new ConnectionInfo(_serverUri, userName, new PasswordAuthenticationMethod(userName, password));
        using (var sftpClient = new SftpClient(connectionInfo))
        {
            sftpClient.Connect();
            using (var fileStream = File.OpenRead(pathToFile))
            {
                sftpClient.UploadFile(fileStream, _direction + "test0", true);
            }
            sftpClient.Disconnect();
        }
    }
}
