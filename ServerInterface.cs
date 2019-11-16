using UnityEngine;
using System.Collections;
using System.Net;
using UnityEngine.Networking;

public class ServerInterface : MonoBehaviour
{
    public void UploadAssetBundle(string pathToAssetBundle)
    {
        // TODO: Implement this
        using(WebClient client = new WebClient()) {
            client.UploadFile("http://141.26.140.219:666", pathToAssetBundle);
        }
        
        Debug.Log("Upload: " + pathToAssetBundle);
    }
}
