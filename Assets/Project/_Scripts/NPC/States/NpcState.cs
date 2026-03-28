namespace Scripts.NPC
{
    public class NpcState
    {
        public virtual void OnStateEnter() {}
        public virtual void OnStateExit() {}
        public virtual void OnPhysicalProcess() {}
        public virtual void OnVisualProcess() {}
    }
}