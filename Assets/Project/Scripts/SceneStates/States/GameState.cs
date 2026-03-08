using UnityEngine.SceneManagement;

namespace Scripts.SceneStates
{
    public class GameState : SceneState
    {
        public override void OnStateEnter()
        {
            SceneManager.LoadScene("Game", LoadSceneMode.Additive);
        }

        public override void OnStateExit()
        {
            SceneManager.UnloadSceneAsync("Game");
        }
    }
}