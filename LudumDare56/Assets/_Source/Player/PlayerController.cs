using UnityEngine;

namespace Player
{
    public class PlayerController
    {
        private float _xRotation;

        public void Move(Vector3 dir, CharacterController characterController, Transform playerTransform, float speed)
        {
            Vector3 moveDir = playerTransform.right * dir.x + playerTransform.forward * dir.z;

            characterController.Move(moveDir * speed * Time.deltaTime);
        }

        public void Rotate(Vector2 dir,Transform cameraTransfom, Transform playerTransform, float speed)
        {
            _xRotation -= dir.y *speed * Time.deltaTime;
            _xRotation = Mathf.Clamp(_xRotation, -90, 75);

            cameraTransfom.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
            playerTransform.Rotate(Vector3.up * (dir.x * speed * Time.deltaTime));
        }
    }
}