using UnityEngine;

namespace Player
{
    public class PickUpData : MonoBehaviour
    {
        [SerializeField] private LayerMask itemLayerMask;
        [SerializeField] private float pickUpDistance;
        [SerializeField] private Transform inventoryTransform;

        public LayerMask ItemLayerMask => itemLayerMask;
        public float PickUpDistance => pickUpDistance;
        public Transform InventoryTransform => inventoryTransform;
    }
}