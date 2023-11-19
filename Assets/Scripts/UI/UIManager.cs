using TMPro;
using UnityEngine;
using DG.Tweening;
using System;

namespace Denis
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager instance;

        [Header("Interact Label")]
        [SerializeField] CanvasGroup interactLabelGroup;
        [SerializeField] TMP_Text interactLabelText;

        [Header("UI Windows")]
        [SerializeField] ShopController shopController;
        [SerializeField] CustomizationController customizationController;
        [SerializeField] InventoryController inventoryController;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
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
    }
}
