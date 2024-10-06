using UnityEngine;

namespace MusicBoxPuzzle
{
    public class MusicBoxChecker : MonoBehaviour
    {
        [SerializeField] private LayerMask itemLayerMask;
        [SerializeField] private Transform handlePlace;

        private int _itemLayer;

        private void Awake()
        {
            _itemLayer = (int)Mathf.Log(itemLayerMask.value, 2);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == _itemLayer)
            {
                Handle handle;
                other.TryGetComponent(out handle);
                if (handle != null)
                {
                    other.transform.parent = handlePlace;
                    other.transform.position = handlePlace.position;
                    other.transform.rotation = handlePlace.rotation;
                }
            }
        }
    }
}