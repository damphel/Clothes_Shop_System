using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR

using UnityEditor;

#endif

namespace ManaSeedTools.CharacterAnimator
{
    public enum Direction
    {
        right,
        left,
        up,
        down,
        none
    }

    public enum MoveType
    {
        idle,
        walking,
        running
    }

    public class Player : MonoBehaviour
    {
        private float xInput, yInput, movementSpeed;
        private MoveType moveType;
        private Direction playerDirection;

        private float runningSpeed = 5.333f;
        private float walkingSpeed = 2.666f;
        private float combatMoveSpeed = 0.555f;

        private Rigidbody2D rigidBody2D;

        private string testTrigger;
        private bool inCombat;

        public GameObject hat;
        public GameObject hair;
        public Texture2D toolTexture;

        [Header("BasePath of textures for runtime")]
        public string textureBasePath;

        [Header("Textures to use for showing the animation")]
        public Texture2D backgroundT;

        public Texture2D bodyT;
        public Texture2D outfitT;
        public Texture2D cloakT;
        public Texture2D faceitemsT;
        public Texture2D hairT;
        public Texture2D hatT;
        public Texture2D pritoolT;
        public Texture2D sectoolT;
        public Texture2D topT;

        [Header("Weapon Textures")]
        public Texture2D mainhandSwordAndShieldT;

        public Texture2D offhandSwordAndShieldT;
        public Texture2D spearT;
        public Texture2D mainhandBowT;
        public Texture2D offhandBowT;

        [Header("Location of the sprites used for the animation (inside 'Assets/Resouces')")]
        public string SpriteSetPath;

        private void Awake()
        {
            rigidBody2D = GetComponent<Rigidbody2D>();
        }

        // Start is called before the first frame update
        private void Start()
        {
            moveType = MoveType.idle;
            playerDirection = Direction.none;

            SetCharacterTextures();
        }

        // Update is called once per frame
        private void Update()
        {
            ResetAnimationTriggers();
            PlayerMovementInput();

            EventHandler.CallMovementEvent(xInput, yInput, moveType, playerDirection, this, testTrigger);
            testTrigger = null;
        }

        private void FixedUpdate()
        {
            PlayerMovement();
        }

        private void SetCharacterTextures()
        {
            if (backgroundT != null)
            {
                SetTexture(backgroundT, "background");
            }
            if (bodyT != null)
            {
                SetTexture(bodyT, "body");
            }
            if (outfitT != null)
            {
                SetTexture(outfitT, "outfit");
            }
            if (cloakT != null)
            {
                SetTexture(cloakT, "cloak");
            }
            if (faceitemsT != null)
            {
                SetTexture(faceitemsT, "faceitems");
            }
            if (hairT != null)
            {
                SetTexture(hairT, "hair");
            }
            if (hatT != null)
            {
                hair.SetActive(false);
                SetTexture(hatT, "hat");
            }
            if (pritoolT != null)
            {
                SetTexture(pritoolT, "pritool");
            }
            if (sectoolT != null)
            {
                SetTexture(sectoolT, "sectool");
            }
            if (topT != null)
            {
                SetTexture(topT, "top");
            }
            //Weapon Textures
            if (mainhandSwordAndShieldT != null)
            {
                SetTexture(mainhandSwordAndShieldT, "mainhand", true);
            }
            if (offhandSwordAndShieldT != null)
            {
                SetTexture(offhandSwordAndShieldT, "offhand", true);
            }
            if (spearT != null)
            {
                SetTexture(spearT, "mainhand", true);
            }
            if (mainhandBowT != null)
            {
                SetTexture(mainhandBowT, "mainhand", true);
            }
            if (offhandBowT != null)
            {
                SetTexture(offhandBowT, "offhand", true);
            }
        }

        private void SetTexture(Texture2D texture, string layer, bool combatAnimation = false)
        {
            //Base Location of all sprites
            string fileBasePath = textureBasePath;
            fileBasePath = fileBasePath.Replace("Assets/Resources/", "");

            //specific part of the path
            string filePath = "";
            string[] partedName = texture.name.Split('_');
            filePath += partedName[0] + "_" + partedName[1] + "_" + partedName[2] + "/";
            if (partedName[3] != "0bas") filePath += partedName[3] + "/";
            filePath += texture.name;

            Dictionary<string, string> textPaths = SetTextureFilePaths(filePath, partedName);

            //Base Textures
            if (!combatAnimation) SetBaseTextures(layer, fileBasePath, filePath, textPaths);
            //Combat Textures
            //Debug.Log(filePath);
            SetCombatTextures(layer, fileBasePath, filePath, textPaths);
        }

        private void SetCombatTextures(string layer, string fileBasePath, string filePath, Dictionary<string, string> textPaths)
        {
            if (layer == "mainhand") layer = "pritool";
            if (layer == "offhand") layer = "sectool";
            Texture2D pONE1Texture = SetTexture(fileBasePath, textPaths, "pONE1", true);
            Texture2D pONE2Texture = SetTexture(fileBasePath, textPaths, "pONE2", true);
            Texture2D pONE3Texture = SetTexture(fileBasePath, textPaths, "pONE3", true);
            Texture2D pPOL1Texture = SetTexture(fileBasePath, textPaths, "pPOL1", true);
            Texture2D pPOL2Texture = SetTexture(fileBasePath, textPaths, "pPOL2", true);
            Texture2D pPOL3Texture = SetTexture(fileBasePath, textPaths, "pPOL3", true);
            Texture2D pBOW1Texture = SetTexture(fileBasePath, textPaths, "pBOW1", true);
            Texture2D pBOW2Texture = SetTexture(fileBasePath, textPaths, "pBOW2", true);
            Texture2D pBOW3Texture = SetTexture(fileBasePath, textPaths, "pBOW3", true);

            if (pONE1Texture != null)
            {
                FillPlayerTexture(layer, pONE1Texture, "combat/pONE1");
                FillPlayerTexture(layer, pONE2Texture, "combat/pONE2");
                FillPlayerTexture(layer, pONE3Texture, "combat/pONE3");
            }
            if (pPOL1Texture != null)
            {
                FillPlayerTexture(layer, pPOL1Texture, "combat/pPOL1");
                FillPlayerTexture(layer, pPOL2Texture, "combat/pPOL2");
                FillPlayerTexture(layer, pPOL3Texture, "combat/pPOL3");
            }
            if (pBOW1Texture != null)
            {
                FillPlayerTexture(layer, pBOW1Texture, "combat/pBOW1");
                FillPlayerTexture(layer, pBOW2Texture, "combat/pBOW2");
                FillPlayerTexture(layer, pBOW3Texture, "combat/pBOW3");
            }
        }

        private void SetBaseTextures(string layer, string fileBasePath, string filePath, Dictionary<string, string> textPaths)
        {
            Texture2D p1Texture = SetTexture(fileBasePath, textPaths, "p1", false);
            Texture2D p1BTexture = SetTexture(fileBasePath, textPaths, "p1B", false);
            Texture2D p1CTexture = SetTexture(fileBasePath, textPaths, "p1C", false);
            Texture2D p2Texture = SetTexture(fileBasePath, textPaths, "p2", false);
            Texture2D p3Texture = SetTexture(fileBasePath, textPaths, "p3", false);
            if (layer == "pritool")
            {
                string fishing_test = filePath;
                //Debug.Log("fishing_test " + fishing_test);
                if (fishing_test.Contains("6tla"))// && fishing_test.Contains("p3"))
                {
                    string[] p3pathParts = textPaths["p3"].Split('_');

                    string replacer = p3pathParts[6];
                    p3Texture = Resources.Load<Texture2D>(fileBasePath + textPaths["p3"].Replace(replacer, "roda").Replace(".png", ""));
                }
            }
            Texture2D p4Texture = SetTexture(fileBasePath, textPaths, "p4", false);

            FillPlayerTexture(layer, p1Texture, "p1");
            FillPlayerTexture(layer, p1BTexture, "p1B");
            FillPlayerTexture(layer, p1CTexture, "p1C");
            FillPlayerTexture(layer, p2Texture, "p2");
            FillPlayerTexture(layer, p3Texture, "p3");
            FillPlayerTexture(layer, p4Texture, "p4");
        }

        private void FillPlayerTexture(string layer, Texture2D pTexture, string key)
        {
            if (SpriteSetPath.EndsWith("/")) SpriteSetPath = SpriteSetPath.TrimEnd('/');
            Texture2D originp1 = Resources.Load<Texture2D>(SpriteSetPath + "/" + key + "/" + layer);
            if (pTexture != null && originp1 != null)
            {
                Color[] newPixelsp1 = pTexture.GetPixels();
                originp1.SetPixels(newPixelsp1);
                originp1.Apply();
            }
        }

        private static Texture2D SetTexture(string fileBasePath, Dictionary<string, string> textPaths, string textureKey, bool combatAnimation)
        {
            if (!fileBasePath.EndsWith("/")) fileBasePath += "/";
            Texture2D pTexture = null;
            if (textPaths[textureKey] != "")
            {
                pTexture = Resources.Load<Texture2D>(fileBasePath + textPaths[textureKey].Replace(".png", ""));
                if (combatAnimation)
                    if (pTexture == null)
                        pTexture = Resources.Load<Texture2D>(fileBasePath + "combat/" + textPaths[textureKey].Replace(".png", ""));
                //Debug.Log(fileBasePath + "combat/" + textPaths[textureKey].Replace(".png", ""));
            }

            return pTexture;
        }

        private static Dictionary<string, string> SetTextureFilePaths(string filePath, string[] partedName)
        {
            Dictionary<string, string> textPaths = new Dictionary<string, string>()
            {
                { "p1", "" },
                { "p1B", "" },
                { "p1C", "" },
                { "p2", "" },
                { "p3", "" },
                { "p4", "" },
                { "pONE1", "" },
                { "pONE2", "" },
                { "pONE3", "" },
                { "pPOL1", "" },
                { "pPOL2", "" },
                { "pPOL3", "" },
                { "pBOW1", "" },
                { "pBOW2", "" },
                { "pBOW3", "" },
            };
            Dictionary<string, string> newPaths = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> tp in textPaths)
            {
                if (filePath.Contains("char_a_" + partedName[2]))
                    newPaths[tp.Key] = filePath.Replace("_" + partedName[2], "_" + tp.Key);
                else newPaths[tp.Key] = tp.Value;
                //Debug.Log(newPaths[tp.Key]);
            }

            return newPaths;
        }

        public void TestInputButton(string trigger)
        {
            if (trigger.Contains("draw") || trigger.Contains("combat")) inCombat = true;
            if (trigger.Contains("sheath")) inCombat = false;
            testTrigger = trigger;
        }

        public void SwapHatButton()
        {
            if (hat.activeInHierarchy)
            {
                hat.SetActive(false);
                hair.SetActive(true);
            }
            else
            {
                hat.SetActive(true);
                hair.SetActive(false);
            }
        }

        public void SwapTextureButton(Texture2D newTexture)
        {
            Debug.Log(newTexture);
            if (newTexture != null)
            {
                Color[] changedPixels = newTexture.GetPixels();
                toolTexture.SetPixels(changedPixels);
                toolTexture.Apply();
            }
        }

        private void PlayerMovement()
        {
            Vector2 move = new Vector2(xInput * movementSpeed * Time.deltaTime, yInput * movementSpeed * Time.deltaTime);
            rigidBody2D.MovePosition(rigidBody2D.position + move);
        }

        private void PlayerMovementInput()
        {
            yInput = Input.GetAxisRaw("Vertical");
            xInput = Input.GetAxisRaw("Horizontal");

            if (xInput != 0 && yInput != 0)
            {
                xInput *= .71f;
                yInput *= .71f;
            }
            if (xInput != 0 || yInput != 0)
            {
                //capture movement
                if (xInput < 0) playerDirection = Direction.left;
                else if (xInput > 0) playerDirection = Direction.right;
                else if (yInput < 0) playerDirection = Direction.down;
                else playerDirection = Direction.up;
            }
            else if (xInput == 0 && yInput == 0)
            {
                moveType = MoveType.idle;
            }
            //check if player walks
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                moveType = MoveType.walking;
                movementSpeed = walkingSpeed;
            }
            else
            {
                moveType = MoveType.running;
                movementSpeed = runningSpeed;
            }

            if (inCombat) movementSpeed = combatMoveSpeed;
        }

        private void ResetAnimationTriggers()
        {
            moveType = MoveType.idle;
            //playerDirection = Direction.none;
        }

        private void ResetMovement()
        {
            //reset movement
            xInput = 0f;
            yInput = 0f;
        }
    }
}