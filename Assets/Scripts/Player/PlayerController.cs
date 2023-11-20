using Denis.Shop.Items;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Denis.Player
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController instance; 

        [Header("Inputs")]
        [SerializeField] PlayerInput input;
        private InputAction moveAction;

        public PlayerInput Inputs { get { return input; } }

        [Header("Player")]
        [SerializeField] PlayerView playerView;
        [SerializeField] PlayerModel playerModel;
        [SerializeField] Rigidbody2D rb;
        [SerializeField] float moveSpeed = 5f;

        private Vector2 movement;

        public PlayerView _PlayerView { get { return playerView; } }
        public PlayerModel _PlayerModel { get {  return playerModel; } }

        private void Awake()
        {
            if(input == null) input = GetComponent<PlayerInput>();

            if (instance == null)
            { 
                instance = this;
            }
        }

        private void Start()
        {
            moveAction = input.actions.FindAction("Move");
        }

        private void FixedUpdate()
        {
            if (GameManager.instance._GameState == GameState.playing)
            {
                MovePlayer();
            }
        }

        public void MovePlayer()
        {
            movement = moveAction.ReadValue<Vector2>();
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }

        public void SetPlayerCustomClothes(Item item)
        {
            playerModel.SetPlayerClothesByItem(item);
            playerView.SetPlayerSpritesByItem(item);
        }

        public void RemovePlayerCustomClother(Item item)
        {
            playerModel.RemovePlayerClothesByItem(item);
            playerView.RemovePlayerSpritesByItem(item);
        }
    }
}
