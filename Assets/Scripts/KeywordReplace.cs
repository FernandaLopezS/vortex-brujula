// --------------------------------------------------
// --------------------------------------------------
// Creation Date: #DATETIME#
// Autor: #DEVELOPER#
// Description: #PROJECTNAME#
// --------------------------------------------------
// --------------------------------------------------

using UnityEngine;
using UnityEditor;

public class KeywordReplace : UnityEditor.AssetModificationProcessor
{
    public static void OnWillCreateAsset(string path)
    {
        path = path.Replace(".meta", "");
        int index = path.LastIndexOf(".");
        if (index < 0)
            return;

        string file = path.Substring(index);
        if (file != ".cs" && file != ".js" && file != ".boo")
            return;

        index = Application.dataPath.LastIndexOf("Assets");
        path = Application.dataPath.Substring(0, index) + path;
        if (!System.IO.File.Exists(path))
            return;
            
        string fileContent = System.IO.File.ReadAllText(path);

        fileContent = fileContent.Replace("#PROJECTNAME#", PlayerSettings.productName);
        fileContent = fileContent.Replace("#DEVELOPER#", SystemInfo.deviceName);
        fileContent = fileContent.Replace("#DATETIME#", System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

        System.IO.File.WriteAllText(path, fileContent);
        AssetDatabase.Refresh();
    }
}