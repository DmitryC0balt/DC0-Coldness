using UnityEngine;

namespace Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ResolutionPreset", menuName = "Scriptable Objects/ResolutionPreset")]
    public class ResolutionPreset : ScriptableObject
    {
        [SerializeField] private int _width;
        [SerializeField] private int _height;


        public int width => _width;
        public int height => _height;
    }
}