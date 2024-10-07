using MusicBoxPuzzle;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace BowPuzzle
{
    public class BowInputListener : AInputListener
    {
        private BowData _bowData;
        private BowController _bowController;
        private Transform _cameraPosition;
        private LayerMask _shootZoneLayer;
        private GameObject _tutor;

        [Inject]
        public void Construct(BowData bowData, BowController bowController, CameraPositionData cameraPositionData, LayerMask shootZoneLayer, TutorialData tutorialData)
        {
            _bowData = bowData;
            _bowController = bowController;
            _cameraPosition = cameraPositionData.BowPuzzleCamera;
            _shootZoneLayer = shootZoneLayer;
            _tutor = tutorialData.BowPuzzleTutor;
            tutorialData.BowPuzzleTutorBtn.onClick.AddListener(CompleteTutor);
        }

        void Update()
        {
            if (_input)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, _shootZoneLayer))
                {
                    if(_bowData.ArrowRb.isKinematic)
                        _bowController.Rotate(_bowData.ArrowTransform, hitInfo);
                }

                if (Input.GetMouseButton(0))
                    _bowController.Charge(_bowData.MaxShootForece, _bowData.ForcePerPress);

                if (Input.GetMouseButtonUp(0))
                    _bowController.Shoot(_bowData.ArrowRb, _bowData.ArrowTransform.forward);
            }
        }

        public void CompleteTutor()
        {
            _input = true;
            _tutor.SetActive(false);
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
            base.TurnInput();
            _input = false;
        }
    }
}