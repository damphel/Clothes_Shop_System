using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

namespace ManaSeedTools.CharacterAnimator
{
    public class MSCNpcEditor : EditorWindow
    {
        private float _space = 5f;

        private string spritePath = "Sprites/Character/Spritesheets/";
        private string spriteSavePath = "Sprites/Character/Spritesheets/";

        private string saveToPath = "Animations/Player/Animations/";
        private string saveToSavePath = "Animations/Player/Animations/";

        private DefaultAsset spriteFolder = null;

        private AnimatorController baseAnimController = null;

        private DefaultAsset saveToFolder = null;

        private int body = 0;
        private List<string> bodyOptions = new List<string>();
        private int cloak = 0;
        private List<string> cloakOptions = new List<string>();
        private int faceitems = 0;
        private List<string> faceitemsOptions = new List<string>();
        private int hair = 0;
        private List<string> hairOptions = new List<string>();
        private int hat = 0;
        private List<string> hatOptions = new List<string>();
        private int outfit = 0;
        private List<string> outfitOptions = new List<string>();
        private int pritool = 0;
        private List<string> pritoolOptions = new List<string>();
        /*private int sectool = 0;
        List<string> sectoolOptions = new List<string>();*/

        private string saveName;

        private Texture2D emptyTexture = null;
        private string p1_source_path;
        private string p3_source_path;

        private GameObject npcPrefab = null;

        [SerializeField] private SO_AnimationSettings animations = null;
        [SerializeField] private SO_AnimationSettings swordAndShieldAnimations = null;
        [SerializeField] private SO_AnimationSettings spearAnimations = null;
        [SerializeField] private SO_AnimationSettings bowAnimations = null;

        [MenuItem("Tools/MSC NPC Editor")]
        public static void MSCNpcEditorWindow()
        {
            GetWindow<MSCNpcEditor>("ManaSeed NPC Editor");
        }

        private void OnGUI()
        {
            emptyTexture = (Texture2D)Resources.Load("pre_sliced_sprites/empty_texture");
            p1_source_path = AssetDatabase.GetAssetPath((Texture2D)Resources.Load("pre_sliced_sprites/p1_sliced"));
            p3_source_path = AssetDatabase.GetAssetPath((Texture2D)Resources.Load("pre_sliced_sprites/p3_sliced"));

            GUILayout.Label("The ManaSeed NPC Editor", EditorStyles.largeLabel);
            GUILayout.Space(_space);
            //Show Frame 0 of Character Base P1 as Drawing Reference in the Middle of the Window
            float sourceAreaWidth = 350;
            float sourceAreaHeight = 300;
            GUILayout.BeginArea(new Rect(5, 25, sourceAreaWidth, sourceAreaHeight));
            CreateSourceArea();
            GUILayout.EndArea();
            int sprAreaW = 300;
            int sprAreaH = 500;
            GUILayout.BeginArea(new Rect(position.width - ((sprAreaW * 1) + 10), 10, sprAreaW, sprAreaH));
            CreateSettingsArea();
            GUILayout.EndArea();

            float paintAreaWidth = 300;
            float paintAreaHeight = 300;
            GUILayout.BeginArea(new Rect(365, 25, paintAreaWidth, paintAreaHeight));
            GUILayout.Label("NPC Preview");
            EditorGUI.DrawTextureTransparent(new Rect(0, 20, 512, 512), emptyTexture);
            ShowSprite();
            GUILayout.EndArea();
        }

        private void CreateSourceArea()
        {
            GUILayout.Label("Give it a Name (to save it to)");
            saveName = EditorGUILayout.TextField("Name", saveName);
            GUILayout.Label("Select the sheets to use");
            bodyOptions = GetSpriteOptions("body");
            body = EditorGUILayout.Popup("Body", body, bodyOptions.ToArray());
            outfitOptions = GetSpriteOptions("outfit");
            outfit = EditorGUILayout.Popup("Outfit", outfit, outfitOptions.ToArray());
            cloakOptions = GetSpriteOptions("cloak");
            cloak = EditorGUILayout.Popup("Cloak", cloak, cloakOptions.ToArray());
            faceitemsOptions = GetSpriteOptions("faceitems");
            faceitems = EditorGUILayout.Popup("Faceitems", faceitems, faceitemsOptions.ToArray());
            hairOptions = GetSpriteOptions("hair");
            hair = EditorGUILayout.Popup("Hair", hair, hairOptions.ToArray());
            hatOptions = GetSpriteOptions("hat");
            hat = EditorGUILayout.Popup("Hat", hat, hatOptions.ToArray());
            pritoolOptions = GetSpriteOptions("pritool");
            pritool = EditorGUILayout.Popup("Primary Tool", pritool, pritoolOptions.ToArray());
            /*sectoolOptions = GetSpriteOptions("sectool");
            sectool = EditorGUILayout.Popup("Secondary Tool", sectool, sectoolOptions.ToArray());*/

            GUILayout.Space(_space);
            if (GUILayout.Button("Create NPC"))
            {
                CreateNPC();
            }
        }

        private void CreateNPC()
        {
            //create folder structure under give path
            string savePath = AssetDatabase.GetAssetPath(saveToFolder) + "/" + saveName;
            if (!Directory.Exists(savePath)) Directory.CreateDirectory(savePath);
            //sheets
            string sheetPath = savePath;
            sheetPath += "/sheets";
            if (!Directory.Exists(sheetPath)) Directory.CreateDirectory(sheetPath);
            //create spritesheets in pages
            CreatePageTexture("p1", sheetPath);
            CreatePageTexture("p2", sheetPath);
            CreatePageTexture("p3", sheetPath);
            CreatePageTexture("p4", sheetPath);
            //slice the spritesheets
            CreateSprites(sheetPath);
            //animations and animcontroller
            string animPath = savePath;
            animPath += "/animations";
            if (!Directory.Exists(animPath)) Directory.CreateDirectory(animPath);
            AssetDatabase.Refresh();
            //create animations and fill them
            CreateAnimations(sheetPath.Replace("Assets/Resources/", ""), animPath);
            //create animController and link it
            CreateAnimatonController(animPath);
            //copy prefab => set Animcontroller first
            GameObject newPrefab = Instantiate(npcPrefab);
            newPrefab.GetComponent<Animator>().runtimeAnimatorController = Resources.Load<AnimatorController>(animPath.Replace("Assets/Resources/", "") + "/" + saveName);
            //Debug.Log(sheetPath.Replace("Assets/Resources/", "") + "/p1/body_0");
            //Debug.Log(Resources.Load<Sprite>(sheetPath.Replace("Assets/Resources/", "") + "/p1"));
            newPrefab.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(sheetPath.Replace("Assets/Resources/", "") + "/p1");
            PrefabUtility.SaveAsPrefabAsset(newPrefab, savePath + "/" + saveName + ".prefab");
            DestroyImmediate(newPrefab);
        }

        private void CreateAnimatonController(string savePath)
        {
            AssetDatabase.CopyAsset(AssetDatabase.GetAssetPath(baseAnimController), savePath + "/" + saveName + ".controller");
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            AnimatorController animController = Resources.Load<AnimatorController>(savePath.Replace("Assets/Resources/", "") + "/" + saveName);
            AnimationClip[] animClips = Resources.LoadAll<AnimationClip>(savePath.Replace("Assets/Resources/", ""));
            if (animController != null)
            {
                AnimatorControllerLayer[] layers = animController.layers;
                //Debug.Log(layers.Length);
                AnimatorControllerLayer workingLayer = layers[0];
                List<AnimatorState> stateList = MSCUnityEditor._ExpandStatesInLayer(workingLayer.stateMachine);

                foreach (var state in stateList)
                {
                    Motion m = state.motion;
                    AnimationClip toUse = null;
                    if (m is AnimationClip) // It is single animation clip
                    {
                        string animName = m.name.Replace("body", "");
                        foreach (AnimationClip reworkedClip in animClips)
                        {
                            if (animName == reworkedClip.name)
                            {
                                toUse = reworkedClip;
                            }
                        }
                    }

                    state.motion = toUse;
                }
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
        }

        private void CreateAnimations(string thisSpritePath, string savePath)
        {
            Dictionary<string, Sprite[]> spriteDict = new Dictionary<string, Sprite[]>();
            spriteDict.Add("p1", Resources.LoadAll<Sprite>(thisSpritePath + "/p1"));
            spriteDict.Add("p2", Resources.LoadAll<Sprite>(thisSpritePath + "/p2"));
            spriteDict.Add("p3", Resources.LoadAll<Sprite>(thisSpritePath + "/p3"));
            spriteDict.Add("p4", Resources.LoadAll<Sprite>(thisSpritePath + "/p4"));

            foreach (MSCAnimation anim in animations.list)
            {
                string animSavePath = savePath + "/";
                string animSaveName = anim.animationType + anim.animationName;
                MSCUnityEditor.CreateAnimationClip(spriteDict[anim.spritePage], anim.keys, anim.keyTimer, animSaveName, animSavePath, anim.animationType, "", anim.xFlip, anim.pritoolLayerKeys, anim.sectoolLayerKeys);
            }
        }

        private void CreatePageTexture(string page, string savePath)
        {
            string basePath = spritePath + "/char_a_" + page + "/";
            Texture2D texture = new Texture2D(emptyTexture.width, emptyTexture.height);

            Color[] basePixels = { };
            Color[] mergePixels = { };
            if (LoadTexture(basePath + bodyOptions[body].Replace("p1", page)) != null)
            {
                basePixels = LoadTexture(basePath + bodyOptions[body].Replace("p1", page)).GetPixels();
                if (LoadTexture(basePath + "1out/" + outfitOptions[outfit].Replace("p1", page)) != null)
                {
                    mergePixels = LoadTexture(basePath + "1out/" + outfitOptions[outfit].Replace("p1", page)).GetPixels();
                    MergeColorArray(basePixels, mergePixels);
                }
                if (LoadTexture(basePath + "2clo/" + cloakOptions[cloak].Replace("p1", page)) != null)
                {
                    mergePixels = LoadTexture(basePath + "2clo/" + cloakOptions[cloak].Replace("p1", page)).GetPixels();
                    MergeColorArray(basePixels, mergePixels);
                }
                if (LoadTexture(basePath + "3fac/" + faceitemsOptions[faceitems].Replace("p1", page)) != null)
                {
                    mergePixels = LoadTexture(basePath + "3fac/" + faceitemsOptions[faceitems].Replace("p1", page)).GetPixels();
                    MergeColorArray(basePixels, mergePixels);
                }
                if (LoadTexture(basePath + "4har/" + hairOptions[hair].Replace("p1", page)) != null)
                {
                    mergePixels = LoadTexture(basePath + "4har/" + hairOptions[hair].Replace("p1", page)).GetPixels();
                    MergeColorArray(basePixels, mergePixels);
                }
                if (LoadTexture(basePath + "5hat/" + hatOptions[hat].Replace("p1", page)) != null)
                {
                    mergePixels = LoadTexture(basePath + "5hat/" + hatOptions[hat].Replace("p1", page)).GetPixels();
                    MergeColorArray(basePixels, mergePixels);
                }
                if (LoadTexture(basePath + "6tla/" + pritoolOptions[pritool].Replace("p2", page)) != null)
                {
                    mergePixels = LoadTexture(basePath + "6tla/" + pritoolOptions[pritool].Replace("p2", page)).GetPixels();
                    MergeColorArray(basePixels, mergePixels);
                }
                texture.SetPixels(basePixels);

                texture.Apply();
            }

            byte[] byteArray = texture.EncodeToPNG();
            string filepath = savePath + "/" + page + ".png";
            System.IO.File.WriteAllBytes(filepath, byteArray);
            AssetDatabase.ImportAsset(filepath);
            AssetDatabase.Refresh();
            MSCUnityEditor.SetTextureReadable(filepath, true);
        }

        private void CreateSprites(string sheetPath)
        {
            MSCUnityEditor.CopySprites(p1_source_path, sheetPath + "/p1.png");
            MSCUnityEditor.CopySprites(p1_source_path, sheetPath + "/p2.png");
            MSCUnityEditor.CopySprites(p3_source_path, sheetPath + "/p3.png");
            MSCUnityEditor.CopySprites(p1_source_path, sheetPath + "/p4.png");
        }

        private void MergeColorArray(Color[] baseArray, Color[] mergeArray)
        {
            for (int i = 0; i < baseArray.Length; i++)
            {
                if (mergeArray[i].a > 0)
                {
                    //mergeArray has color
                    if (mergeArray[i].a >= 1)
                    {
                        //fully replace
                        baseArray[i] = mergeArray[i];
                    }
                    else
                    {
                        //interpolate colors
                        float alpha = mergeArray[i].a;
                        baseArray[i].r += (mergeArray[i].r - baseArray[i].r) * alpha;
                        baseArray[i].g += (mergeArray[i].g - baseArray[i].g) * alpha;
                        baseArray[i].b += (mergeArray[i].b - baseArray[i].b) * alpha;
                        baseArray[i].a += mergeArray[i].a;
                    }
                }
            }
        }

        private List<string> GetSpriteOptions(string type)
        {
            List<string> options = new List<string>()
            {
                "empty"
            };
            Texture2D[] texture2Ds = Resources.LoadAll<Texture2D>(spritePath + "/char_a_p1");
            if (spriteFolder != null)
            {
                foreach (Texture2D t2d in texture2Ds)
                {
                    string path = AssetDatabase.GetAssetPath(t2d).Replace("Assets/Resources/", "").Replace(spritePath + "/char_a_p1/", "");
                    string[] splitted = path.Split('/');

                    switch (type)
                    {
                        case "body":
                            if (splitted.Length == 1) options.Add(t2d.name);
                            break;

                        case "outfit":
                            if (splitted.Length == 2 && splitted[0] == "1out") options.Add(t2d.name);
                            break;

                        case "cloak":
                            if (splitted.Length == 2 && splitted[0] == "2clo") options.Add(t2d.name);
                            break;

                        case "faceitems":
                            if (splitted.Length == 2 && splitted[0] == "3fac") options.Add(t2d.name);
                            break;

                        case "hair":
                            if (splitted.Length == 2 && splitted[0] == "4har") options.Add(t2d.name);
                            break;

                        case "hat":
                            if (splitted.Length == 2 && splitted[0] == "5hat") options.Add(t2d.name);
                            break;
                    }
                }
            }

            texture2Ds = Resources.LoadAll<Texture2D>(spritePath + "/char_a_p2");
            if (spriteFolder != null)
            {
                foreach (Texture2D t2d in texture2Ds)
                {
                    string path = AssetDatabase.GetAssetPath(t2d).Replace("Assets/Resources/", "").Replace(spritePath + "/char_a_p2/", "");
                    string[] splitted = path.Split('/');

                    switch (type)
                    {
                        case "pritool":
                            if (splitted.Length == 2 && splitted[0] == "6tla") options.Add(t2d.name);
                            break;
                            /*case "sectool":
                                if (splitted.Length == 2 && splitted[0] == "7tlb") options.Add(t2d.name);
                                break;*/
                    }
                }
            }

            return options;
        }

        private void CreateSettingsArea()
        {
            GUILayout.Label("Folder Paths \n(they need to be nested in: Assets/Resources)");
            //Sprites
            spriteFolder = (DefaultAsset)EditorGUILayout.ObjectField(
                "Sprites to use",
                spriteFolder,
                typeof(DefaultAsset),
                false);
            if (spriteFolder != null)
            {
                spriteSavePath = AssetDatabase.GetAssetPath(spriteFolder);
                spritePath = spriteSavePath.Replace("Assets/Resources/", "");
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
            //AnimationController
            GUILayout.Space(_space);
            GUILayout.Label("Set the base AnimController provided in Resources/AnimationController");
            baseAnimController = (AnimatorController)EditorGUILayout.ObjectField(
                "Base AnimController",
                baseAnimController,
                typeof(AnimatorController),
                false);
            //save to Folder
            saveToFolder = (DefaultAsset)EditorGUILayout.ObjectField(
                "Save To Path",
                saveToFolder,
                typeof(DefaultAsset),
                false);

            if (saveToFolder != null)
            {
                saveToSavePath = AssetDatabase.GetAssetPath(saveToFolder);
                saveToPath = saveToSavePath.Replace("Assets/Resources/", "").Replace("Assets/MSC Animation Creator/Resources/", "");
                EditorGUILayout.HelpBox(
                    "Saving created NPC to: " + saveToPath,
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
            GUILayout.Label("Definitions of the animations to create!\nFound as Scriptable Object in the\nAnimationSettings Folder");
            animations = (SO_AnimationSettings)EditorGUILayout.ObjectField(
                "Animation Settings",
                animations,
                typeof(SO_AnimationSettings),
                false);
            GUILayout.Space(_space);
            GUILayout.Label("There is a base NPC Prefab you can use\nFound in the Prefabs Folder");
            npcPrefab = (GameObject)EditorGUILayout.ObjectField(
                "NPC Prefab",
                npcPrefab,
                typeof(GameObject),
                false);
        }

        private Texture2D LoadTexture(string texName)
        {
            return Resources.Load<Texture2D>(texName);
        }

        private Sprite[] LoadSprites(string spriteName)
        {
            return Resources.LoadAll<Sprite>(spriteName);
        }

        private void ShowSprite()
        {
            string basePath = spritePath + "/char_a_p1/";
            string baseSavePath = spriteSavePath + "/char_a_p1/";
            Sprite[] sprites = LoadSprites(basePath + bodyOptions[body]);
            if (sprites.Length == 1) MSCUnityEditor.CopySprites(p1_source_path, baseSavePath + bodyOptions[body] + ".png");
            DrawLayer(sprites);

            sprites = LoadSprites(basePath + "1out/" + outfitOptions[outfit]);
            if (sprites.Length == 1) MSCUnityEditor.CopySprites(p1_source_path, baseSavePath + "1out/" + outfitOptions[outfit] + ".png");
            DrawLayer(sprites);

            sprites = LoadSprites(basePath + "2clo/" + cloakOptions[cloak]);
            if (sprites.Length == 1) MSCUnityEditor.CopySprites(p1_source_path, baseSavePath + "2clo/" + cloakOptions[cloak] + ".png");
            DrawLayer(sprites);

            sprites = LoadSprites(basePath + "3fac/" + faceitemsOptions[faceitems]);
            if (sprites.Length == 1) MSCUnityEditor.CopySprites(p1_source_path, baseSavePath + "3fac/" + faceitemsOptions[faceitems] + ".png");
            DrawLayer(sprites);

            sprites = LoadSprites(basePath + "4har/" + hairOptions[hair]);
            if (sprites.Length == 1) MSCUnityEditor.CopySprites(p1_source_path, baseSavePath + "4har/" + hairOptions[hair] + ".png");
            DrawLayer(sprites);

            sprites = LoadSprites(basePath + "5hat/" + hatOptions[hat]);
            if (sprites.Length == 1) MSCUnityEditor.CopySprites(p1_source_path, baseSavePath + "5hat/" + hatOptions[hat] + ".png");
            DrawLayer(sprites);

            sprites = LoadSprites(basePath + "6tla/" + pritoolOptions[pritool]);
            if (sprites.Length == 1) MSCUnityEditor.CopySprites(p1_source_path, baseSavePath + "6tla/" + pritoolOptions[pritool] + ".png");
            DrawLayer(sprites);
            //DrawLayer(LoadSprites(basePath + "7tlb/" + sectoolOptions[sectool]));
        }

        private static void DrawLayer(Sprite[] sprites)
        {
            if (sprites.Length > 0)
            {
                Texture texture = AssetPreview.GetAssetPreview(sprites[0]);
                if (texture != null)
                {
                    texture.filterMode = FilterMode.Point;
                    Color guiColor = GUI.color; // Save the current GUI color
                    GUI.color = Color.clear; // This does the magic
                    EditorGUI.DrawTextureTransparent(new Rect(0, 15, 300, 300), texture);
                    GUI.color = guiColor; // Get back to previous GUI color
                }
            }
        }
    }
}