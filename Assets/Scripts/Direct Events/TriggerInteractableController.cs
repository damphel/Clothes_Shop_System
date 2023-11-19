using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Denis
{
    public class TriggerInteractableController : MonoBehaviour
    {
        [SerializeField] InputActionReference interactAction;
        [SerializeField] string activatorTag = "Player";

        [SerializeField] UnityEvent doOnInteractCall;
        [SerializeField] UnityEvent doOnTriggerExit;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag(activatorTag))
            {
                interactAction.action.performed += CallInteraction;
                UIManager.instance.ActiveInteractLabel();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag(activatorTag))
            {
                interactAction.action.performed -= CallInteraction;
                UIManager.instance.DeActiveInteractLabel();
                doOnTriggerExit.Invoke();
            }
        }

        public void CallInteraction(InputAction.CallbackContext callback)
        {
            doOnInteractCall.Invoke();
        }
    }
}
