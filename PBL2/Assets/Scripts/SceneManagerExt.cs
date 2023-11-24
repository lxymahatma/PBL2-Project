using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts
{
    public static class SceneManagerExt
    {
        public static void LoadMainScene(LoadType loadType)
        {
            SceneManager.LoadScene("MainScene");

            switch (loadType)
            {
                case LoadType.Recognize:
                    LoadRecognizeScene();
                    break;

                case LoadType.Write:
                    LoadWriteScene();
                    break;
            }
        }

        public static void LoadMenuScene()
        {
            SceneManager.LoadSceneAsync("MenuScene");
        }

        private static void LoadRecognizeScene()
        {
            Debug.Log("Recognize scene");
        }

        private static void LoadWriteScene()
        {
            Debug.Log("Write scene");
        }
    }
}