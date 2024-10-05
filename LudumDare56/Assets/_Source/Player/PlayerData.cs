using UnityEngine;

namespace Player
{
    public class PlayerData : MonoBehaviour
    {
        [SerializeField] private Transform bodyTransform;
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private Transform cameraPosition;
        [SerializeField] private CharacterController characterController;
        [SerializeField] private float rotateSpeed;
        [SerializeField] private float moveSpeed;

        public Transform BodyTransform => bodyTransform;
        public Transform CameraTransform => cameraTransform;
        public Transform CameraPosition => cameraPosition;
        public CharacterController CharacterController => characterController;
        public float RotateSpeed => rotateSpeed;
        public float MoveSpeed => moveSpeed;
    }
}