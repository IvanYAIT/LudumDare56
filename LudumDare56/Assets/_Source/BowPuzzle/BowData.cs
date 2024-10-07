using UnityEngine;

namespace BowPuzzle
{
    public class BowData : MonoBehaviour
    {
        [SerializeField] private Transform arrowTransform;
        [SerializeField] private Rigidbody arrowRb;
        [SerializeField] private float maxShootForece;
        [SerializeField] private float forcePerPress;

        public Transform ArrowTransform => arrowTransform;
        public Rigidbody ArrowRb => arrowRb;
        public float MaxShootForece => maxShootForece;
        public float ForcePerPress => forcePerPress;
    }
}