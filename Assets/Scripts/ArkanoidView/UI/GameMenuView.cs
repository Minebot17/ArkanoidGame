using ArkanoidModel.Core;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace ArkanoidView.UI
{
    public class GameMenuView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _titleText;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _restartButton;
        
        private IScoreManager _scoreManager;
        private GameModelHandler _gameModelHandler;

        [Inject]
        public void Construct(
            IScoreManager scoreManager,
            GameModelHandler gameModelHandler)
        {
            _scoreManager = scoreManager;
            _gameModelHandler = gameModelHandler;
        }
        
        private void Awake()
        {
            _continueButton.onClick.AddListener(OnContinueClick);
            _restartButton.onClick.AddListener(OnRestartClick);
        }

        public void Show(MenuMode menuMode)
        {
            gameObject.SetActive(true);

            switch (menuMode)
            {
                case MenuMode.Win:
                    _titleText.text = "Win";
                    _scoreText.text = $"Score: {_scoreManager.Score}";
                    _scoreText.gameObject.SetActive(true);
                    _continueButton.gameObject.SetActive(false);
                    _restartButton.gameObject.SetActive(true);
                    break;
                case MenuMode.Lose:
                    _titleText.text = "Lose";
                    _continueButton.gameObject.SetActive(false);
                    _restartButton.gameObject.SetActive(true);
                    break;
            }
        }
        
        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void OnContinueClick()
        {
            _gameModelHandler.IsPause = false;
        }

        private void OnRestartClick()
        {
            SceneManager.LoadScene(1);
        }

        public enum MenuMode
        {
            Pause, Win, Lose
        }
    }
}