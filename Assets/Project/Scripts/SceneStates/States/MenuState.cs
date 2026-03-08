using UnityEngine.SceneManagement;

namespace Scripts.SceneStates
{
    public class MenuState : SceneState
    {
        public override void OnStateEnter()
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
        }

        public override void OnStateExit()
        {
            SceneManager.UnloadSceneAsync("Menu");
        }
    }
}