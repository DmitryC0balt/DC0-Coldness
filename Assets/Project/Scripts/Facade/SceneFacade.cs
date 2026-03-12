using Scripts.EntryPoint;

namespace Scripts.Facade
{
    public class SceneFacade
    {
        protected GameEntryPoint _gameEntryPoint;

        public SceneFacade()
        {
            _gameEntryPoint = GameEntryPoint.GetInstance();
        }
    }
}