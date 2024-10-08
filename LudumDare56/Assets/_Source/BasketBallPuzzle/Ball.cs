using UnityEngine;

namespace BasketBallPuzzle
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private LayerMask deathZoneLayerMask;
        [SerializeField] private Rigidbody rb;

        private Vector3 _startPos;
        private Quaternion _startRot;
        private int _deathZoneLayer;

        private void Awake()
        {
            _startPos = transform.position;
            _startRot = transform.rotation;
            _deathZoneLayer = (int)Mathf.Log(deathZoneLayerMask.value,2);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.layer == _deathZoneLayer)
            {
                transform.position = _startPos + new Vector3(0,0.05f,0);
                transform.rotation = transform.parent.rotation;
                Quaternion rot = transform.rotation;
                rot.eulerAngles += new Vector3(90, 0, 0);
                transform.rotation = rot;
                rb.isKinematic = true;
            }
        }
    }
}