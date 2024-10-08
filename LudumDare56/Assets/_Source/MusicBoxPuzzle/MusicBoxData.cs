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
        [SerializeField] private Transform cap;
        [SerializeField] private GameObject toy;
        [SerializeField] private AudioSource audio;

        public Slider Slider => slider;
        public Slider BgSlider => bgSlider;
        public float SliderSpeed => sliderSpeed;
        public GameObject HandlePlace => handlePlace;
        public Transform Cap => cap;
        public GameObject Toy => toy;
        public AudioSource Audio => audio;
    }
}