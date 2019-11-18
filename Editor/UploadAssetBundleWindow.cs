using System.IO;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class UploadAssetBundleWindow : EditorWindow
    {
        private AssetBundleInterface _assetBundleInterface = new AssetBundleInterface();
        //private ServerInterface _serverInterface = new ServerInterface("ftp://odl4u.ko-ld.de/home/mmints/unity-webservice");
        private SFTPServerInterface _serverInterface = new SFTPServerInterface("odl4u.ko-ld.de");

        // TODO: Make this secure!
        private string username;
        private string password;
        
        private string[] assetBundleOptions; // utilize for asset bundle selection from Popup element
        private int optionIndex; // needed for indexing of assetBundleOptions
    
        [MenuItem("Window/Upload Scene to Moodle Server")] // Add menu item to the Window menu
        public static void ShowWindow()
        {
            // Show existing window instance. If one doesn't exist, make one.
            EditorWindow.GetWindow(typeof(UploadAssetBundleWindow));
        }
    
        void OnEnable()
        {
            assetBundleOptions = AssetDatabase.GetAllAssetBundleNames(); // fill assetBundleOptions when opening the window
        }

        void OnGUI()
        {
            if (GUILayout.Button("Build Scene"))
            {
                _assetBundleInterface.BuildAllAssetBundles("Assets/AssetBundles");
            }
            
            optionIndex = EditorGUILayout.Popup(optionIndex, assetBundleOptions);
        
            username = EditorGUILayout.TextField ("Username", username);
            password = EditorGUILayout.TextField ("Password", password);
            
            if (GUILayout.Button("Upload Scene"))
            {
                // TODO: Select the path to the build asset bundle, not to the raw scene file
                _serverInterface.UploadFile("Assets/AssetBundles/test0", username, password); // just for testing
            }
        }
    }
}