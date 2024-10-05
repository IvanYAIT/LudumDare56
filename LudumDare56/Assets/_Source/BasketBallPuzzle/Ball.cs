using UnityEngine;

namespace BasketBallPuzzle
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private LayerMask deathZoneLayerMask;
        [SerializeField] private Rigidbody rb;

        private Vector3 _startPos;
        private int _deathZoneLayer;

        private void Awake()
        {
            _startPos = transform.position;
            _deathZoneLayer = (int)Mathf.Log(deathZoneLayerMask.value,2);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.layer == _deathZoneLayer)
            {
                transform.position = _startPos;
                transform.rotation = Quaternion.identity;
                rb.isKinematic = true;
            }
        }
    }
}