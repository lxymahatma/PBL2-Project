using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.sceneLoaded += (_, _) => OnSceneLoaded();
    }

    private static void OnSceneLoaded()
    {
        if (InfomationProvider.LoadType == LoadType.Recognize)
            LoadRecognize();
        else
            LoadWrite();
    }

    private static void LoadRecognize()
    {
        Debug.Log("LoadRecognize");
    }

    private static void LoadWrite()
    {
        Debug.Log("LoadWrite");
    }
}