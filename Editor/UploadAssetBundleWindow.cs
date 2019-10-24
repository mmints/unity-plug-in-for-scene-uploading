using System;
using UnityEditor;
using UnityEngine;
using System.IO;

public class UploadAssetBundleWindow : EditorWindow
{
    private AssetBundleInterface _assetBundleInterface = new AssetBundleInterface();
    
    private string[] assetBundleOptions; // utilize for asset bundle selection from Popup element
    private int optionIndex; // needed for indexing of assetBundleOptions
    private string pathToScene;
    
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
        optionIndex = EditorGUILayout.Popup(optionIndex, assetBundleOptions);
        pathToScene = _assetBundleInterface.GetPathToScene(assetBundleOptions, optionIndex);
        pathToScene = EditorGUILayout.TextField ("Path to Scene", pathToScene);
    }
}