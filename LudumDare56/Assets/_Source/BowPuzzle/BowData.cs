using UnityEngine;

namespace BowPuzzle
{
    public class BowData : MonoBehaviour
    {
        [SerializeField] private Transform arrowTransform;
        [SerializeField] private Rigidbody arrowRb;

        public Transform ArrowTransform => arrowTransform;
        public Rigidbody ArrowRb => arrowRb;
    }
}