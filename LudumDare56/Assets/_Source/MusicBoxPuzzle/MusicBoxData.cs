using UnityEngine;
using UnityEngine.UI;

namespace MusicBoxPuzzle
{
    public class MusicBoxData : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        [SerializeField] private Slider bgSlider;
        [SerializeField] private float sliderSpeed;
        [SerializeField] private GameObject handlePlace;

        public Slider Slider => slider;
        public Slider BgSlider => bgSlider;
        public float SliderSpeed => sliderSpeed;
        public GameObject HandlePlace => handlePlace;
    }
}