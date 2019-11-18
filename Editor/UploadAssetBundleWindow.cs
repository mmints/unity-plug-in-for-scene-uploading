using System.IO;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class UploadAssetBundleWindow : EditorWindow
    {
        private AssetBundleInterface _assetBundleInterface = new AssetBundleInterface();
        private SFTPServerInterface _serverInterface = new SFTPServerInterface("odl4u.ko-ld.de");
        
        private string _username;
        private string _password;
        
        private string _assetBundleBuildDirectory = "Assets/AssetBundles/";
        private string[] _assetBundleOptions; // utilize for asset bundle selection from Popup element
        private int _optionIndex; // needed for indexing of assetBundleOptions
    
        [MenuItem("Window/Upload Scene to Moodle Server")] // Add menu item to the Window menu
        public static void ShowWindow()
        {
            // Show existing window instance. If one doesn't exist, make one.
            EditorWindow.GetWindow(typeof(UploadAssetBundleWindow));
        }
    
        void OnEnable()
        {
            _assetBundleOptions = AssetDatabase.GetAllAssetBundleNames(); // fill assetBundleOptions when opening the window
            
            Debug.Log("Available Asset Bundles: ");
            foreach (var ab in _assetBundleOptions)
            {
                Debug.Log(ab);
            }
            Debug.Log("\n ==== \n");
        }

        void OnGUI()
        {
            if (GUILayout.Button("Build Scene"))
            {
                _assetBundleInterface.BuildAllAssetBundles(_assetBundleBuildDirectory);
            }
            
            _optionIndex = EditorGUILayout.Popup(_optionIndex, _assetBundleOptions);
        
            _username = EditorGUILayout.TextField ("Username", _username);
            _password = EditorGUILayout.PasswordField("Password", _password);
            
            if (GUILayout.Button("Upload Scene"))
            {
                if (File.Exists(_assetBundleBuildDirectory + _assetBundleOptions[_optionIndex]))
                {
                    _serverInterface.UploadFile(_assetBundleBuildDirectory + _assetBundleOptions[_optionIndex], _username, _password);
                }
                else
                {
                    Debug.LogError("There is no target build for '" + _assetBundleBuildDirectory + _assetBundleOptions[_optionIndex] + "'");
                }
            }
        }
    }
}