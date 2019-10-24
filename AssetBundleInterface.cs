using UnityEditor;
using UnityEngine;

public class AssetBundleInterface : MonoBehaviour
{
    public string GetPathToScene(string[] options, int index)
    // TODO: Use a Tuple to return a string and a boolean
    {
        string[] paths = AssetDatabase.GetAssetPathsFromAssetBundle(options[index]);
        if (paths.Length == 0)
        {
            return "Selected AssetBundle Is Not Assigned to a Scene";
        }
        else {
            return paths[0];
        }
    }
}
