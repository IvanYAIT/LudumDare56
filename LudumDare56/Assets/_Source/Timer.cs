using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject loseScreen;

    private float _timer;
    private bool _stopTimer;

    void Update()
    {
        if (!_stopTimer)
        {
            _timer += Time.deltaTime;

            int hours = Mathf.FloorToInt(_timer / 3600f);
            int minutes = Mathf.FloorToInt((_timer - hours * 3600f) / 60f);
            int seconds = Mathf.FloorToInt((_timer - hours * 3600f) - (minutes * 60f));

            timerText.text = $"{minutes:D2}:{seconds:D2}";

            if (minutes >= 6)
            {
                loseScreen.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void StopTimer()
    {
        _stopTimer = true;
    }
}
