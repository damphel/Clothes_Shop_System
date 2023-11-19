using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ManaSeedTools.CharacterAnimator
{
    public class MSCAnimationSettings
    {
        public static void FillBasicMSCAnimations(SO_AnimationSettings animations)
        {
            animations.list = new List<MSCAnimation>();
            AddClimbing(animations);
            AddCrafting(animations);
            AddFishing(animations);
            AddHacking(animations);
            AddIdle(animations);
            AddJump(animations);
            AddLift(animations);
            AddPull(animations);
            AddPush(animations);
            AddRun(animations);
            AddThrowing(animations);
            AddWalk(animations);
            AddWater(animations);
            AddSleep(animations);
            AddSchock(animations);
            AddIdle2(animations);
            AddSideglance(animations);
            AddSittingStool(animations);
            AddSittingGround(animations);
            AddToeTapping(animations);
            EditorUtility.SetDirty(animations);
        }

        public static void FillSwordAndShieldMSCAnimations(SO_AnimationSettings swordAndShieldCombatAnimations)
        {
            swordAndShieldCombatAnimations.list = new List<MSCAnimation>();
            AddCombatIdle(swordAndShieldCombatAnimations, "combat/pONE2");
            AddCombatMove(swordAndShieldCombatAnimations, "combat/pONE2");
            AddCombatDraw(swordAndShieldCombatAnimations, "combat/pONE1");
            AddCombatSheath(swordAndShieldCombatAnimations, "combat/pONE1");
            AddCombatParry(swordAndShieldCombatAnimations, "combat/pONE1");
            AddCombatDodge(swordAndShieldCombatAnimations, "combat/pONE1");
            AddCombatHurt(swordAndShieldCombatAnimations, "combat/pONE1");
            AddCombatDead(swordAndShieldCombatAnimations, "combat/pONE1");
            AddCombatDeadDown(swordAndShieldCombatAnimations, "combat/pONE1");
            AddCombatRetreat(swordAndShieldCombatAnimations, "combat/pONE2");
            AddCombatLunge(swordAndShieldCombatAnimations, "combat/pONE2");

            AddCombatSlash1(swordAndShieldCombatAnimations, "combat/pONE3");
            AddCombatSlash2(swordAndShieldCombatAnimations, "combat/pONE3");

            AddSwordAndShieldThrust(swordAndShieldCombatAnimations, "combat/pONE3");
            AddSwordAndShieldShieldbash(swordAndShieldCombatAnimations, "combat/pONE3");
            EditorUtility.SetDirty(swordAndShieldCombatAnimations);
        }

        public static void FillSpearMSCAnimations(SO_AnimationSettings spearCombatAnimations)
        {
            spearCombatAnimations.list = new List<MSCAnimation>();
            AddCombatIdle(spearCombatAnimations, "combat/pPOL2");
            AddCombatMove(spearCombatAnimations, "combat/pPOL2");
            Dictionary<AnimDirection, int[]> loMainhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down,  new int[] { 0, 7, 7, 7 }},
                    {AnimDirection.up,  new int[] { 7, 0, 0, 0 }},
                    {AnimDirection.right,  new int[] { 0, 7, 7, 7 }},
                    {AnimDirection.left,  new int[] { 0, 7, 7, 7 }}
                };
            AddCombatDraw(spearCombatAnimations, "combat/pPOL1", loMainhand);
            loMainhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down,  new int[] { 7, 7, 0, 0 }},
                    {AnimDirection.up,  new int[] { 0, 0, 7, 7 }},
                    {AnimDirection.right,  new int[] { 7, 7, 0, 0 }},
                    {AnimDirection.left,  new int[] { 7, 7, 0, 0 }}
                };
            AddCombatSheath(spearCombatAnimations, "combat/pPOL1", loMainhand);
            AddCombatParry(spearCombatAnimations, "combat/pPOL1");
            AddCombatDodge(spearCombatAnimations, "combat/pPOL1");
            AddCombatHurt(spearCombatAnimations, "combat/pPOL1");
            loMainhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down,  new int[] { 7, 7,7  }},
                    {AnimDirection.up,  new int[] { 0, 0, 0 }},
                    {AnimDirection.right,  new int[] { 7, 7, 7 }},
                    {AnimDirection.left,  new int[] { 7, 7, 7 }}
                };
            AddCombatDead(spearCombatAnimations, "combat/pPOL1", loMainhand);
            loMainhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down,  new int[] { 7 }},
                    {AnimDirection.up,  new int[] { 0 }},
                    {AnimDirection.right,  new int[] { 7 }},
                    {AnimDirection.left,  new int[] { 7 }}
                };
            AddCombatDeadDown(spearCombatAnimations, "combat/pPOL1", loMainhand);
            AddCombatRetreat(spearCombatAnimations, "combat/pPOL2");
            AddCombatLunge(spearCombatAnimations, "combat/pPOL2");

            AddSpearSlash1(spearCombatAnimations, "combat/pPOL3");
            AddSpearThrust(spearCombatAnimations, "combat/pPOL3");
            AddSpearThrust2(spearCombatAnimations, "combat/pPOL3");
            EditorUtility.SetDirty(spearCombatAnimations);
        }

        public static void FillBowMSCAnimations(SO_AnimationSettings bowCombatAnimations)
        {
            bowCombatAnimations.list = new List<MSCAnimation>();
            Dictionary<AnimDirection, int[]> loMainhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down,  new int[] { 7, 7, 7, 7, 7 }},
                    {AnimDirection.up,  new int[] { 0, 0, 0, 0, 0 }},
                    {AnimDirection.right,  new int[] { 0, 0, 0, 0, 0 }},
                    {AnimDirection.left,  new int[] { 0, 0, 0, 0, 0 }}
                };
            Dictionary<AnimDirection, int[]> loOffhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down,  new int[] { 0, 0, 0, 0, 0 }},
                    {AnimDirection.up,  new int[] { 7, 7, 7, 7, 7 }},
                    {AnimDirection.right,  new int[] { 0, 0, 0, 0, 0 }},
                    {AnimDirection.left,  new int[] { 0, 0, 0, 0, 0 }}
                };
            AddCombatIdle(bowCombatAnimations, "combat/pBOW2", loMainhand, loOffhand);
            AddCombatMove(bowCombatAnimations, "combat/pBOW2", loMainhand, loOffhand);
            loMainhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down,  new int[] { 0, 7, 7, 7 }},
                    {AnimDirection.up,  new int[] { 7, 0, 0, 0 }},
                    {AnimDirection.right,  new int[] { 0, 0, 7, 7 }},
                    {AnimDirection.left,  new int[] { 0, 0, 7, 7 }}
                };
            loOffhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down,  new int[] { 0, 0, 0, 0 }},
                    {AnimDirection.up,  new int[] { 7, 7, 7, 7 }},
                    {AnimDirection.right,  new int[] { 0, 0, 0, 0 }},
                    {AnimDirection.left,  new int[] { 0, 0, 0, 0 }}
                };
            AddCombatDraw(bowCombatAnimations, "combat/pBOW1", loMainhand, loOffhand);
            loMainhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down,  new int[] { 7, 7, 0, 0 }},
                    {AnimDirection.up,  new int[] { 0, 0, 7, 7 }},
                    {AnimDirection.right,  new int[] { 7, 0, 0, 0 }},
                    {AnimDirection.left,  new int[] { 7, 0, 0, 0 }}
                };
            loOffhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down,  new int[] { 0, 0, 0, 0 }},
                    {AnimDirection.up,  new int[] { 7, 7, 7, 7 }},
                    {AnimDirection.right,  new int[] { 0, 0, 0, 0 }},
                    {AnimDirection.left,  new int[] { 0, 0, 0, 0 }}
                };
            AddCombatSheath(bowCombatAnimations, "combat/pBOW1", loMainhand, loOffhand);
            loOffhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down,  new int[] { 0 }},
                    {AnimDirection.up,  new int[] { 8 }},
                    {AnimDirection.right,  new int[] { 0 }},
                    {AnimDirection.left,  new int[] { 0 }}
                };
            AddCombatParry(bowCombatAnimations, "combat/pBOW1", null, loOffhand);
            loMainhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down,  new int[] { 0 }},
                    {AnimDirection.up,  new int[] { 0 }},
                    {AnimDirection.right,  new int[] { 0 }},
                    {AnimDirection.left,  new int[] { 0 }}
                };
            loOffhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down,  new int[] { 0 }},
                    {AnimDirection.up,  new int[] { 8 }},
                    {AnimDirection.right,  new int[] { 0 }},
                    {AnimDirection.left,  new int[] { 0 }}
                };
            AddCombatDodge(bowCombatAnimations, "combat/pBOW1", loMainhand, loOffhand);
            loMainhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down,  new int[] { 0 }},
                    {AnimDirection.up,  new int[] { 7 }},
                    {AnimDirection.right,  new int[] { 0 }},
                    {AnimDirection.left,  new int[] { 0 }}
                };
            loOffhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down,  new int[] { 0 }},
                    {AnimDirection.up,  new int[] { 8 }},
                    {AnimDirection.right,  new int[] { 0 }},
                    {AnimDirection.left,  new int[] { 0 }}
                };
            AddCombatHurt(bowCombatAnimations, "combat/pBOW1", loMainhand, loOffhand);
            loMainhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down,  new int[] { 0, 0, 0 }},
                    {AnimDirection.up,  new int[] { 7, 0, 7 }},
                    {AnimDirection.right,  new int[] { 0, 0, 0 }},
                    {AnimDirection.left,  new int[] { 0, 0, 0 }}
                };
            loOffhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down,  new int[] { 0, 0, 0 }},
                    {AnimDirection.up,  new int[] { 8, 8, 8 }},
                    {AnimDirection.right,  new int[] { 0, 0, 0 }},
                    {AnimDirection.left,  new int[] { 0, 0, 0 }}
                };
            AddCombatDead(bowCombatAnimations, "combat/pBOW1", loMainhand, loOffhand);
            loMainhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down,  new int[] { 0 }},
                    {AnimDirection.up,  new int[] { 0 }},
                    {AnimDirection.right,  new int[] { 0 }},
                    {AnimDirection.left,  new int[] { 0 }}
                };
            loOffhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down,  new int[] { 0 }},
                    {AnimDirection.up,  new int[] { 8 }},
                    {AnimDirection.right,  new int[] { 0 }},
                    {AnimDirection.left,  new int[] { 0 }}
                };
            AddCombatDeadDown(bowCombatAnimations, "combat/pBOW1", loMainhand, loOffhand);
            loMainhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down,  new int[] { 7, 7, 7, 7 }},
                    {AnimDirection.up,  new int[] { 0, 0, 0, 0 }},
                    {AnimDirection.right,  new int[] { 0, 0, 0, 0 }},
                    {AnimDirection.left,  new int[] { 0, 0, 0, 0 }}
                };
            loOffhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down,  new int[] { 0, 0, 0, 0 }},
                    {AnimDirection.up,  new int[] { 8, 8, 8, 8 }},
                    {AnimDirection.right,  new int[] { 0, 0, 0, 0 }},
                    {AnimDirection.left,  new int[] { 0, 0, 0, 0 }}
                };
            AddCombatRetreat(bowCombatAnimations, "combat/pBOW2", loMainhand, loOffhand);
            loMainhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down,  new int[] { 7, 0, 0, 0 }},
                    {AnimDirection.up,  new int[] { 0, 0, 0, 0 }},
                    {AnimDirection.right,  new int[] { 0, 0, 0, 0 }},
                    {AnimDirection.left,  new int[] { 0, 0, 0, 0 }}
                };
            loOffhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down,  new int[] { 0, 0, 0, 0 }},
                    {AnimDirection.up,  new int[] { 8, 8, 8, 8 }},
                    {AnimDirection.right,  new int[] { 0, 0, 0, 0 }},
                    {AnimDirection.left,  new int[] { 0, 0, 0, 0 }}
                };
            AddCombatLunge(bowCombatAnimations, "combat/pBOW2", loMainhand, loOffhand);

            AddBowShootUp(bowCombatAnimations, "combat/pBOW3");
            AddBowShootStraight(bowCombatAnimations, "combat/pBOW3");
            EditorUtility.SetDirty(bowCombatAnimations);
        }

        #region Combat Animations

        private static void AddCombatIdle(SO_AnimationSettings animations, string animPage, Dictionary<AnimDirection, int[]> loMainhand = null, Dictionary<AnimDirection, int[]> loOffhand = null)
        {
            string animKey = "idle";

            if (loMainhand == null)
            {
                loMainhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down,  new int[] { 7, 7, 7, 7, 7 }},
                    {AnimDirection.up,  new int[] { 0, 0, 0, 0, 0 }},
                    {AnimDirection.right,  new int[] { 7, 7, 7, 7, 7 }},
                    {AnimDirection.left,  new int[] { 7, 7, 7, 7, 7 }}
                };
            }

            if (loOffhand == null)
            {
                loOffhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down, new int[] { 8, 8, 8, 8, 8 }},
                    {AnimDirection.up,  new int[] { -1, -1, -1, -1, -1 }},
                    {AnimDirection.right,  new int[] { 0, 0, 0, 0, 0 }},
                    {AnimDirection.left,  new int[] { 0, 0, 0, 0, 0 }}
                };
            }

            float[] keyTimer = new float[] { 0f, 0.18f, 0.24f, 0.3f, 0.4f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 0, 1, 2, 3, 3 }, false, loMainhand[direction], loOffhand[direction]);
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 8, 9, 10, 11, 11 }, false, loMainhand[direction], loOffhand[direction]);
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 16, 17, 18, 19, 19 }, false, loMainhand[direction], loOffhand[direction]);
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 24, 25, 26, 27, 27 }, false, loMainhand[direction], loOffhand[direction]);
                        break;
                }
            }
        }

        private static void AddCombatMove(SO_AnimationSettings animations, string animPage, Dictionary<AnimDirection, int[]> loMainhand = null, Dictionary<AnimDirection, int[]> loOffhand = null)
        {
            string animKey = "move";

            if (loMainhand == null)
            {
                loMainhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down,  new int[] { 7, 7, 7, 7, 7 }},
                    {AnimDirection.up,  new int[] { 0, 0, 0, 0, 0 }},
                    {AnimDirection.right,  new int[] { 7, 7, 7, 7, 7 }},
                    {AnimDirection.left,  new int[] { 7, 7, 7, 7, 7 }}
                };
            }

            if (loOffhand == null)
            {
                loOffhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down, new int[] { 8, 8, 8, 8, 8 }},
                    {AnimDirection.up,  new int[] { -1, -1, -1, -1, -1 }},
                    {AnimDirection.right,  new int[] { 0, 0, 0, 0, 0 }},
                    {AnimDirection.left,  new int[] { 0, 0, 0, 0, 0 }}
                };
            }

            float[] keyTimer = new float[] { 0f, 0.18f, 0.24f, 0.3f, 0.4f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 4, 5, 6, 7, 7 }, false, loMainhand[direction], loOffhand[direction]);
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 12, 13, 14, 15, 15 }, false, loMainhand[direction], loOffhand[direction]);
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 20, 21, 22, 23, 23 }, false, loMainhand[direction], loOffhand[direction]);
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 28, 29, 30, 31, 31 }, false, loMainhand[direction], loOffhand[direction]);
                        break;
                }
            }
        }

        private static void AddCombatDraw(SO_AnimationSettings animations, string animPage, Dictionary<AnimDirection, int[]> loMainhand = null, Dictionary<AnimDirection, int[]> loOffhand = null)
        {
            string animKey = "draw";
            if (loMainhand == null)
            {
                loMainhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down,  new int[] { 0, 7, 0, 0 }},
                    {AnimDirection.up,  new int[] { 7, 0, 0, 0 }},
                    {AnimDirection.right,  new int[] { 0, 7, 7, 7 }},
                    {AnimDirection.left,  new int[] { 0, 7, 7, 7 }}
                };
            }

            if (loOffhand == null)
            {
                loOffhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down, new int[] { -1, -1, -1, -1 }},
                    {AnimDirection.up,  new int[] { 8, -1, 7, 7 }},
                    {AnimDirection.right,  new int[] { -1, 0, 0, 0 }},
                    {AnimDirection.left,  new int[] { -1, 0, 0, 0 }}
                };
            }

            float[] keyTimer = new float[] { 0f, 0.18f, 0.24f, 0.3f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 0, 1, 2, 2 }, false, loMainhand[direction], loOffhand[direction]);
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 8, 9, 10, 10 }, false, loMainhand[direction], loOffhand[direction]);
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 16, 17, 18, 18 }, false, loMainhand[direction], loOffhand[direction]);
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 24, 25, 26, 26 }, false, loMainhand[direction], loOffhand[direction]);
                        break;
                }
            }
        }

        private static void AddCombatSheath(SO_AnimationSettings animations, string animPage, Dictionary<AnimDirection, int[]> loMainhand = null, Dictionary<AnimDirection, int[]> loOffhand = null)
        {
            string animKey = "sheath";

            if (loMainhand == null)
            {
                loMainhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down,  new int[] { 0, 7, 0, 0 }},
                    {AnimDirection.up,  new int[] { 0, 0, 7, 7 }},
                    {AnimDirection.right,  new int[] { 7, 7, 0, 0 }},
                    {AnimDirection.left,  new int[] { 7, 7, 0, 0 }}
                };
            }

            if (loOffhand == null)
            {
                loOffhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down, new int[] { -1, 8, -1, -1 }},
                    {AnimDirection.up, new int[] { 7, -1, 8, 8 }},
                    {AnimDirection.right, new int[] { 0, 0, -1, -1 }},
                    {AnimDirection.left, new int[] { 0, 0, -1, -1 }}
                };
            }

            float[] keyTimer = new float[] { 0f, 0.18f, 0.24f, 0.3f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 2, 1, 0, 0 }, false, loMainhand[direction], loOffhand[direction]);
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 10, 9, 8, 8 }, false, loMainhand[direction], loOffhand[direction]);
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 18, 17, 16, 16 }, false, loMainhand[direction], loOffhand[direction]);
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 26, 25, 24, 24 }, false, loMainhand[direction], loOffhand[direction]);
                        break;
                }
            }
        }

        private static void AddCombatParry(SO_AnimationSettings animations, string animPage, Dictionary<AnimDirection, int[]> loMainhand = null, Dictionary<AnimDirection, int[]> loOffhand = null)
        {
            string animKey = "parry";

            if (loMainhand == null)
            {
                loMainhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down,  new int[] {7 }},
                    {AnimDirection.up,  new int[] { 0 }},
                    {AnimDirection.right,  new int[] { 0 }},
                    {AnimDirection.left,  new int[] { 0 }}
                };
            }

            if (loOffhand == null)
            {
                loOffhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down, new int[] { 0 }},
                    {AnimDirection.up, new int[] { 8 }},
                    {AnimDirection.right, new int[] { 8 }},
                    {AnimDirection.left, new int[] { 8 }}
                };
            }

            float[] keyTimer = new float[] { 0f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 3 }, false, loMainhand[direction], loOffhand[direction]);
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 11 }, false, loMainhand[direction], loOffhand[direction]);
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 19 }, false, loMainhand[direction], loOffhand[direction]);
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 27 }, false, loMainhand[direction], loOffhand[direction]);
                        break;
                }
            }
        }

        private static void AddCombatDodge(SO_AnimationSettings animations, string animPage, Dictionary<AnimDirection, int[]> loMainhand = null, Dictionary<AnimDirection, int[]> loOffhand = null)
        {
            string animKey = "dodge";

            if (loMainhand == null)
            {
                loMainhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down,  new int[] {7 }},
                    {AnimDirection.up,  new int[] { 0 }},
                    {AnimDirection.right,  new int[] { 8 }},
                    {AnimDirection.left,  new int[] { 8 }}
                };
            }

            if (loOffhand == null)
            {
                loOffhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down, new int[] { 8 }},
                    {AnimDirection.up, new int[] { -1 }},
                    {AnimDirection.right, new int[] { 0 }},
                    {AnimDirection.left, new int[] { 0 }}
                };
            }

            float[] keyTimer = new float[] { 0f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 4 }, false, loMainhand[direction], loOffhand[direction]);
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 12 }, false, loMainhand[direction], loOffhand[direction]);
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 20 }, false, loMainhand[direction], loOffhand[direction]);
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 28 }, false, loMainhand[direction], loOffhand[direction]);
                        break;
                }
            }
        }

        private static void AddCombatHurt(SO_AnimationSettings animations, string animPage, Dictionary<AnimDirection, int[]> loMainhand = null, Dictionary<AnimDirection, int[]> loOffhand = null)
        {
            string animKey = "hurt";

            if (loMainhand == null)
            {
                loMainhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down,  new int[] {7 }},
                    {AnimDirection.up,  new int[] { 0 }},
                    {AnimDirection.right,  new int[] { 7 }},
                    {AnimDirection.left,  new int[] { 7 }}
                };
            }

            if (loOffhand == null)
            {
                loOffhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down, new int[] { 0 }},
                    {AnimDirection.up, new int[] { 8 }},
                    {AnimDirection.right, new int[] { 0 }},
                    {AnimDirection.left, new int[] { 0 }}
                };
            }

            float[] keyTimer = new float[] { 0f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 5 }, false, loMainhand[direction], loOffhand[direction]);
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 13 }, false, loMainhand[direction], loOffhand[direction]);
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 21 }, false, loMainhand[direction], loOffhand[direction]);
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 29 }, false, loMainhand[direction], loOffhand[direction]);
                        break;
                }
            }
        }

        private static void AddCombatDead(SO_AnimationSettings animations, string animPage, Dictionary<AnimDirection, int[]> loMainhand = null, Dictionary<AnimDirection, int[]> loOffhand = null)
        {
            string animKey = "dead";

            if (loMainhand == null)
            {
                loMainhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down,  new int[] { 0, 0, 0  }},
                    {AnimDirection.up,  new int[] { -1, -1, -1 }},
                    {AnimDirection.right,  new int[] { 0, 0, 0 }},
                    {AnimDirection.left,  new int[] { 0, 0, 0 }}
                };
            }

            if (loOffhand == null)
            {
                loOffhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down, new int[] { -1, -1, -1 }},
                    {AnimDirection.up,  new int[] { 0, 0, 0 }},
                    {AnimDirection.right, new int[] { -1, -1, -1 }},
                    {AnimDirection.left, new int[] { -1, -1, -1 }}
                };
            }

            float[] keyTimer = new float[] { 0f, 0.18f, 0.24f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 6, 7, 7 }, false, loMainhand[direction], loOffhand[direction]);
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 14, 15, 15 }, false, loMainhand[direction], loOffhand[direction]);
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 22, 23, 23 }, false, loMainhand[direction], loOffhand[direction]);
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 30, 31, 31 }, false, loMainhand[direction], loOffhand[direction]);
                        break;
                }
            }
        }

        private static void AddCombatDeadDown(SO_AnimationSettings animations, string animPage, Dictionary<AnimDirection, int[]> loMainhand = null, Dictionary<AnimDirection, int[]> loOffhand = null)
        {
            string animKey = "deaddown";

            if (loMainhand == null)
            {
                loMainhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down,  new int[] {0 }},
                    {AnimDirection.up,  new int[] { -1 }},
                    {AnimDirection.right,  new int[] { 0 }},
                    {AnimDirection.left,  new int[] { 0 }}
                };
            }

            if (loOffhand == null)
            {
                loOffhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down, new int[] { -1 }},
                    {AnimDirection.up, new int[] { 0 }},
                    {AnimDirection.right, new int[] { -1 }},
                    {AnimDirection.left, new int[] { -1 }}
                };
            }

            float[] keyTimer = new float[] { 0f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 7 }, false, loMainhand[direction], loOffhand[direction]);
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 15 }, false, loMainhand[direction], loOffhand[direction]);
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 23 }, false, loMainhand[direction], loOffhand[direction]);
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 31 }, false, loMainhand[direction], loOffhand[direction]);
                        break;
                }
            }
        }

        private static void AddCombatCrouch(SO_AnimationSettings animations, string animPage)
        {
            string animKey = "crouch";

            float[] keyTimer = new float[] { 0f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 32 }, false, new int[] { 7 }, new int[] { 8 });
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 40 }, false, new int[] { 0 }, new int[] { -1 });
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 48 }, false, new int[] { 7 }, new int[] { 0 });
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 56 }, false, new int[] { 7 }, new int[] { 0 });
                        break;
                }
            }
        }

        private static void AddCombatRetreat(SO_AnimationSettings animations, string animPage, Dictionary<AnimDirection, int[]> loMainhand = null, Dictionary<AnimDirection, int[]> loOffhand = null)
        {
            string animKey = "retreat";

            if (loMainhand == null)
            {
                loMainhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down, new int[] { 7, 7, 7, 7 }},
                    {AnimDirection.up, new int[] { 0, 0, 0, 0 }},
                    {AnimDirection.right, new int[] { 7, 7, 7, 7 }},
                    {AnimDirection.left, new int[] { 7, 7, 7, 7 }}
                };
            }

            if (loOffhand == null)
            {
                loOffhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down, new int[] { 8, 8, 8, 8 }},
                    {AnimDirection.up, new int[] { -1, -1, -1, -1 }},
                    {AnimDirection.right, new int[] { 0, 0, 0, 0 }},
                    {AnimDirection.left, new int[] { 0, 0, 0, 7 }}
                };
            }

            float[] keyTimer = new float[] { 0f, 0.18f, 0.3f, 0.35f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 32, 33, 32, 32 }, false, loMainhand[direction], loOffhand[direction]);
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 40, 41, 40, 40 }, false, loMainhand[direction], loOffhand[direction]);
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 48, 49, 48, 48 }, false, loMainhand[direction], loOffhand[direction]);
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 56, 57, 56, 56 }, false, loMainhand[direction], loOffhand[direction]);
                        break;
                }
            }
        }

        private static void AddCombatLunge(SO_AnimationSettings animations, string animPage, Dictionary<AnimDirection, int[]> loMainhand = null, Dictionary<AnimDirection, int[]> loOffhand = null)
        {
            string animKey = "lunge";

            if (loMainhand == null)
            {
                loMainhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down, new int[] { 7, 7, 7, 7 }},
                    {AnimDirection.up, new int[] { 0, 0, 0, 0 }},
                    {AnimDirection.right, new int[] { 7, 7, 7, 7 }},
                    {AnimDirection.left, new int[] { 7, 7, 7, 7 }}
                };
            }

            if (loOffhand == null)
            {
                loOffhand = new Dictionary<AnimDirection, int[]>
                {
                    {AnimDirection.down, new int[] { 8, 8, 8, 8 }},
                    {AnimDirection.up, new int[] { -1, -1, -1, -1 }},
                    {AnimDirection.right, new int[] { 0, 0, 0, 0 }},
                    {AnimDirection.left, new int[] { 0, 0, 0, 0 }}
                };
            }

            float[] keyTimer = new float[] { 0f, 0.18f, 0.3f, 0.35f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 32, 34, 32, 32 }, false, loMainhand[direction], loOffhand[direction]);
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 40, 42, 40, 40 }, false, loMainhand[direction], loOffhand[direction]);
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 48, 50, 48, 48 }, false, loMainhand[direction], loOffhand[direction]);
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 56, 58, 56, 56 }, false, loMainhand[direction], loOffhand[direction]);
                        break;
                }
            }
        }

        private static void AddCombatSlash1(SO_AnimationSettings animations, string animPage)
        {
            string animKey = "slash1";

            float[] keyTimer = new float[] { 0f, 0.18f, 0.24f, 0.3f, 0.4f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 0, 1, 2, 3, 3 }, false, new int[] { 0, 0, 0, 0, 0 }, new int[] { 7, 0, 0, 0, 0 });
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 8, 9, 10, 11, 11 }, false, new int[] { 0, 0, 0, 0, 0 }, new int[] { -1, -1, 7, 7, -1 });
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 16, 17, 18, 19, 19 }, false, new int[] { 0, 7, 0, 0, 0 }, new int[] { -1, 0, -1, -1, -1 });
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 24, 25, 26, 27, 27 }, false, new int[] { 0, 7, -1, -1, 0 }, new int[] { -1, 0, 0, 0, -1 });
                        break;
                }
            }
        }

        private static void AddCombatSlash2(SO_AnimationSettings animations, string animPage)
        {
            string animKey = "slash2";

            float[] keyTimer = new float[] { 0f, 0.18f, 0.24f, 0.3f, 0.4f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 4, 5, 6, 7, 7 }, false, new int[] { 0, 0, 0, 0, 0 }, new int[] { -1, 0, 8, 8, 8 });
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 12, 13, 14, 15, 15 }, false, new int[] { 0, 0, 0, 0, 0 }, new int[] { 8, 8, -1, -1, -1 });
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 20, 21, 22, 23, 23 }, false, new int[] { 0, 0, 0, 0, 0 }, new int[] { -1, 0, 0, -1, -1 });
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 28, 29, 30, 31, 31 }, false, new int[] { 0, 0, 0, 0, 0 }, new int[] { -1, -1, -1, -1, -1 });
                        break;
                }
            }
        }

        #endregion Combat Animations

        #region Bow

        private static void AddBowShootUp(SO_AnimationSettings animations, string animPage)
        {
            string animKey = "shootup";

            Dictionary<AnimDirection, int[]> loMainhand = new Dictionary<AnimDirection, int[]>()
            {
                { AnimDirection.down, new int[] { 7, 7, 7, 7, 7, 7, 7, 7, 7 } },
                { AnimDirection.up, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 } },
                { AnimDirection.right, new int[] { 0, 7, 7, 7, 7, 7, 7, 7, 7 } },
                { AnimDirection.left, new int[] { 0, 7, 7, 7, 7, 7, 7, 7, 7 } }
            };
            Dictionary<AnimDirection, int[]> loOffhand = new Dictionary<AnimDirection, int[]>()
            {
                { AnimDirection.down, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 } },
                { AnimDirection.up, new int[] { 8, 8, 8, 8, 8, 8, 8, 8, 8 } },
                { AnimDirection.right, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 } },
                { AnimDirection.left, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 } }
            };

            float[] keyTimer = new float[] { 0f, 0.18f, 0.24f, 0.3f, 0.4f, 0.5f, 0.55f, 0.72f, 1.3f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 7 }, false, loMainhand[direction], loOffhand[direction]);
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 8, 9, 10, 11, 12, 13, 14, 15, 15 }, false, loMainhand[direction], loOffhand[direction]);
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 16, 17, 18, 19, 20, 21, 22, 23, 23 }, false, loMainhand[direction], loOffhand[direction]);
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 24, 25, 26, 27, 28, 29, 30, 31, 31 }, false, loMainhand[direction], loOffhand[direction]);
                        break;
                }
            }
        }

        private static void AddBowShootStraight(SO_AnimationSettings animations, string animPage)
        {
            string animKey = "shootstraight";

            Dictionary<AnimDirection, int[]> loMainhand = new Dictionary<AnimDirection, int[]>()
            {
                { AnimDirection.down, new int[] { 7, 7, 7, 7, 7, 7, 7, 7, 7 } },
                { AnimDirection.up, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 } },
                { AnimDirection.right, new int[] { 0, 7, 7, 7, 7, 7, 7, 7, 7 } },
                { AnimDirection.left, new int[] { 0, 7, 7, 7, 7, 7, 7, 7, 7 } }
            };
            Dictionary<AnimDirection, int[]> loOffhand = new Dictionary<AnimDirection, int[]>()
            {
                { AnimDirection.down, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 } },
                { AnimDirection.up, new int[] { 8, 8, 8, 8, 8, 8, 8, 8, 8 } },
                { AnimDirection.right, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 } },
                { AnimDirection.left, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 } }
            };

            float[] keyTimer = new float[] { 0f, 0.18f, 0.24f, 0.3f, 0.4f, 0.5f, 0.55f, 0.72f, 1.3f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 32, 33, 34, 35, 36, 37, 38, 39, 39 }, false, loMainhand[direction], loOffhand[direction]);
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 40, 41, 42, 43, 44, 45, 46, 47, 47 }, false, loMainhand[direction], loOffhand[direction]);
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 48, 49, 50, 51, 52, 53, 54, 55, 55 }, false, loMainhand[direction], loOffhand[direction]);
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 56, 57, 58, 59, 60, 61, 62, 63, 63 }, false, loMainhand[direction], loOffhand[direction]);
                        break;
                }
            }
        }

        #endregion Bow

        #region Spear

        private static void AddSpearSlash1(SO_AnimationSettings animations, string animPage)
        {
            string animKey = "slash1";

            float[] keyTimer = new float[] { 0f, 0.18f, 0.24f, 0.3f, 0.4f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 0, 1, 2, 3, 3 }, false, new int[] { 0, 0, 0, 0, 0 });
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 8, 9, 10, 11, 11 }, false, new int[] { 7, 0, 0, 0, 0 });
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 16, 17, 18, 19, 19 }, false, new int[] { 0, 0, 7, 7, 7 });
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 24, 25, 26, 27, 27 }, false, new int[] { 0, 0, 7, 7, 7 });
                        break;
                }
            }
        }

        private static void AddSpearThrust(SO_AnimationSettings animations, string animPage)
        {
            string animKey = "thrust";

            float[] keyTimer = new float[] { 0f, 0.18f, 0.24f, 0.3f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 32, 33, 34, 34 }, false, new int[] { 7, 7, 7, 7 });
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 40, 41, 42, 42 }, false, new int[] { 7, 0, 0, 0 });
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 48, 49, 50, 50 }, false, new int[] { 7, 7, 7, 7 });
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 56, 57, 58, 58 }, false, new int[] { 7, 7, 7, 7 });
                        break;
                }
            }
        }

        private static void AddSpearThrust2(SO_AnimationSettings animations, string animPage)
        {
            string animKey = "thrust2";

            float[] keyTimer = new float[] { 0f, 0.18f, 0.24f, 0.3f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 35, 36, 37, 37 }, false, new int[] { 7, 7, 7, 7 });
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 43, 44, 45, 45 }, false, new int[] { 7, 0, 0, 0 });
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 51, 52, 53, 53 }, false, new int[] { 7, 7, 7, 7 });
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 59, 60, 61, 61 }, false, new int[] { 7, 7, 7, 7 });
                        break;
                }
            }
        }

        #endregion Spear

        #region Sword and Shield

        private static void AddSwordAndShieldThrust(SO_AnimationSettings animations, string animPage)
        {
            string animKey = "thrust";

            float[] keyTimer = new float[] { 0f, 0.18f, 0.24f, 0.3f, 0.4f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 32, 33, 34, 35, 35 }, false, new int[] { 7, 7, 0, 0, 0 }, new int[] { 8, 0, -1, -1, -1 });
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 40, 41, 42, 43, 43 }, false, new int[] { 0, 0, 0, 0, 0 }, new int[] { -1, -1, 0, 0, 0 });
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 48, 49, 50, 51, 51 }, false, new int[] { 7, 7, 0, 0, 0 }, new int[] { 0, 0, -1, -1, -1 });
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 56, 57, 58, 59, 59 }, false, new int[] { 7, 7, 0, 0, 0 }, new int[] { 0, 0, -1, -1, -1 });
                        break;
                }
            }
        }

        private static void AddSwordAndShieldShieldbash(SO_AnimationSettings animations, string animPage)
        {
            string animKey = "shieldbash";

            float[] keyTimer = new float[] { 0f, 0.18f, 0.24f, 0.3f, 0.4f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 36, 37, 38, 39, 39 }, false, new int[] { 0, 0, 0, 0, 0 }, new int[] { 8, 8, -1, -1, -1 });
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 44, 45, 46, 47, 47 }, false, new int[] { 0, 0, 0, 0, 0 }, new int[] { -1, -1, 1, 8, 8 });
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 52, 53, 54, 55, 55 }, false, new int[] { 7, 7, 7, 7, 7 }, new int[] { 6, 0, 0, 0, 0 });
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, animKey, direction.ToString(), animPage, keyTimer, new int[] { 60, 61, 62, 63, 63 }, false, new int[] { 7, 7, 7, 7, 7 }, new int[] { 6, 0, 0, 0, 0 });
                        break;
                }
            }
        }

        #endregion Sword and Shield

        #region CharacterBase Animations

        private static void AddToeTapping(SO_AnimationSettings animations)
        {
            //toetapping 4 P3 0/0,3/1,1                  33,34         41,42            49,50             57,58
            float[] keyTimer = new float[] { 0f, 0.2f, 0.4f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, "toetapping", direction.ToString(), "p4", keyTimer, new int[] { 33, 34, 33 }, false, new int[] { 0, 0, 0 });
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, "toetapping", direction.ToString(), "p4", keyTimer, new int[] { 41, 42, 41 });
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, "toetapping", direction.ToString(), "p4", keyTimer, new int[] { 49, 50, 49 });
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, "toetapping", direction.ToString(), "p4", keyTimer, new int[] { 57, 58, 57 });
                        break;
                }
            }
        }

        private static void AddSittingGround(SO_AnimationSettings animations)
        {
            //sittingground 4 P4 0   down 37   up 45   right 53   left 61
            float[] keyTimer = new float[] { 0f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, "sittingground", direction.ToString(), "p4", keyTimer, new int[] { 37 });
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, "sittingground", direction.ToString(), "p4", keyTimer, new int[] { 45 }, false, new int[] { 0 });
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, "sittingground", direction.ToString(), "p4", keyTimer, new int[] { 53 });
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, "sittingground", direction.ToString(), "p4", keyTimer, new int[] { 61 });
                        break;
                }
            }
            //sittingground2 4 P4 0   down 38   up 46   right 54   left 62
            keyTimer = new float[] { 0f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, "sittingground2", direction.ToString(), "p4", keyTimer, new int[] { 38 });
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, "sittingground2", direction.ToString(), "p4", keyTimer, new int[] { 46 }, false, new int[] { 0 });
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, "sittingground2", direction.ToString(), "p4", keyTimer, new int[] { 54 });
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, "sittingground2", direction.ToString(), "p4", keyTimer, new int[] { 62 });
                        break;
                }
            }
        }

        private static void AddSittingStool(SO_AnimationSettings animations)
        {
            //sittingstool 4 P4 0   down 35   up 43   right 51   left 59
            float[] keyTimer = new float[] { 0f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, "sittingstool", direction.ToString(), "p4", keyTimer, new int[] { 35 });
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, "sittingstool", direction.ToString(), "p4", keyTimer, new int[] { 43 }, false, new int[] { 0 });
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, "sittingstool", direction.ToString(), "p4", keyTimer, new int[] { 51 });
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, "sittingstool", direction.ToString(), "p4", keyTimer, new int[] { 59 });
                        break;
                }
            }
            //sittingstoolasleep 4 P4 0   down 36   up 44   right 52   left 60
            keyTimer = new float[] { 0f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, "sittingstoolasleep", direction.ToString(), "p4", keyTimer, new int[] { 36 });
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, "sittingstoolasleep", direction.ToString(), "p4", keyTimer, new int[] { 44 }, false, new int[] { 0 });
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, "sittingstoolasleep", direction.ToString(), "p4", keyTimer, new int[] { 52 });
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, "sittingstoolasleep", direction.ToString(), "p4", keyTimer, new int[] { 60 });
                        break;
                }
            }
            //sittingstooldrinking 1 P4 0/0,3/1   left 27,28,27
            keyTimer = new float[] { 0f, 0.3f, 1f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.left:
                        AddMSCAnimation(animations, "sittingstooldrinking", direction.ToString(), "p4", keyTimer, new int[] { 27, 28, 29 });
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, "sittingstooldrinking", direction.ToString(), "p4", keyTimer, new int[] { 27, 28, 29 }, true);
                        break;
                }
            }
        }

        private static void AddSideglance(SO_AnimationSettings animations)
        {
            //sideglance 4 P4 0   right 25   left 26
            float[] keyTimer = new float[] { 0f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.right:
                        AddMSCAnimation(animations, "sideglance", direction.ToString(), "p4", keyTimer, new int[] { 25 });
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, "sideglance", direction.ToString(), "p4", keyTimer, new int[] { 26 });
                        break;
                }
            }
        }

        private static void AddIdle2(SO_AnimationSettings animations)
        {
            //idle2 4 P4 0   down 32   up 40   right 48   left 56
            float[] keyTimer = new float[] { 0f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, "idle2", direction.ToString(), "p4", keyTimer, new int[] { 32 }, false, new int[] { 0 });
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, "idle2", direction.ToString(), "p4", keyTimer, new int[] { 40 });
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, "idle2", direction.ToString(), "p4", keyTimer, new int[] { 48 }, false, new int[] { 0 });
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, "idle2", direction.ToString(), "p4", keyTimer, new int[] { 56 }, false, new int[] { 0 });
                        break;
                }
            }
        }

        private static void AddSchock(SO_AnimationSettings animations)
        {
            //schock P4  24
            AddMSCAnimation(animations, "schock", "down", "p4", new float[] { 0f }, new int[] { 24 });
        }

        private static void AddSleep(SO_AnimationSettings animations)
        {
            //sleep 4 P4 0   down 39   up 47   right 55   left 63
            float[] keyTimer = new float[] { 0f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, "sleep", direction.ToString(), "p4", keyTimer, new int[] { 39 });
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, "sleep", direction.ToString(), "p4", keyTimer, new int[] { 47 });
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, "sleep", direction.ToString(), "p4", keyTimer, new int[] { 55 });
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, "sleep", direction.ToString(), "p4", keyTimer, new int[] { 63 });
                        break;
                }
            }
        }

        private static void AddWater(SO_AnimationSettings animations)
        {
            //water 4 P2 0/0,3/0,47/1/1,3   down 32,33,34,35   up 40,41,42,43   right 48,49,50,51   left 56,57,58,59
            float[] keyTimer = new float[] { 0f, 0.3f, 0.47f, 1f, 1.3f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, "water", direction.ToString(), "p2", keyTimer, new int[] { 32, 33, 34, 35, 35 });
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, "water", direction.ToString(), "p2", keyTimer, new int[] { 40, 41, 42, 43, 43 }, false, new int[] { 0, 0, 0, 0, 0 });
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, "water", direction.ToString(), "p2", keyTimer, new int[] { 48, 49, 50, 51, 51 });
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, "water", direction.ToString(), "p2", keyTimer, new int[] { 56, 57, 58, 59, 59 });
                        break;
                }
            }
        }

        private static void AddWalk(SO_AnimationSettings animations)
        {
            //walk 4 P1 0/0,1/0,2/0,3/0,4/0,5/0,6   down 32,33,34,35,36,37   up 40,41,42,43,44,45   right 48,49,50,51,52,53    left 56,57,58,59,60,61
            float[] keyTimer = new float[] { 0f, 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, "walk", direction.ToString(), "p1", keyTimer, new int[] { 32, 33, 34, 35, 36, 37, 37 }, false, new int[] { 0, 0, 0, 0, 0, 0, 0 });
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, "walk", direction.ToString(), "p1", keyTimer, new int[] { 40, 41, 42, 43, 44, 45, 45 });
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, "walk", direction.ToString(), "p1", keyTimer, new int[] { 48, 49, 50, 51, 52, 53, 53 }, false, new int[] { 0, 0, 0, 0, 0, 0, 0 });
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, "walk", direction.ToString(), "p1", keyTimer, new int[] { 56, 57, 58, 59, 60, 61, 61 }, false, new int[] { 0, 0, 0, 0, 0, 0, 0 });
                        break;
                }
            }
        }

        private static void AddThrowing(SO_AnimationSettings animations)
        {
            //throwing 4 P2 0/0,3/0,4/0,5/1   down 4,5,6,7   up 12,13,14,15   right 20,21,22,23   left 28,29,30,31
            float[] keyTimer = new float[] { 0f, 0.3f, 0.4f, 0.5f, 1f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, "throwing", direction.ToString(), "p2", keyTimer, new int[] { 4, 5, 6, 7, 7 });
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, "throwing", direction.ToString(), "p2", keyTimer, new int[] { 12, 13, 14, 15, 15 }, false, new int[] { 0, 0, 0, 0, 0 });
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, "throwing", direction.ToString(), "p2", keyTimer, new int[] { 20, 21, 22, 23, 23 });
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, "throwing", direction.ToString(), "p2", keyTimer, new int[] { 28, 29, 30, 31, 31 });
                        break;
                }
            }
        }

        private static void AddRun(SO_AnimationSettings animations)
        {
            //run 4 P1 0/0,08/0,13/0,23/0,31/0,36/0,45   down 32,33,38,35,36,39   up 40,41,46,43,44,47   right 48,49,54,51,52,55   left 56,57,62,59,60,63
            float[] keyTimer = new float[] { 0f, 0.08f, 0.13f, 0.23f, 0.31f, 0.36f, 0.45f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, "run", direction.ToString(), "p1", keyTimer, new int[] { 32, 33, 38, 35, 36, 39, 39 }, false, new int[] { 0, 0, 0, 0, 0, 0, 0 });
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, "run", direction.ToString(), "p1", keyTimer, new int[] { 40, 41, 46, 43, 44, 47, 47 });
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, "run", direction.ToString(), "p1", keyTimer, new int[] { 48, 49, 54, 51, 52, 55, 55 }, false, new int[] { 0, 0, 0, 0, 0, 0, 0 });
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, "run", direction.ToString(), "p1", keyTimer, new int[] { 56, 57, 62, 59, 60, 63, 63 }, false, new int[] { 0, 0, 0, 0, 0, 0, 0 });
                        break;
                }
            }
        }

        private static void AddPush(SO_AnimationSettings animations)
        {
            //push 4 P1 0/0,3/1   down 1,2,1    up 9,10,9    right 17,18,17   left 25,26,25
            float[] keyTimer = new float[] { 0f, 0.3f, 1f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, "push", direction.ToString(), "p1", keyTimer, new int[] { 1, 2, 1 }, false, new int[] { 0, 0, 0 });
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, "push", direction.ToString(), "p1", keyTimer, new int[] { 9, 10, 9 });
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, "push", direction.ToString(), "p1", keyTimer, new int[] { 17, 18, 17 });
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, "push", direction.ToString(), "p1", keyTimer, new int[] { 25, 26, 25 });
                        break;
                }
            }
        }

        private static void AddPull(SO_AnimationSettings animations)
        {
            //pull 4 P1 0/0,4/1,1   down 3,4,3   up 11,12,11   right 19,20,19   left 27,28,27
            float[] keyTimer = new float[] { 0f, 0.4f, 1.1f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, "pull", direction.ToString(), "p1", keyTimer, new int[] { 3, 4, 3 }, false, new int[] { 0, 0, 0 });
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, "pull", direction.ToString(), "p1", keyTimer, new int[] { 11, 12, 11 });
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, "pull", direction.ToString(), "p1", keyTimer, new int[] { 19, 20, 19 });
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, "pull", direction.ToString(), "p1", keyTimer, new int[] { 27, 28, 27 });
                        break;
                }
            }
        }

        private static void AddLift(SO_AnimationSettings animations)
        {
            //lift 4 P2 0/0,3/0,47/1/1,3  down 36,37,38,39   up 44,45,46,47   right 52,53,54,55    left 60,61,62,63
            float[] keyTimer = new float[] { 0f, 0.3f, 0.47f, 1f, 1.3f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, "lift", direction.ToString(), "p2", keyTimer, new int[] { 36, 37, 38, 39, 39 }, false, new int[] { 0, 0, 0, 0, 0 });
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, "lift", direction.ToString(), "p2", keyTimer, new int[] { 44, 45, 46, 47, 47 });
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, "lift", direction.ToString(), "p2", keyTimer, new int[] { 52, 53, 54, 55, 55 });
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, "lift", direction.ToString(), "p2", keyTimer, new int[] { 60, 61, 62, 63, 63 });
                        break;
                }
            }
        }

        private static void AddJump(SO_AnimationSettings animations)
        {
            //jump 4 P1 0/0,2/0,3/0,55  down 5,6,7,5   up 13,14,15,13   right 21,22,23,21   left 29,30,31,29
            float[] keyTimer = new float[] { 0f, 0.2f, 0.3f, 0.55f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, "jump", direction.ToString(), "p1", keyTimer, new int[] { 5, 6, 7, 5 }, false, new int[] { 0, 0, 7, 0 });
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, "jump", direction.ToString(), "p1", keyTimer, new int[] { 13, 14, 15, 13 }, false, new int[] { 0, 0, 0, 0 });
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, "jump", direction.ToString(), "p1", keyTimer, new int[] { 21, 22, 23, 21 }, false, new int[] { 0, 0, 0, 0 });
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, "jump", direction.ToString(), "p1", keyTimer, new int[] { 29, 30, 31, 29 }, false, new int[] { 0, 0, 0, 0 });
                        break;
                }
            }
        }

        private static void AddIdle(SO_AnimationSettings animations)
        {
            //idle 4 P1 down 0   up 8   right 16   left 24
            float[] keyTimer = new float[] { 0f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, "idle", direction.ToString(), "p1", keyTimer, new int[] { 0 }, false, new int[] { 0 });
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, "idle", direction.ToString(), "p1", keyTimer, new int[] { 8 });
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, "idle", direction.ToString(), "p1", keyTimer, new int[] { 16 }, false, new int[] { 0 });
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, "idle", direction.ToString(), "p1", keyTimer, new int[] { 24 }, false, new int[] { 0 });
                        break;
                }
            }
        }

        private static void AddHacking(SO_AnimationSettings animations)
        {
            //hack 4 P2 0/0.18/0,24/0,30/0,40  down 0,1,2,3   up 8,9,10,11   right 16,17,18,19   left 24,25,26,27
            float[] keyTimer = new float[] { 0f, 0.18f, 0.24f, 0.3f, 0.4f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, "hack", direction.ToString(), "p2", keyTimer, new int[] { 0, 1, 2, 3, 3 });
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, "hack", direction.ToString(), "p2", keyTimer, new int[] { 8, 9, 10, 11, 11 }, false, new int[] { 0, 0, 0, 0, 0 });
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, "hack", direction.ToString(), "p2", keyTimer, new int[] { 16, 17, 18, 19, 19 });
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, "hack", direction.ToString(), "p2", keyTimer, new int[] { 24, 25, 26, 27, 27 });
                        break;
                }
            }
        }

        private static void AddFishing(SO_AnimationSettings animations)
        {
            //fishingcast 4 P3 0/0,18/0,28/0,46/1,2  down 0,1,2,3  up 8,9,10,11  right 16,23,17,18  left 32,33,25,26
            float[] keyTimer = new float[] { 0f, 0.18f, 0.28f, 0.46f, 1.2f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, "fishing", "cast" + direction.ToString(), "p3", keyTimer, new int[] { 0, 1, 2, 3, 3 });
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, "fishing", "cast" + direction.ToString(), "p3", keyTimer, new int[] { 8, 9, 10, 11, 11 });
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, "fishing", "cast" + direction.ToString(), "p3", keyTimer, new int[] { 16, 23, 17, 18, 18 });
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, "fishing", "cast" + direction.ToString(), "p3", keyTimer, new int[] { 32, 33, 25, 26, 26 });
                        break;
                }
            }
            //fishingreel 4 P3 0/0,3/1                    4,5,4       12,13,12         21,22,21          29,30,29
            keyTimer = new float[] { 0f, 0.3f, 1f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, "fishing", "reel" + direction.ToString(), "p3", keyTimer, new int[] { 4, 5, 4 });
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, "fishing", "reel" + direction.ToString(), "p3", keyTimer, new int[] { 12, 13, 12 });
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, "fishing", "reel" + direction.ToString(), "p3", keyTimer, new int[] { 21, 22, 21 });
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, "fishing", "reel" + direction.ToString(), "p3", keyTimer, new int[] { 29, 30, 29 });
                        break;
                }
            }
            //fishingshow 4 P3 0/0,3/1,1                  6,7         14,15            24,31             34,35
            keyTimer = new float[] { 0f, 0.3f, 1f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, "fishing", "show" + direction.ToString(), "p3", keyTimer, new int[] { 6, 7, 7 });
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, "fishing", "show" + direction.ToString(), "p3", keyTimer, new int[] { 14, 15, 15 });
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, "fishing", "show" + direction.ToString(), "p3", keyTimer, new int[] { 24, 31, 31 });
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, "fishing", "show" + direction.ToString(), "p3", keyTimer, new int[] { 34, 35, 35 });
                        break;
                }
            }
            //fishingwait 4 P3                            3           11               18                26
            keyTimer = new float[] { 0f };
            foreach (AnimDirection direction in Enum.GetValues(typeof(AnimDirection)))
            {
                switch (direction)
                {
                    case AnimDirection.down:
                        AddMSCAnimation(animations, "fishing", "wait" + direction.ToString(), "p3", keyTimer, new int[] { 3 });
                        break;

                    case AnimDirection.up:
                        AddMSCAnimation(animations, "fishing", "wait" + direction.ToString(), "p3", keyTimer, new int[] { 11 });
                        break;

                    case AnimDirection.right:
                        AddMSCAnimation(animations, "fishing", "wait" + direction.ToString(), "p3", keyTimer, new int[] { 18 });
                        break;

                    case AnimDirection.left:
                        AddMSCAnimation(animations, "fishing", "wait" + direction.ToString(), "p3", keyTimer, new int[] { 26 });
                        break;
                }
            }
        }

        private static void AddCrafting(SO_AnimationSettings animations)
        {
            //smithingleft P4  0/0,15/0,3/0,4/0,6/1,1  8,9,10,11,12
            AddMSCAnimation(animations, "crafting", "smithingleft", "p4", new float[] { 0f, 0.15f, 0.3f, 0.4f, 0.6f, 1.1f }, new int[] { 8, 9, 10, 11, 12, 12 });
            //smithingright P4 0/0,15/0,3/0,4/0,6/1,1  0,1,2,3,4
            AddMSCAnimation(animations, "crafting", "smithingright", "p4", new float[] { 0f, 0.15f, 0.3f, 0.4f, 0.6f, 1.1f }, new int[] { 0, 1, 2, 3, 4, 4 });
        }

        private static void AddClimbing(SO_AnimationSettings animations)
        {
            //climbstandup P4  20
            AddMSCAnimation(animations, "climb", "standup", "p4", new float[] { 0f }, new int[] { 20 }, false, new int[] { 0 });
            //climbup P4 0/0,12/0,23/0,35/0,47/0,58/1,1  16,17,18,19,18,17,16
            AddMSCAnimation(animations, "climb", "up", "p4", new float[] { 0f, 0.12f, 0.23f, 0.35f, 0.47f, 0.58f, 1.1f }, new int[] { 16, 17, 18, 19, 18, 17, 16 }, false, new int[] { 0, 0, 0, 0, 0, 0, 0 });
        }

        #endregion CharacterBase Animations

        private static void AddMSCAnimation(SO_AnimationSettings animations, string layer, string name, string page, float[] keyTimer, int[] keys, bool xFlip = false, int[] pritoolLayer = null, int[] sectoolLayer = null)
        {
            MSCAnimation temp = new MSCAnimation()
            {
                animationType = layer,
                animationName = name,
                spritePage = page,
                keyTimer = keyTimer,
                keys = keys,
                xFlip = xFlip,
                pritoolLayerKeys = pritoolLayer,
                sectoolLayerKeys = sectoolLayer
            };
            animations.list.Add(temp);
        }
    }
}