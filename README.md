# Unity Plug-In for Scene Uploading (WIP)
_**Attention:** This plug-in is still in development. Currently it is possible to upload AssetBundles to ``odl4u.ko-ld.de`` for registered users on this server._

## Download and Installation ( Build 0.0.2)
The news build of the plug-in can be downloaded [here](https://owncloud.uni-koblenz.de/owncloud/s/tApp6sxP94Y5DfY).

Install the plug-in package (``UploadScene.unitypackage``) simply by drag and drop into the desired Unity-Editor window. After this, you will find uploading dialogue under ``Window->Upload Asset Bundle to Moodle Server``.

## Dependencies
All needed dependencies can be found in the directory ``third-party``.
- ``UnityEngine.dll (Unity Version 2019.2.19f1)``
- ``UnityEditor.dll (Unity Version 2019.2.19f1)``
- ``Renci.SshNet.dll`` [GitHub](https://github.com/sshnet/SSH.NET)

## Change Log

### Version 0.0.2
The GUI has been redesign.

A reloading function has been added. For reloading the plug-in for example to update the AssetBundle list, it noe necessary to close and open it up again anymore. Just press the button 'Reset'.

Now it is possible to brows through Scene inside of a selected AssetBundle.Currently this feature has no effect, but in future it will be used to select the starting scene in a multi-level VR-scenario. 

A messaging field has been added. It will be user for showing messages to the user directly in the plug-in and not through the Unity-console.