using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public LoadType LoadType;

    public void OnClick()
    {
        SceneManager.LoadSceneAsync("MainScene");
        InfomationProvider.LoadType = LoadType;
    }
}