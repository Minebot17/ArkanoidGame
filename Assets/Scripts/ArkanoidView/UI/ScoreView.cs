using ArkanoidModel.Core;
using TMPro;
using UnityEngine;
using Zenject;

namespace ArkanoidView.UI
{
    public class ScoreView : MonoBehaviour // TODO полностью убрать монобехи с помощью ITickable и IInitializable и переделать модель на зенжект
    {
        [SerializeField]
        private TextMeshProUGUI _scoreValueText;
        
        private IScoreManager _scoreManager;

        [Inject]
        public void Construct(IScoreManager scoreManager)
        {
            _scoreManager = scoreManager;

            _scoreManager.OnScoreChanged += OnScoreChanged;
        }

        private void OnScoreChanged(int deltaScore)
        {
            _scoreValueText.text = _scoreManager.Score.ToString();
        }
    }
}