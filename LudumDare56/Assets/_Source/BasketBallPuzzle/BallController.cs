using UnityEngine;

namespace BasketBallPuzzle
{
    public class BallController
    {
        public void Rotate(Transform ballTransform, RaycastHit hitInfo)
        {
            Vector3 dir = hitInfo.point - ballTransform.position;
            ballTransform.rotation = Quaternion.LookRotation(dir);
        }

        public void Throw(Rigidbody rb, Vector3 dir, float force)
        {
            if (rb.isKinematic)
            {
                rb.isKinematic = false;
                rb.AddForce(dir * force, ForceMode.Impulse);
            }
        }
    }
}