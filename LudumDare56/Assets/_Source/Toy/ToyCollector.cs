using TinyToy;
using UnityEngine;

public class ToyCollector : MonoBehaviour
{
    [SerializeField] private LayerMask toyLayerMask;
    [SerializeField] private ToyView view;

    private int _toyLayer;
    private int _toyCount;

    private void Awake()
    {
        _toyLayer = (int)Mathf.Log(toyLayerMask.value, 2);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == _toyLayer)
        {
            Toy currentToy;
            other.TryGetComponent<Toy>(out currentToy);
            if(currentToy != null)
            {
                _toyCount++;
                view.SetToyCount(_toyCount);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == _toyLayer)
        {
            Toy currentToy;
            other.TryGetComponent<Toy>(out currentToy);
            if (currentToy != null)
            {
                _toyCount--;
                view.SetToyCount(_toyCount);
            }
        }
    }
}
