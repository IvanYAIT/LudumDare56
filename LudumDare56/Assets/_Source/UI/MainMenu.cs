using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenuUI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button playBtn;
        [SerializeField] private Button tutorialBtn;
        [SerializeField] private Button settingsBtn;
        [SerializeField] private Button settingsBackBtn;
        [SerializeField] private GameObject settings;
        [SerializeField] private GameObject tutorial;

        void Start()
        {
            playBtn.onClick.AddListener(Play);
            tutorialBtn.onClick.AddListener(() => { OpenClosePanel(tutorial, gameObject); });
            settingsBtn.onClick.AddListener(() => { OpenClosePanel(settings, gameObject); });
            settingsBackBtn.onClick.AddListener(() => { OpenClosePanel(gameObject, settings); });
        }

        private void OnDestroy()
        {
            playBtn.onClick.RemoveListener(Play);
        }

        private void Play()=>
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        private void OpenClosePanel(GameObject openPanel, GameObject closePanel)
        {
            openPanel.SetActive(true);
            closePanel.SetActive(false);
        }

    }
}