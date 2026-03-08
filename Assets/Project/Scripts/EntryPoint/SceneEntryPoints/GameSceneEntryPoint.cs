using Scripts.GUI;
using Scripts.MonoCash.Tier1;
using UnityEngine;

namespace Scripts.EntryPoint
{
    public sealed class GameSceneEntryPoint : SceneEntryPoint
    {
        [Header("Screens")]
        [SerializeField] private GuiScreen[] _screens;
        [Space(5)]

        [Header("MonoCashListeners")]
        [SerializeField] private MonoCashListener[] _listeners;
        

        private MonoCashObserver _monoCashObserver;
        private GuiScreenContainer _guiScreenContainer;


        public override void OnSceneEnter()
        {
            
        }


        public override void OnSceneExit()
        {
            
        }
    }
}