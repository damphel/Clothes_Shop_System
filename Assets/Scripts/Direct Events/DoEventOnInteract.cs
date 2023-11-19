using Denis.Player;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Denis.Events
{
    public class DoEventOnInteract : MonoBehaviour
    {
        [SerializeField] UnityEvent doOnInteractPressed;
        
        private InputAction interactAction;

        private void Start()
        {
            interactAction = PlayerController.instance.Inputs.actions.FindAction("Interact");

            interactAction.performed += CallUnityEvent;
        }

        public void CallUnityEvent(InputAction.CallbackContext context)
        {
            doOnInteractPressed.Invoke();
        }
    }
}
