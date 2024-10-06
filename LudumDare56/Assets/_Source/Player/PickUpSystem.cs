using UnityEngine;

namespace Player
{
    public class PickUpSystem
    {
        public void PickUp(Transform itemForPick, Transform inventory)
        {
            itemForPick.parent = inventory;
            itemForPick.localPosition = Vector3.zero;
            itemForPick.rotation = Quaternion.identity;
            itemForPick.GetComponent<Rigidbody>().isKinematic = true;
        }

        public void Drop(Transform pickedUpItem)
        {
            pickedUpItem.parent = null;
            pickedUpItem.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}