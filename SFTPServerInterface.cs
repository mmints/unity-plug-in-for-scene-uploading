using System.IO;
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
        string fileName = GetFileNameFromPath(pathToFile);
        var connectionInfo = new ConnectionInfo(_serverUri, userName, new PasswordAuthenticationMethod(userName, password));
        using (var sftpClient = new SftpClient(connectionInfo))
        {
            sftpClient.Connect();
            using (var fileStream = File.OpenRead(pathToFile))
            {
                sftpClient.UploadFile(fileStream, _direction + fileName, true);
            }
            sftpClient.Disconnect();
        }
        Debug.Log("SUCCESS: save file [" + fileName + "] at [" + _serverUri + pathToFile + "]");
    }

    private string GetFileNameFromPath(string pathToFile)
    {
        string[] path = pathToFile.Split('/');
        return path[path.Length - 1];
    }
}
