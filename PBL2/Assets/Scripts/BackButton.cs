using UnityEngine;

namespace Scripts
{
    public class BackButton : MonoBehaviour
    {
        public void OnClick() => SceneManagerExt.LoadMenuScene();
    }
}