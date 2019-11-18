using System.IO;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class AssetBundleInterface : MonoBehaviour
    {
        public void BuildAllAssetBundles(string assetBundleDirectory)
        {
            if(!Directory.Exists(assetBundleDirectory))
            {
                Directory.CreateDirectory(assetBundleDirectory);
            }
            BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.StandaloneWindows);
            Debug.Log("All Asset Bundles has been build and saved to: " + assetBundleDirectory);
        }
    }
}
