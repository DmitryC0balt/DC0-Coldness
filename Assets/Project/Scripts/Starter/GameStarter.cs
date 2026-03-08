using Scripts.EntryPoint;
using UnityEngine;

namespace Scripts.Starter
{
    public class GameStarter
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void OnLoadGame()
        {
            var gameEntryPoint = GameEntryPoint.GetInstance();
            gameEntryPoint.OpenMenuScene();
        }
    }
}