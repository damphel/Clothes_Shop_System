using UnityEngine;

namespace Denis
{
    public class DoUIInteractLabel : MonoBehaviour
    {
        public void DoActiveLabel()
        {
            UIManager.instance.ActiveInteractLabel();
        }

        public void DoDeactivateLabel()
        {
            UIManager.instance.DeActiveInteractLabel();
        }
    }
}
