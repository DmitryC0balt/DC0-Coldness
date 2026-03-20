using Scripts.MonoCash.Tier1;
using UnityEngine;
using UnityEngine.Rendering;

namespace Scripts.Effect
{
    [RequireComponent(typeof(Volume))]
    public class ScreenEffectHandler : MonoCashListener
    {
        [Header("Value settings")]
        [SerializeField, Range(0,1)] private float _maxVignetteValue;
        [Header("Color settings")]
        [SerializeField, ColorUsage(true)] private Color _defaultColor;
        [SerializeField, ColorUsage(true)] private Color _coldnessColor;
        [SerializeField, ColorUsage(true)] private Color _hurtColor;

        private Volume _volume;


        public override void OnInitialization()
        {
            _volume = GetComponent<Volume>();
        }


        public override void OnProcess()
        {
            
        }


        public void SetColnessFrame()
        {
            
        }


        public void SetHurtFrame()
        {
            
        }

    }
}