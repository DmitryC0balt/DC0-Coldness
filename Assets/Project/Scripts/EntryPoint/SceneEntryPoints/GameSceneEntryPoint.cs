using Scripts.Facade;
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
        

        private GameSceneFacade _gameSceneFacade;


        public override void OnSceneEnter()
        {
            _gameSceneFacade = SetupGameSceneFacade();
        }


        public override void OnSceneExit()
        {
            
        }


        //Включен в SetupGameSceneFacade
        private MonoCashObserver SetupMonoCashObserver()
        {
            var monoCashObserver = new MonoCashObserver();

            foreach (var listener in _listeners)
            {
                monoCashObserver.AddListener(listener);
            }

            return monoCashObserver;
        }


        //Включен в SetupGameSceneFacade
        private GuiScreenContainer SetupScreenContainer()
        {
            var guiScreenContainer = new GuiScreenContainer();

            foreach (var screen in _screens)
            {
                guiScreenContainer.AddScreen(screen);
            }

            return guiScreenContainer;
        }


        private void SetupGameScreens(GameSceneFacade gameSceneFacade)
        {
            
        }


        private GameSceneFacade SetupGameSceneFacade()
        {
            var monoCashObserver = SetupMonoCashObserver();
            var guiScreenContainer = SetupScreenContainer();
            var gameSceneFacade = new GameSceneFacade();

            return gameSceneFacade;
        }
    }
}