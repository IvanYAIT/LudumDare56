using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndUI : MonoBehaviour
{
    [SerializeField] private Button mainMenuBtn;

    private void Awake()
    {
        mainMenuBtn.onClick.AddListener(End);
    }

    private void OnDestroy()
    {
        mainMenuBtn.onClick.RemoveListener(End);
    }

    public void End()=>
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
}
