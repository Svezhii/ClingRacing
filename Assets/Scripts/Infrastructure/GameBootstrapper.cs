using Infrastructure.States;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        public LoadingCurtain сurtain;
        
        private Game _game;

        private void Awake()
        {
            _game = new Game(this, сurtain);
            _game.StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}