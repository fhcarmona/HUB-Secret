using UnityEngine.SceneManagement;

public static class LoadingPersistence
{
    public static string nextScene;

    private const string loadSceneName = "LoadingScene";

    public static void LoadScene(string nextSceneName)
    {
        nextScene = nextSceneName;

        SceneManager.LoadScene(loadSceneName);
    }
}
