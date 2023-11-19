using System;
using UnityEngine;
using UnityEngine.Events;

namespace Denis.Events
{
    [Serializable] public class TriggerEnterEvents : UnityEvent<Collider> { }
    [Serializable] public class TriggerExitEvents : UnityEvent<Collider> { }
    [Serializable] public class TriggerStayEvents : UnityEvent<Collider> { }

    public class DoEventOnTrigger : MonoBehaviour
    {
        [SerializeField] TriggerEnterEvents triggerEnterEvents = null;
        [SerializeField] TriggerExitEvents triggerExitEvents = null;
        [SerializeField] TriggerStayEvents triggerStayEvents = null;

        private void OnTriggerEnter(Collider other)
        {
            triggerEnterEvents.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            triggerExitEvents.Invoke(other);
        }

        private void OnTriggerStay(Collider other)
        {
            triggerStayEvents.Invoke(other);
        }
    }
}
