using UnityEditor;
using UnityEditor.SceneManagement;

// Auto-generated file. Do not edit manually.
public static class SceneMenu
{
    [MenuItem("Scenes/Sample")]
    public static void Open_Sample() => OpenScene("Assets/Scenes/Sample.unity");

    [MenuItem("Scenes/SampleScene")]
    public static void Open_SampleScene() => OpenScene("Assets/Scenes/SampleScene.unity");

    private static void OpenScene(string path)
    {
        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            EditorSceneManager.OpenScene(path);
    }
}
