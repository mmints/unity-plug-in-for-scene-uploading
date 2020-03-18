using System.IO;
using UnityEditor;
using UnityEngine;

public class AssetBundleInterface : MonoBehaviour
{
    
    public string GetPathToScene(string[] options, int index)
    {
        // Can be usefull for late use
        string[] paths = AssetDatabase.GetAssetPathsFromAssetBundle(options[index]);
        if (paths.Length == 0)
        {
            return "Selected AssetBundle Is Not Assigned to a Scene";
        }
        else {
            return paths[0];
        }
    }

    public void BuildAllAssetBundles(string assetBundleDirectory)
    {
        if(!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.StandaloneWindows);
        Debug.Log("All Asset Bundles have been build and saved to: " + assetBundleDirectory);
    }
}
