using TMPro;
using UnityEngine;

namespace TinyToy
{
    public class ToyView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI toyCount;

        public void SetToyCount(int amount) =>
            toyCount.text = $"{amount}/5";
    }
}