using Denis.Player;
using UnityEngine;

namespace Denis.Camera
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] float FollowSpeed = 2f;
        [SerializeField] float yOffset = 1f;
        
        Transform target;

        void Start ()
        {
            target = PlayerController.instance.transform;
        }

        private void LateUpdate()
        {
            Vector3 newPos = new Vector3(target.position.x, target.position.y, this.transform.position.z);

            transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed*Time.deltaTime);
        }
    }
}
