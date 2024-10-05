using UnityEngine;
using Zenject;

namespace BowPuzzle
{
    public class BowInputListener : AInputListener
    {
        private BowData _bowData;
        private BowController _bowController;
        private Transform _cameraPosition;
        private LayerMask _shootZoneLayer;

        [Inject]
        public void Construct(BowData bowData, BowController bowController, CameraPositionData cameraPositionData, LayerMask shootZoneLayer)
        {
            _bowData = bowData;
            _bowController = bowController;
            _cameraPosition = cameraPositionData.BowPuzzleCamera;
            _shootZoneLayer = shootZoneLayer;
        }

        void Update()
        {
            if (_input)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, _shootZoneLayer))
                {
                    _bowController.Rotate(_bowData.ArrowTransform, hitInfo);
                }

                if (Input.GetMouseButton(0))
                    _bowController.Charge();

                if (Input.GetMouseButtonUp(0))
                    _bowController.Shoot(_bowData.ArrowRb, _bowData.ArrowTransform.forward);
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