using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button backBtn;

    private bool _hideCursor;

    private void Awake()
    {
        backBtn.onClick.AddListener(UnPause);
    }

    private void OnDestroy()
    {
        backBtn.onClick.RemoveListener(UnPause);
    }

    public void Pause(bool fromPlayer)
    {
        gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        _hideCursor = fromPlayer;
    }

    public void UnPause()
    {
        gameObject.SetActive(false);
        if (_hideCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        Time.timeScale = 1;
    }
}
