using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.SceneStates
{
    public class MenuState : SceneState
    {
        public MenuState(bool needSceneAccept) : base(needSceneAccept) {}
        public override AsyncOperation OnStateEnter() => SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Additive);
        public override void OnStateExit() => SceneManager.UnloadSceneAsync("Menu");
    }
}