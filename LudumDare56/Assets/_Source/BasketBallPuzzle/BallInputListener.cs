using UnityEngine;
using Zenject;

namespace BasketBallPuzzle
{
    public class BallInputListener : AInputListener
    {
        private BallData _ballData;
        private BallController _ballController;
        private LayerMask _shootZoneLayer;
        private Transform _cameraPosition;
        private GameObject _tutor;

        [Inject]
        public void Construct(BallData ballData, BallController ballController, LayerMask shootZoneLayer, CameraPositionData cameraPositionData, TutorialData tutorialData)
        {
            _ballData = ballData;
            _ballController = ballController;
            _shootZoneLayer = shootZoneLayer;
            _tutor = tutorialData.BasketBAllPuzzleTutor;
            tutorialData.BaskteBallPuzzleTutorBtn.onClick.AddListener(CompleteTutor);
            _cameraPosition = cameraPositionData.BasketBallPuzzleCamera;
        }

        void Update()
        {
            if (_input)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, _shootZoneLayer))
                {
                    _ballController.Rotate(_ballData.BallTransform, hitInfo);
                }

                if (Input.GetMouseButtonDown(0))
                {
                    _ballController.Throw(_ballData.BallRb, _ballData.BallTransform.forward + new Vector3(0, 0.9f, 0), _ballData.ThrowForce);
                }
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