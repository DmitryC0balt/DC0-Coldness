using Scripts.GUI;
using UnityEngine;

namespace Scripts.EntryPoint
{
    public sealed class MenuSceneEntryPoint : SceneEntryPoint
    {
        //Значится, так - здесь все, что касается сцены с основным меню - и только с ним.
        //Все, что не относится к меню - долой. Настройки тоже, они в другой сцене.

        [Header("GUI presets")]
        [SerializeField] private GuiScreen[] _screens;
        //И в основном-то эта сцена из экранов и состоит - просто заносим все, что наследуется от GuiScreen, 
        //а дальше входная точка сама прокинет это все в контейнер и запечатает его. Измменить содержимое в
        //процессе игры не выйдет


        private GuiScreenContainer _guiScreenContainer;
        

        public override void OnSceneEnter()
        {
            _guiScreenContainer = new GuiScreenContainer();
        }

        public override void OnSceneExit()
        {
            
        }


        private void LoadGui()
        {
            foreach (var screen in _screens)
            {
                _guiScreenContainer.AddScreen(screen);
            }
        }
    }
}