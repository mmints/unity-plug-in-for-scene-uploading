using System.IO;
using UnityEditor;
using UnityEngine;


public class UploadAssetBundleWindow : EditorWindow
{
    private AssetBundleInterface _assetBundleInterface = new AssetBundleInterface();
    private SFTPServerInterface _serverInterface = new SFTPServerInterface("odl4u.ko-ld.de");
        
    private string _username;
    private string _password;
        
    private string _assetBundleBuildDirectory = "Assets/AssetBundles/";

    private string[] _assetBundleOptions; // utilize for asset bundle selection from Popup element
    private int _assetBundleOptionIndex; // needed for indexing of assetBundleOptions

    private string[] _sceneNameOptions; // utilize for scene selection from Popup element  
    private int _sceneNameOptionIndex; // needed for indexing of scene names

    void OnEnable()
    {
        ReloadAssetBundleList();
    }

    void ReloadAssetBundleList()
    {
        _assetBundleOptions = AssetDatabase.GetAllAssetBundleNames(); // fill assetBundleOptions when opening the window
        
        // Just needed for 
        Debug.Log("Available Asset Bundles: ");
        foreach (var ab in _assetBundleOptions)
        {
            Debug.Log(ab);
        }
    }
    
    // *** BEGIN GUI LAYOUT *** //
    
    [MenuItem("Window/Upload Asset Bundle to Moodle Server")] // Add menu item to the Window menu
    public static void ShowWindow()
    {
        // Show existing window instance. If one doesn't exist, make one.
        EditorWindow.GetWindow(typeof(UploadAssetBundleWindow));
    }

    void OnGUI()
    {
        if (GUILayout.Button("Reset"))
        {
            ReloadAssetBundleList();
        }

        
        if (GUILayout.Button("Build All Asset Bundles"))
        {
            _assetBundleInterface.BuildAllAssetBundles(_assetBundleBuildDirectory);
        }

        EditorGUILayout.Space();
        
        _assetBundleOptionIndex = EditorGUILayout.Popup("Select Asset Bundle", _assetBundleOptionIndex, _assetBundleOptions);

        _sceneNameOptions = AssetDatabase.GetAssetPathsFromAssetBundle(_assetBundleOptions[_assetBundleOptionIndex]);
        _sceneNameOptionIndex = EditorGUILayout.Popup("Select Start Scene", _sceneNameOptionIndex, _sceneNameOptions);
        
        EditorGUILayout.Space();
        
        _username = EditorGUILayout.TextField ("Username", _username);
        _password = EditorGUILayout.PasswordField("Password", _password);
            
        if (GUILayout.Button("Upload Asset Bundles"))
        {
            if (File.Exists(_assetBundleBuildDirectory + _assetBundleOptions[_assetBundleOptionIndex]))
            {
                _serverInterface.UploadFile(_assetBundleBuildDirectory + _assetBundleOptions[_assetBundleOptionIndex], _username, _password);
            }
            else
            {
                Debug.LogError("There is no target build for '" + _assetBundleBuildDirectory + _assetBundleOptions[_assetBundleOptionIndex] + "'");
            }
        }
        
        EditorGUILayout.Space();

        EditorGUILayout.HelpBox("PLACEHOLDER - Show help to the user", MessageType.Info);
    }
}
