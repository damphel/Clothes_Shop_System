using UnityEngine;

namespace Denis
{
    public enum GameState { playing, paused }

    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        private GameState _gameState = GameState.playing;

        public GameState _GameState { get { return _gameState; } set { _gameState = value; } }

        private void Awake()
        {
            if (instance == null)
                instance = this;
        }
    }
}
