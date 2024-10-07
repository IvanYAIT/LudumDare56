using UnityEngine;

namespace BowPuzzle
{
    public class BowController
    {
        private float _shootForce = 0;

        public void Rotate(Transform bowTransform, RaycastHit hitInfo)
        {
            Vector3 dir = hitInfo.point - bowTransform.position;
            bowTransform.rotation = Quaternion.LookRotation(dir);
        }

        public void Charge(float maxForce, float force)
        {
            if(_shootForce <= maxForce)
                _shootForce += force;
        }

        public void Shoot(Rigidbody rb, Vector3 dir)
        {
            if (rb.isKinematic)
            {
                rb.isKinematic = false;
                rb.AddForce(dir * _shootForce, ForceMode.Impulse);
                _shootForce = 0;
            }
        }
    }
}