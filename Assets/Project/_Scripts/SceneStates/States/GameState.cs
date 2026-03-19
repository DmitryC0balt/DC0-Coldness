using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.SceneStates
{
    public class GameState : SceneState
    {
        public GameState(bool needSceneAccept) : base(needSceneAccept) {}
        public override AsyncOperation OnStateEnter() => SceneManager.LoadSceneAsync("Game", LoadSceneMode.Additive);
        public override void OnStateExit() => SceneManager.UnloadSceneAsync("Game");
    }
}