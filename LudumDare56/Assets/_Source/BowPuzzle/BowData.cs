using UnityEngine;

namespace BowPuzzle
{
    public class BowData : MonoBehaviour
    {
        [SerializeField] private Transform arrowTransform;
        [SerializeField] private Transform bowTransform;
        [SerializeField] private Rigidbody arrowRb;
        [SerializeField] private float maxShootForece;
        [SerializeField] private float forcePerPress;

        public Transform ArrowTransform => arrowTransform;
        public Transform BowTransform => bowTransform;
        public Rigidbody ArrowRb => arrowRb;
        public float MaxShootForece => maxShootForece;
        public float ForcePerPress => forcePerPress;
    }
}