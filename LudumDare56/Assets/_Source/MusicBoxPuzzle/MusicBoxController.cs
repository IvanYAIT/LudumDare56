using UnityEngine;
using UnityEngine.UI;

namespace MusicBoxPuzzle
{
    public class MusicBoxController
    {
        private float _dir =1;
        public void MoveSlider(Slider slider, float speed)
        {
            slider.value += speed * _dir * Time.deltaTime;

            if (slider.value >= slider.maxValue || slider.value <= slider.minValue)
                _dir *= -1;
        }

        public void GeneratePoint(Slider bgSlider)
        {
            bgSlider.value = Random.Range(bgSlider.minValue, bgSlider.maxValue + 1);
        }

        public void Check(Slider slider, Slider bgSlider)
        {
            if(slider.value >= bgSlider.value - 1 && slider.value <= bgSlider.value + 1)
            {
                Debug.Log("Win");
            } else
            {
                Debug.Log("Lose");
            }
        }
    }
}