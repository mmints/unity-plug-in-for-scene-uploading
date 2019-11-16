using System.IO;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class UploadAssetBundleWindow : EditorWindow
    {
        private AssetBundleInterface _assetBundleInterface = new AssetBundleInterface();
        private ServerInterface _serverInterface = new ServerInterface();
    
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
        
            if (GUILayout.Button("Upload Scene"))
            {
                // TODO: Select the path to the build asset bundle, not to the raw scene file
                _serverInterface.UploadAssetBundle("Assets/AssetBundles/test0"); // just for testing
            }

        }
    }
}