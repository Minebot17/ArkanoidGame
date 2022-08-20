using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ArkanoidView.UI
{
    public class StartMenuView : MonoBehaviour
    {
        [SerializeField] private Button _startButton;

        private void Awake()
        {
            _startButton.onClick.AddListener(OnStartClick);
        }
        
        private void OnStartClick()
        {
            SceneManager.LoadScene(1);
        }
    }
}