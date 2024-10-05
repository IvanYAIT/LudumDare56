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

        [Inject]
        public void Construct(BallData ballData, BallController ballController, LayerMask shootZoneLayer, CameraPositionData cameraPositionData)
        {
            _ballData = ballData;
            _ballController = ballController;
            _shootZoneLayer = shootZoneLayer;
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

        public override void TurnInput()
        {
            base.TurnInput();
            if (_input)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Camera.main.transform.parent = _cameraPosition;
                Camera.main.transform.localPosition = Vector3.zero;
                Camera.main.transform.rotation = Quaternion.identity;
            }
        }
    }
}