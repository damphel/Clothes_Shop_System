using UnityEngine;
using UnityEditor;
using System;
using UnityEditor.Animations;
using System.Collections.Generic;
using System.IO;

namespace ManaSeedTools.CharacterAnimator
{
    public enum AnimDirection
    {
        right,
        left,
        up,
        down
    }

    public class MSCUnityEditor : EditorWindow
    {
        private float _space = 5f;

        private string spritePath = "Sprites/Character/Spritesheets/";
        private string spriteSavePath = "Sprites/Character/Spritesheets/";
        private string animationControllerPath = "Animations/Player/AnimationController/";
        private string animationControllerSavePath = "Animations/Player/AnimationController/";
        private string animationPath = "Animations/Player/Animations/";
        private string animationSavePath = "Animations/Player/Animations/";

        private string preslicedSprite_p1;
        private string preslicedSprite_p3;

        private DefaultAsset spriteFolder = null;
        private DefaultAsset animationFolder = null;
        private DefaultAsset animationControllerFolder = null;

        private GameObject playerPrefab = null;
        private AnimatorController baseAnimController = null;

        private static float keyTimerModifier = 100f / 60f;

        //public List<MSCAnimation> animationsList = new List<MSCAnimation>();
        [SerializeField] private SO_AnimationSettings baseAnimations = null;

        [SerializeField] private SO_AnimationSettings swordAndShieldCombatAnimations = null;
        [SerializeField] private SO_AnimationSettings spearCombatAnimations = null;
        [SerializeField] private SO_AnimationSettings bowCombatAnimations = null;

        [SerializeField] private List<string> animationLayers = new List<string>() { "background", "body", "cloak", "faceitems", "hair", "hat", "outfit", "pritool", "sectool", "top" };

        [MenuItem("Tools/MSC Animator")]
        public static void MSCUnityEditorWindow()
        {
            GetWindow<MSCUnityEditor>("ManaSeed Character Animator");
        }

        private void OnGUI()
        {
            preslicedSprite_p1 = AssetDatabase.GetAssetPath((Texture2D)Resources.Load("pre_sliced_sprites/p1_sliced"));
            preslicedSprite_p3 = AssetDatabase.GetAssetPath((Texture2D)Resources.Load("pre_sliced_sprites/p3_sliced"));

            GUILayout.Label("The ManaSeed Character Animator", EditorStyles.largeLabel);
            //Load Button
            if (1 == 0 && GUILayout.Button("Load Predefined Animation Parameters") && baseAnimations != null)
            {
                MSCAnimationSettings.FillBasicMSCAnimations(baseAnimations);
                if (swordAndShieldCombatAnimations != null) MSCAnimationSettings.FillSwordAndShieldMSCAnimations(swordAndShieldCombatAnimations);
                if (spearCombatAnimations != null) MSCAnimationSettings.FillSpearMSCAnimations(spearCombatAnimations);
                if (bowCombatAnimations != null) MSCAnimationSettings.FillBowMSCAnimations(bowCombatAnimations);
            }

            GUILayout.Label("Definitions of the animations to create", EditorStyles.largeLabel);
            GUILayout.Label("Found as Scriptable Object in the AnimationSettings Folder");
            baseAnimations = (SO_AnimationSettings)EditorGUILayout.ObjectField(
                "CharacterBase Animation Settings",
                baseAnimations,
                typeof(SO_AnimationSettings),
                false);
            swordAndShieldCombatAnimations = (SO_AnimationSettings)EditorGUILayout.ObjectField(
                "Sword and Shield Combat Animation Settings",
                swordAndShieldCombatAnimations,
                typeof(SO_AnimationSettings),
                false);
            spearCombatAnimations = (SO_AnimationSettings)EditorGUILayout.ObjectField(
                "Spear Combat Animation Settings",
                spearCombatAnimations,
                typeof(SO_AnimationSettings),
                false);
            bowCombatAnimations = (SO_AnimationSettings)EditorGUILayout.ObjectField(
                "Bow Combat Animation Settings",
                bowCombatAnimations,
                typeof(SO_AnimationSettings),
                false);
            //Animation Layers
            GUILayout.Label("Animations Layer subfolders in the save path for animations");
            ScriptableObject target = this;
            SerializedObject so = new SerializedObject(target);
            SerializedProperty animationLayersProperty = so.FindProperty("animationLayers");
            EditorGUILayout.PropertyField(animationLayersProperty, true); // True means show children
            so.ApplyModifiedProperties(); // Remember to apply modified properties
            GUILayout.Space(_space);
            GUILayout.Label("Folder Paths (they need to be nested in: Assets/Resources)");
            GUILayout.Label("Folder of sliced sprites the character should use");
            //Sprites
            spriteFolder = (DefaultAsset)EditorGUILayout.ObjectField(
                "Character Spritesheets",
                spriteFolder,
                typeof(DefaultAsset),
                false);
            if (spriteFolder != null)
            {
                spriteSavePath = AssetDatabase.GetAssetPath(spriteFolder);
                spritePath = AssetDatabase.GetAssetPath(spriteFolder).Replace("Assets/Resources/", "");
                EditorGUILayout.HelpBox(
                    "Sprites located at: " + spritePath,
                    MessageType.Info,
                    true);
            }
            else
            {
                EditorGUILayout.HelpBox(
                    "Not valid!",
                    MessageType.Warning,
                    true);
            }
            if (GUILayout.Button("Create presliced sprites in character-sprite-folder"))
            {
                CreatePreslicedBaseSprites();
                if (swordAndShieldCombatAnimations != null) CreatePreslicedSwordAndShieldCombatSprites();
                if (spearCombatAnimations != null) CreatePreslicedSpearCombatSprites();
                if (bowCombatAnimations != null) CreatePreslicedBowCombatSprites();
            }
            GUILayout.Space(_space);
            GUILayout.Label("Create Animations", EditorStyles.largeLabel);
            GUILayout.Label("Please be aware that this will take some time");
            //Animations
            animationFolder = (DefaultAsset)EditorGUILayout.ObjectField(
                "Save Path for Animations",
                animationFolder,
                typeof(DefaultAsset),
                false);

            if (animationFolder != null)
            {
                animationSavePath = AssetDatabase.GetAssetPath(animationFolder);
                animationPath = animationSavePath.Replace("Assets/Resources/", "").Replace("Assets/MSC Animation Creator/Resources/", "");
                EditorGUILayout.HelpBox(
                    "Saving the animations to: " + animationPath,
                    MessageType.Info,
                    true);
            }
            else
            {
                EditorGUILayout.HelpBox(
                    "Not valid!",
                    MessageType.Warning,
                    true);
            }
            //Create Button
            if (GUILayout.Button("Create Animations"))
            {
                CreateBaseAnimations();
            }
            if (swordAndShieldCombatAnimations != null)
            {
                if (GUILayout.Button("Create Sword and Shield Combat Animations"))
                {
                    CreateSwordAndShieldAnimations();
                }
            }
            if (spearCombatAnimations != null)
            {
                if (GUILayout.Button("Create Spear Combat Animations"))
                {
                    CreateSpearAnimations();
                }
            }
            if (bowCombatAnimations != null)
            {
                if (GUILayout.Button("Create Bow Combat Animations"))
                {
                    CreateBowAnimations();
                }
            }
            GUILayout.Space(_space);
            GUILayout.Label("Rework/Create AnimController", EditorStyles.largeLabel);
            //AnimationController
            animationControllerFolder = (DefaultAsset)EditorGUILayout.ObjectField(
                "AnimationController Path",
                animationControllerFolder,
                typeof(DefaultAsset),
                false);

            if (animationControllerFolder != null)
            {
                animationControllerSavePath = AssetDatabase.GetAssetPath(animationControllerFolder);
                animationControllerPath = animationControllerSavePath.Replace("Assets/Resources/", "").Replace("Assets/MSC Animation Creator/Resources/", "");
                EditorGUILayout.HelpBox(
                    "Saving/Updating the AnimationControllers in: " + animationControllerPath,
                    MessageType.Info,
                    true);
            }
            else
            {
                EditorGUILayout.HelpBox(
                    "Not valid!",
                    MessageType.Warning,
                    true);
            }
            GUILayout.Space(_space);
            GUILayout.Label("Set the base AnimController provided in Resources/AnimationController");
            baseAnimController = (AnimatorController)EditorGUILayout.ObjectField(
                "Base AnimController",
                baseAnimController,
                typeof(AnimatorController),
                false);
            GUILayout.Space(_space);
            GUILayout.Label("If you have a player prefab you want to associate the anim controller to:");
            playerPrefab = (GameObject)EditorGUILayout.ObjectField(
                "Player Prefab",
                playerPrefab,
                typeof(GameObject),
                false);
            GUILayout.Space(_space);
            //Refactor Controller Button
            if (GUILayout.Button("Rework Animation Controller"))
            {
                ReworkAnimationController();
            }
        }

        private void CreatePreslicedBaseSprites()
        {
            List<string> pFolders = new List<string>()
            {
                "p1",
                "p1B",
                "p1C",
                "p2",
                "p3",
                "p4"
            };

            foreach (string pF in pFolders)
            {
                if (!Directory.Exists(spriteSavePath + "/" + pF)) Directory.CreateDirectory(spriteSavePath + "/" + pF);
                string spriteSource;
                switch (pF)
                {
                    case "p3":
                        spriteSource = preslicedSprite_p3;
                        break;

                    default:
                        spriteSource = preslicedSprite_p1;
                        break;
                }

                foreach (string layer in animationLayers)
                {
                    string newSprite = spriteSavePath + "/" + pF + "/" + layer + ".png";
                    CreateEmptySpritePage(newSprite);
                    CopySprites(spriteSource, newSprite);
                }
            }
        }

        private void CreatePreslicedSwordAndShieldCombatSprites()
        {
            List<string> pFolders = new List<string>()
            {
                "combat/pONE1",
                "combat/pONE2",
                "combat/pONE3"
            };

            foreach (string pF in pFolders)
            {
                if (!Directory.Exists(spriteSavePath + "/" + pF)) Directory.CreateDirectory(spriteSavePath + "/" + pF);
                string spriteSource = preslicedSprite_p1;

                foreach (string layer in animationLayers)
                {
                    string newSprite = spriteSavePath + "/" + pF + "/" + layer + ".png";
                    CreateEmptySpritePage(newSprite);
                    CopySprites(spriteSource, newSprite);
                }
            }
        }

        private void CreatePreslicedSpearCombatSprites()
        {
            List<string> pFolders = new List<string>()
            {
                "combat/pPOL1",
                "combat/pPOL2",
                "combat/pPOL3"
            };

            foreach (string pF in pFolders)
            {
                if (!Directory.Exists(spriteSavePath + "/" + pF)) Directory.CreateDirectory(spriteSavePath + "/" + pF);
                string spriteSource = preslicedSprite_p1;

                foreach (string layer in animationLayers)
                {
                    string newSprite = spriteSavePath + "/" + pF + "/" + layer + ".png";
                    CreateEmptySpritePage(newSprite);
                    CopySprites(spriteSource, newSprite);
                }
            }
        }

        private void CreatePreslicedBowCombatSprites()
        {
            List<string> pFolders = new List<string>()
            {
                "combat/pBOW1",
                "combat/pBOW2",
                "combat/pBOW3"
            };

            foreach (string pF in pFolders)
            {
                if (!Directory.Exists(spriteSavePath + "/" + pF)) Directory.CreateDirectory(spriteSavePath + "/" + pF);
                string spriteSource = preslicedSprite_p1;

                foreach (string layer in animationLayers)
                {
                    string newSprite = spriteSavePath + "/" + pF + "/" + layer + ".png";
                    CreateEmptySpritePage(newSprite);
                    CopySprites(spriteSource, newSprite);
                }
            }
        }

        public static void CopySprites(string pathFrom, string pathTo)
        {
            TextureImporter _importerFrom = AssetImporter.GetAtPath(pathFrom) as TextureImporter;
            //Get Texture Importer of pasteTo texture for assigning sprite variables
            TextureImporter _importer = AssetImporter.GetAtPath(pathTo) as TextureImporter;
            if (_importerFrom != null && _importer != null)
            {
                _importerFrom.textureType = TextureImporterType.Sprite;
                _importerFrom.isReadable = true;

                EditorUtility.CopySerialized(_importerFrom, _importer);
                //Rebuild asset
                AssetDatabase.ImportAsset(pathTo, ImportAssetOptions.ForceUpdate);
                AssetDatabase.Refresh();
            }
            else
            {
                Debug.Log(pathFrom + " / " + pathTo);
                Debug.Log("Copy Sprites Problem!");
            }
        }

        public static void CreateEmptySpritePage(string spritePath)
        {
            Texture2D emptyTexture = (Texture2D)Resources.Load("pre_sliced_sprites/empty_texture"); ;
            Texture2D texture = new Texture2D(emptyTexture.width, emptyTexture.height);

            Color[] basePixels = emptyTexture.GetPixels();
            texture.SetPixels(basePixels);
            texture.Apply();

            byte[] byteArray = texture.EncodeToPNG();
            System.IO.File.WriteAllBytes(spritePath, byteArray);
            AssetDatabase.ImportAsset(spritePath);
            AssetDatabase.Refresh();
        }

        public static void SetTextureReadable(string assetPath, bool isReadable)
        {
            var tImporter = AssetImporter.GetAtPath(assetPath) as TextureImporter;
            if (tImporter != null)
            {
                tImporter.textureType = TextureImporterType.Sprite;

                tImporter.isReadable = isReadable;

                AssetDatabase.ImportAsset(assetPath);
                AssetDatabase.Refresh();
            }
        }

        private void ReworkAnimationController()
        {
            Debug.Log("ReworkAnimationController ");
            foreach (var layer in animationLayers)
            {
                AssetDatabase.CopyAsset(AssetDatabase.GetAssetPath(baseAnimController), animationControllerSavePath + "/" + layer + ".controller");
            }
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            foreach (var layer in animationLayers)
            {
                AnimatorController animController = Resources.Load<AnimatorController>(animationControllerPath + "/" + layer);
                AnimationClip[] animClips = Resources.LoadAll<AnimationClip>(animationPath + "/" + layer);
                //Debug.Log(animationPath + "/" + layer.ToString() + " => " + animClips.Length);
                if (animController != null)
                {
                    AnimatorControllerLayer[] layers = animController.layers;
                    AnimatorControllerLayer workingLayer = layers[0];
                    List<AnimatorState> stateList = _ExpandStatesInLayer(workingLayer.stateMachine);
                    foreach (var state in stateList)
                    {
                        AnimationClip toUse = null;
                        string animName = layer + state.name.ToLower();
                        foreach (AnimationClip reworkedClip in animClips)
                        {
                            if (animName == reworkedClip.name)
                            {
                                toUse = reworkedClip;
                            }
                        }

                        state.motion = toUse;
                    }
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();
                    //zuordnung Player prefab
                    if (playerPrefab != null)
                    {
                        //newPrefab.GetComponent<Animator>().runtimeAnimatorController = Resources.Load<AnimatorController>(animPath.Replace("Assets/Resources/", "") + "/" + saveName);
                        foreach (Animator pl_animator in playerPrefab.GetComponentsInChildren<Animator>())
                        {
                            if (pl_animator.name == layer.ToString()) pl_animator.runtimeAnimatorController = animController;
                        }
                    }
                }
                else
                {
                    AnimatorController animator = AnimatorController.CreateAnimatorControllerAtPath(animationControllerSavePath + "/" + layer.ToString() + ".controller");
                    animator.name = layer;
                    AnimatorControllerLayer clayer = animator.layers[0];
                    foreach (AnimationClip reworkedClip in animClips)
                    {
                        AnimatorState state = clayer.stateMachine.AddState(reworkedClip.name);
                        state.motion = reworkedClip;
                    }
                }
            }
        }

        public static List<AnimatorState> _ExpandStatesInLayer(AnimatorStateMachine sm, List<AnimatorState> collector = null)
        {
            if (collector == null)
                collector = new List<AnimatorState>();

            foreach (var subSm in sm.stateMachines) // Jump into nested state machine
                _ExpandStatesInLayer(subSm.stateMachine, collector);

            foreach (var state in sm.states)
            {
                collector.Add(state.state);

                foreach (var subSm in sm.stateMachines) // Jump into nested state machine
                    _ExpandStatesInLayer(subSm.stateMachine, collector);
            }
            return collector;
        }

        private void CreateBaseAnimations()
        {
            Debug.Log("CreateBaseAnimations");
            string thisSpritePath = spritePath + "/";
            Dictionary<string, Sprite[]> spriteDict = null;

            foreach (var layer in animationLayers)
            {
                spriteDict = new Dictionary<string, Sprite[]>
                {
                    { "p1", Resources.LoadAll<Sprite>(thisSpritePath + "p1/" + layer) },
                    { "p1B", Resources.LoadAll<Sprite>(thisSpritePath + "p1B/" + layer) },
                    { "p1C", Resources.LoadAll<Sprite>(thisSpritePath + "p1C/" + layer) },
                    { "p2", Resources.LoadAll<Sprite>(thisSpritePath + "p2/" + layer) },
                    { "p3", Resources.LoadAll<Sprite>(thisSpritePath + "p3/" + layer) },
                    { "p4", Resources.LoadAll<Sprite>(thisSpritePath + "p4/" + layer) }
                };

                foreach (MSCAnimation anim in baseAnimations.list)
                {
                    string animSavePath = animationSavePath + "/" + layer.ToString() + "/";
                    if (!AssetDatabase.IsValidFolder(animationSavePath + "/" + layer.ToString()))
                    {
                        AssetDatabase.CreateFolder(System.IO.Path.GetDirectoryName(animationSavePath + "/"), layer.ToString());
                    }
                    string animSaveName = layer + anim.animationType + anim.animationName;
                    CreateAnimationClip(spriteDict[anim.spritePage], anim.keys, anim.keyTimer, animSaveName, animSavePath, anim.animationType, layer, anim.xFlip, anim.pritoolLayerKeys, anim.sectoolLayerKeys);
                }
            }
        }

        private void CreateSwordAndShieldAnimations()
        {
            Debug.Log("CreateSwordAndShieldAnimations");
            string thisSpritePath = spritePath + "/";
            Dictionary<string, Sprite[]> spriteDict = null;

            foreach (var layer in animationLayers)
            {
                if (!AssetDatabase.IsValidFolder(animationSavePath + "/" + layer.ToString() + "/combat"))
                    AssetDatabase.CreateFolder(System.IO.Path.GetDirectoryName(animationSavePath + "/" + layer.ToString() + "/"), "combat");

                spriteDict = new Dictionary<string, Sprite[]>
                {
                    { "combat/pONE1", Resources.LoadAll<Sprite>(thisSpritePath + "combat/pONE1/" + layer) },
                    { "combat/pONE2", Resources.LoadAll<Sprite>(thisSpritePath + "combat/pONE2/" + layer) },
                    { "combat/pONE3", Resources.LoadAll<Sprite>(thisSpritePath + "combat/pONE3/" + layer) }
                };

                foreach (MSCAnimation anim in swordAndShieldCombatAnimations.list)
                {
                    string animSavePath = animationSavePath + "/" + layer.ToString() + "/combat/swordshield/";
                    if (!AssetDatabase.IsValidFolder(animationSavePath + "/" + layer.ToString() + "/combat/swordshield"))
                    {
                        AssetDatabase.CreateFolder(System.IO.Path.GetDirectoryName(animationSavePath + "/" + layer.ToString() + "/combat/"), "swordshield");
                    }
                    string animSaveName = layer + "combatswordshield" + anim.animationType + anim.animationName;
                    CreateAnimationClip(spriteDict[anim.spritePage], anim.keys, anim.keyTimer, animSaveName, animSavePath, anim.animationType, layer, anim.xFlip, anim.pritoolLayerKeys, anim.sectoolLayerKeys);
                }
            }
        }

        private void CreateSpearAnimations()
        {
            Debug.Log("CreateSpearAnimations");
            string thisSpritePath = spritePath + "/";
            Dictionary<string, Sprite[]> spriteDict = null;

            foreach (var layer in animationLayers)
            {
                if (!AssetDatabase.IsValidFolder(animationSavePath + "/" + layer.ToString() + "/combat"))
                    AssetDatabase.CreateFolder(System.IO.Path.GetDirectoryName(animationSavePath + "/" + layer.ToString() + "/"), "combat");

                spriteDict = new Dictionary<string, Sprite[]>
                {
                    { "combat/pPOL1", Resources.LoadAll<Sprite>(thisSpritePath + "combat/pPOL1/" + layer) },
                    { "combat/pPOL2", Resources.LoadAll<Sprite>(thisSpritePath + "combat/pPOL2/" + layer) },
                    { "combat/pPOL3", Resources.LoadAll<Sprite>(thisSpritePath + "combat/pPOL3/" + layer) }
                };

                foreach (MSCAnimation anim in spearCombatAnimations.list)
                {
                    string animSavePath = animationSavePath + "/" + layer.ToString() + "/combat/spear/";
                    if (!AssetDatabase.IsValidFolder(animationSavePath + "/" + layer.ToString() + "/combat/spear"))
                    {
                        AssetDatabase.CreateFolder(System.IO.Path.GetDirectoryName(animationSavePath + "/" + layer.ToString() + "/combat/"), "spear");
                    }
                    string animSaveName = layer + "combatspear" + anim.animationType + anim.animationName;
                    CreateAnimationClip(spriteDict[anim.spritePage], anim.keys, anim.keyTimer, animSaveName, animSavePath, anim.animationType, layer, anim.xFlip, anim.pritoolLayerKeys, anim.sectoolLayerKeys);
                }
            }
        }

        private void CreateBowAnimations()
        {
            Debug.Log("CreateBowAnimations");
            string thisSpritePath = spritePath + "/";
            Dictionary<string, Sprite[]> spriteDict = null;

            foreach (var layer in animationLayers)
            {
                if (!AssetDatabase.IsValidFolder(animationSavePath + "/" + layer.ToString() + "/combat"))
                    AssetDatabase.CreateFolder(System.IO.Path.GetDirectoryName(animationSavePath + "/" + layer.ToString() + "/"), "combat");

                spriteDict = new Dictionary<string, Sprite[]>
                {
                    { "combat/pBOW1", Resources.LoadAll<Sprite>(thisSpritePath + "combat/pBOW1/" + layer) },
                    { "combat/pBOW2", Resources.LoadAll<Sprite>(thisSpritePath + "combat/pBOW2/" + layer) },
                    { "combat/pBOW3", Resources.LoadAll<Sprite>(thisSpritePath + "combat/pBOW3/" + layer) }
                };

                foreach (MSCAnimation anim in bowCombatAnimations.list)
                {
                    string animSavePath = animationSavePath + "/" + layer.ToString() + "/combat/bow/";
                    if (!AssetDatabase.IsValidFolder(animationSavePath + "/" + layer.ToString() + "/combat/bow"))
                    {
                        AssetDatabase.CreateFolder(System.IO.Path.GetDirectoryName(animationSavePath + "/" + layer.ToString() + "/combat/"), "bow");
                    }
                    string animSaveName = layer + "combatbow" + anim.animationType + anim.animationName;
                    CreateAnimationClip(spriteDict[anim.spritePage], anim.keys, anim.keyTimer, animSaveName, animSavePath, anim.animationType, layer, anim.xFlip, anim.pritoolLayerKeys, anim.sectoolLayerKeys);
                }
            }
        }

        public static void CreateAnimationClip(Sprite[] sprites, int[] keys, float[] keyTimer, string animName, string savePathParent, string savePathAdd, string layer, bool xFlip, int[] pritoolLayerKeys, int[] sectoolLayerKeys)
        {
            AnimationClip newClip = new AnimationClip();
            newClip.name = animName;
            newClip.frameRate = 60f;

            EditorCurveBinding spriteBinding = new EditorCurveBinding();
            spriteBinding.type = typeof(SpriteRenderer);
            spriteBinding.path = "";
            spriteBinding.propertyName = "m_Sprite";

            EditorCurveBinding layerOrderBinding = new EditorCurveBinding();
            layerOrderBinding.type = typeof(SpriteRenderer);
            layerOrderBinding.path = "";
            layerOrderBinding.propertyName = "m_SortingOrder";

            AnimationClipSettings animClipSett = new AnimationClipSettings();
            animClipSett.loopTime = true;

            AnimationUtility.SetAnimationClipSettings(newClip, animClipSett);

            AnimationUtility.SetObjectReferenceCurve(newClip, spriteBinding, CreateSpriteKeyframes(sprites, keys, keyTimer));
            if (xFlip)
            {
                EditorCurveBinding flipX = new EditorCurveBinding();
                flipX.type = typeof(SpriteRenderer);
                flipX.path = "";
                flipX.propertyName = "m_FlipX";
                AnimationCurve ac = new AnimationCurve();
                ac.AddKey(0f, 1f);
                AnimationUtility.SetEditorCurve(newClip, flipX, ac);
            }
            if ((layer == "pritool") && pritoolLayerKeys != null && pritoolLayerKeys.Length > 0)
            {
                //Debug.Log(layer + ", " + savePathAdd);
                AnimationUtility.SetEditorCurve(newClip, layerOrderBinding, CreateLayerOrderKeyframes(pritoolLayerKeys, keys, keyTimer));
            }
            if ((layer == "sectool") && sectoolLayerKeys != null && sectoolLayerKeys.Length > 0)
            {
                //Debug.Log(layer + ", " + savePathAdd);
                AnimationUtility.SetEditorCurve(newClip, layerOrderBinding, CreateLayerOrderKeyframes(sectoolLayerKeys, keys, keyTimer));
            }

            //Debug.Log(savePathParent);
            //Debug.Log(savePathAdd);
            if (!AssetDatabase.IsValidFolder(savePathParent + savePathAdd))
            {
                AssetDatabase.CreateFolder(System.IO.Path.GetDirectoryName(savePathParent), savePathAdd);
            }
            AssetDatabase.CreateAsset(newClip, savePathParent + savePathAdd + "/" + newClip.name + ".anim");
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        public static ObjectReferenceKeyframe[] CreateSpriteKeyframes(Sprite[] sprites, int[] spritesNumbers, float[] keyTimer)
        {
            //Debug.Log(modifier);
            ObjectReferenceKeyframe[] keyFrames = new ObjectReferenceKeyframe[spritesNumbers.Length];
            if (sprites.Length > 0)
            {
                for (int i = 0; i < spritesNumbers.Length; i++)
                {
                    keyFrames[i] = new ObjectReferenceKeyframe
                    {
                        time = keyTimer[i] * keyTimerModifier,
                        value = sprites[spritesNumbers[i]]
                    };
                }
            }

            return keyFrames;
        }

        private static AnimationCurve CreateLayerOrderKeyframes(int[] layerOrder, int[] spritesNumbers, float[] keyTimer)
        {
            AnimationCurve curve = new AnimationCurve();
            Keyframe[] keyFrames = new Keyframe[spritesNumbers.Length];
            for (int i = 0; i < spritesNumbers.Length; i++)
            {
                keyFrames[i] = new Keyframe();
                keyFrames[i].time = keyTimer[i] * keyTimerModifier;
                keyFrames[i].value = layerOrder[i];
            }
            curve.keys = keyFrames;

            return curve;
        }
    }
}