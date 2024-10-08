using UnityEngine;

namespace BasketBallPuzzle
{
    public class BallData : MonoBehaviour
    {
        [SerializeField] private Transform ballTransform;
        [SerializeField] private Rigidbody ballRb;
        [SerializeField] private float throwForce;

        public Transform BallTransform => ballTransform;
        public Rigidbody BallRb => ballRb;
        public float ThrowForce => throwForce;
    }
}