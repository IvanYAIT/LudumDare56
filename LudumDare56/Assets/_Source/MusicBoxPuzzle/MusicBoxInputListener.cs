using DG.Tweening;
using UnityEngine;
using Zenject;

namespace MusicBoxPuzzle
{
    public class MusicBoxInputListener : AInputListener
    {
        [SerializeField] private Transform inventory;

        private MusicBoxController _musicBoxController;
        private MusicBoxData _musicBoxData;
        private Transform _cameraPosition;
        private GameObject _tutor;
        private GameObject _handlePlace;
        private Transform _handle;
        private AudioSource _source;
        private bool isFixed;

        [Inject]
        public void Constructor(MusicBoxController musicBoxController, MusicBoxData musicBoxData, CameraPositionData cameraPosition, TutorialData tutorialData)
        {
            _musicBoxController = musicBoxController;
            _musicBoxData = musicBoxData;
            _cameraPosition = cameraPosition.MusicBoxCamera;
            _tutor = tutorialData.MusicBoxPuzzleTutor;
            _handlePlace = musicBoxData.HandlePlace;
            _source = _musicBoxData.Audio;
            tutorialData.MusicBoxPuzzleTutorBtn.onClick.AddListener(CompleteTutor);
            _musicBoxController.GeneratePoint(_musicBoxData.BgSlider);
        }

        void Update()
        {
            if (_input)
            {
                _musicBoxController.MoveSlider(_musicBoxData.Slider, _musicBoxData.SliderSpeed);
                if (Input.GetMouseButtonDown(0))
                {
                    _musicBoxController.Check(_musicBoxData.Slider, _musicBoxData.BgSlider, _musicBoxData.Cap, _musicBoxData.Toy, inventory);
                    _musicBoxController.GeneratePoint(_musicBoxData.BgSlider);
                }
            }
        }

        public void CompleteTutor()
        {
            _input = true;
            _tutor.SetActive(false);
            if (isFixed)
            {
                _handle = _handlePlace.transform.GetChild(0);
                _handle.DOLocalRotate(new Vector3(180, 0, 0), 1).SetLoops(-1, LoopType.Incremental);
                _musicBoxData.Slider.gameObject.SetActive(_input);
                _musicBoxData.BgSlider.gameObject.SetActive(_input);
                _source.Play();
            }

            if (_input)
            {
                Camera.main.transform.parent = _cameraPosition;
                Camera.main.transform.localPosition = Vector3.zero;
                Camera.main.transform.rotation = _cameraPosition.rotation;
            }
        }

        public override void TurnInput()
        {
            if (!_input)
            {
                _tutor.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                _musicBoxData.Slider.gameObject.SetActive(false);
                _musicBoxData.BgSlider.gameObject.SetActive(false);
                DOTween.KillAll();
                _source.Pause();
            }
            base.TurnInput();
            _input = false;
            if (_handlePlace.transform.GetChild(0).childCount > 0)
                isFixed = true;
        }
    }
}