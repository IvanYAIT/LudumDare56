using TMPro;
using UnityEngine;

namespace QTE
{
    public class QTEView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI keyText;
        [SerializeField] private TextMeshProUGUI timerText;

        public GameObject KeyTextObject => keyText.gameObject;
        public GameObject TimerTextObject => timerText.gameObject;

        public void SetKey(string key) =>
            keyText.text += $"[{key}] ";

        public void ResetText()
        {
            keyText.text = "";
            timerText.text = "";
        }
        public void SetTimer(float time) =>
            timerText.text = $"{time}";
    }
}