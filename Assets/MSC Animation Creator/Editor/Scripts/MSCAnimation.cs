using System;

namespace ManaSeedTools.CharacterAnimator
{
    [Serializable]
    public class MSCAnimation
    {
        public string animationType;

        //body,outfit, etc..
        public string animationName;

        //p1,p2,p3...
        public string spritePage;

        //animation key ints
        public int[] keys;

        //animation timers floats
        public float[] keyTimer;

        //layer key ints
        public int[] pritoolLayerKeys;

        public int[] sectoolLayerKeys;

        //xflip of sprite
        public bool xFlip = false;
    }
}