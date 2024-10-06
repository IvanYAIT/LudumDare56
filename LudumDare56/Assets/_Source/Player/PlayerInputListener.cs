using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerInputListener : AInputListener
    {
        public LayerMask mask;

        private int id;
        private PlayerData _data;
        private PlayerController _controller;
        private Transform _cameraPosition;
        private PickUpData _pickUpData;
        private PickUpSystem _pickUpSystem;

        [Inject]
        public void Construct(PlayerData data, PlayerController controller, PickUpData pickUpData, PickUpSystem pickUpSystem)
        {
            _data = data;
            _controller = controller;
            _cameraPosition = _data.CameraPosition;
            _pickUpData = pickUpData;
            _pickUpSystem = pickUpSystem;
            id = (int)Mathf.Log(mask.value, 2);
            _input = true;
        }

        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        void Update()
        {
            if (_input)
            {
                Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                Vector2 rotateDir = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

                _controller.Rotate(rotateDir, _data.CameraTransform, _data.BodyTransform, _data.RotateSpeed);
                _controller.Move(moveDir, _data.CharacterController, _data.BodyTransform, _data.MoveSpeed);

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hitInfo, _pickUpData.PickUpDistance, _pickUpData.ItemLayerMask))
                {
                    if (Input.GetKey(KeyCode.E) && _pickUpData.InventoryTransform.childCount == 0)
                    {
                        _pickUpSystem.PickUp(hitInfo.transform, _pickUpData.InventoryTransform);
                    }
                }

                if (Input.GetKey(KeyCode.Q) && _pickUpData.InventoryTransform.childCount >= 1)
                    _pickUpSystem.Drop(_pickUpData.InventoryTransform.GetChild(0));
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if(other.gameObject.layer == id && Input.GetKeyDown(KeyCode.E))
            {
                other.GetComponent<InputChanger>().SwitchInput();
            }
        }

        public override void TurnInput()
        {
            base.TurnInput();
            if (_input)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Camera.main.transform.parent = _cameraPosition;
                Camera.main.transform.localPosition = Vector3.zero;
                Camera.main.transform.rotation = Quaternion.identity;
            }
            transform.GetChild(0).gameObject.SetActive(!transform.GetChild(0).gameObject.activeInHierarchy);
        }
    }
}