using UnityEngine;

namespace Scripts.MonoCash.Tier1
{
    public abstract class MonoCashListener : MonoBehaviour
    {
        public virtual void OnInitialization()
        {
            //Что происходит при старте сцены
        }

        public virtual void OnProcess()
        {
            //Обновление данных
        }


        public virtual void OnFixedProcess()
        {
            //Обновление физического состояния
        }


        public virtual void OnPostProcess()
        {
            //Обновление визуального состояния
        }
    }
}