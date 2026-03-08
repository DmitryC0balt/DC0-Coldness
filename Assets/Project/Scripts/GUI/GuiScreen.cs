using UnityEngine;

namespace Scripts.GUI
{
    public abstract class GuiScreen : MonoBehaviour
    {
        public void Show()
        {
            gameObject.SetActive(true);
            OnShow();
        }


        public void Hide()
        {
            gameObject.SetActive(false);
            OnHide();
        }


        protected abstract void OnShow();//Что происходит, когда включается UI
        protected abstract void OnHide();//Что происходит, когда UI выключается
    }
}