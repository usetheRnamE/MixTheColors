using UnityEngine.SceneManagement;
using UnityEngine;

namespace UI
{
    public class SceneSwitcher : MonoBehaviour
    {
        public string sceneName;

        public void SwitchTheScene()
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
