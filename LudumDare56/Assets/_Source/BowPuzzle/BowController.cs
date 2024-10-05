using UnityEngine;

namespace BowPuzzle
{
    public class BowController
    {
        private float _shootForce = 0;

        public void Rotate(Transform arrowTransform, RaycastHit hitInfo)
        {
            Vector3 dir = hitInfo.point - arrowTransform.position;
            arrowTransform.rotation = Quaternion.LookRotation(dir);
        }

        public void Charge()
        {
            if(_shootForce <= 30)
                _shootForce += 0.1f;
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