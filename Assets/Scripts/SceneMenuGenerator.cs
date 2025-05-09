using UnityEditor;
using UnityEngine;
using System.IO;
using System.Text;

public class SceneMenuGenerator
{
    private const string scenesFolder = "Assets/Scenes"; // Change to your folder
    private const string outputPath = "Assets/Editor/Generated/SceneMenu.cs"; // Output script

    [MenuItem("Tools/Generate Scene Menu Script")]
    public static void GenerateSceneMenu()
    {
        if (!Directory.Exists("Assets/Editor/Generated"))
            Directory.CreateDirectory("Assets/Editor/Generated");

        var guids = AssetDatabase.FindAssets("t:Scene", new[] { scenesFolder });

        var sb = new StringBuilder();

        sb.AppendLine("using UnityEditor;");
        sb.AppendLine("using UnityEditor.SceneManagement;");
        sb.AppendLine("");
        sb.AppendLine("// Auto-generated file. Do not edit manually.");
        sb.AppendLine("public static class SceneMenu");
        sb.AppendLine("{");

        foreach (var guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            string sceneName = Path.GetFileNameWithoutExtension(path);
            string safeMethodName = sceneName.Replace(" ", "_"); // Avoid spaces in method names

            sb.AppendLine($"    [MenuItem(\"Scenes/{sceneName}\")]");
            sb.AppendLine($"    public static void Open_{safeMethodName}() => OpenScene(\"{path}\");");
            sb.AppendLine();
        }

        sb.AppendLine("    private static void OpenScene(string path)");
        sb.AppendLine("    {");
        sb.AppendLine("        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())");
        sb.AppendLine("            EditorSceneManager.OpenScene(path);");
        sb.AppendLine("    }");

        sb.AppendLine("}");

        File.WriteAllText(outputPath, sb.ToString());
        AssetDatabase.Refresh();

        Debug.Log($"Scene menu script generated at: {outputPath}");
    }
}