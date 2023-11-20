using TMPro;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.InputSystem;
using Denis.Shop;
using Denis.Inventory;
using Denis.Customization;

namespace Denis
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager instance;

        [Header("Inputs")]
        [SerializeField] InputActionReference pauseInput;

        [Header("Interact Label")]
        [SerializeField] CanvasGroup interactLabelGroup;
        [SerializeField] TMP_Text interactLabelText;

        [Header("UI Windows")]
        [SerializeField] CanvasGroup itemsCanvas;
        [Space(5)]
        [SerializeField] ShopController shopController;
        [SerializeField] CustomizationController customizationController;
        [SerializeField] InventoryController inventoryController;

        public ShopController ShopController { get { return shopController; } }
        public CustomizationController CustomizationController { get { return customizationController; } }
        public InventoryController InventoryController { get { return inventoryController; } }


        private void OnEnable()
        {
            pauseInput.action.performed += DoByGameState;
        }

        private void OnDisable()
        {
            pauseInput.action.performed -= DoByGameState;
        }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }

            itemsCanvas.alpha = 0f;
        }

        public void ActiveInteractLabel(string newText = "")
        {
            interactLabelGroup.DOFade(1f, .5f);

            if (newText != "")
                interactLabelText.text = newText;
        }

        public void DeActiveInteractLabel()
        {
            interactLabelGroup.DOFade(0f, .5f);
        }

        public void DoActivateItemsCanvas()
        {
            GameManager.instance._GameState = GameState.paused;

            ShopController.gameObject.SetActive(true);

            DeActiveInteractLabel();

            shopController.OpenShop();

            itemsCanvas.DOFade(1f, .5f);
            itemsCanvas.interactable = true;
            itemsCanvas.blocksRaycasts = true;
        }        
        
        public void DoDeactivateItemsCanvas()
        {
            GameManager.instance._GameState = GameState.playing;

            itemsCanvas.DOFade(0f, .5f);
            itemsCanvas.interactable = false;
            itemsCanvas.blocksRaycasts = false;
        }

        public void DoByGameState(InputAction.CallbackContext context)
        {
            switch (GameManager.instance._GameState)
            {
                case GameState.playing:
                    DoActivateItemsCanvas();
                    ShopController.gameObject.SetActive(false);
                    break;
                case GameState.paused:
                    DoDeactivateItemsCanvas();
                    break;
                default:
                    break;
            }
        }
    }
}
