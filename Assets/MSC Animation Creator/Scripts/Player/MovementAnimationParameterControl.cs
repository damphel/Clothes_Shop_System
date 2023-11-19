using UnityEngine;

namespace ManaSeedTools.CharacterAnimator
{
    public class MovementAnimationParameterControl : MonoBehaviour
    {
        private Animator animator;

        //use this for initialisation
        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            EventHandler.MovementEvent += SetAnimationParameters;
        }

        private void OnDisable()
        {
            EventHandler.MovementEvent -= SetAnimationParameters;
        }

        public void SetAnimationParameters(float inputX, float inputY,
            MoveType moveType, Direction direction, Player character, string testTrigger)
        {
            animator.SetFloat("xInput", inputX);
            animator.SetFloat("yInput", inputY);
            animator.SetBool("isRunning", true);
            animator.SetInteger("direction", (int)direction);

            switch (moveType)
            {
                case MoveType.walking:
                    animator.SetBool("isWalking", true);
                    animator.SetBool("isRunning", false);
                    break;

                case MoveType.running:
                    animator.SetBool("isWalking", false);
                    animator.SetBool("isRunning", true);
                    break;

                case MoveType.idle:
                    animator.SetTrigger("idle");
                    break;
            }

            if (testTrigger != null)
            {
                string[] splitted = testTrigger.Split(',');
                foreach (string trigger in splitted)
                    animator.SetTrigger(trigger);
            }
        }
    }
}