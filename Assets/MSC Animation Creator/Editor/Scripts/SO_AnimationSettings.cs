using System.Collections.Generic;
using UnityEngine;

namespace ManaSeedTools.CharacterAnimator
{
    [CreateAssetMenu(fileName = "so_animationSettings", menuName = "Scriptable Objects/MSC Animation Settings")]
    public class SO_AnimationSettings : ScriptableObject
    {
        [SerializeField]
        public List<MSCAnimation> list;
    }
}