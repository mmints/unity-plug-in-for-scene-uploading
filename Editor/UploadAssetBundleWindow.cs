using System;
using UnityEditor;
using UnityEngine;
using System.IO;

public class UploadAssetBundleWindow : EditorWindow
{
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
        optionIndex = EditorGUILayout.Popup(optionIndex, assetBundleOptions);
    }
}