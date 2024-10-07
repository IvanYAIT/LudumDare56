using DG.Tweening;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace MusicBoxPuzzle
{
    public class MusicBoxController
    {
        private float _dir =1;
        private int helper = 0;
        Vector3 rot = new Vector3(15, 0, 0);

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

        public void Check(Slider slider, Slider bgSlider, Transform cap, GameObject toy, Transform inventory)
        {
            if(slider.value >= bgSlider.value - 2 && slider.value <= bgSlider.value + 2)
            {
                Open(cap);
            } else
            {
                if(helper < 5)
                    Close(cap);
            }
            if(helper >= 5)
            {
                slider.gameObject.SetActive(false);
                bgSlider.gameObject.SetActive(false);
                toy.SetActive(true);
            }
        }

        public void Open(Transform cap)
        {
            if(helper < 5)
            {
                helper++;
                cap.DORotate(-rot, 1, RotateMode.LocalAxisAdd);
            }
        }

        public void Close(Transform cap)
        {
            if(helper > 0)
            {
                cap.DORotate(rot, 1, RotateMode.LocalAxisAdd);
                helper--;
            }
        }
    }
}