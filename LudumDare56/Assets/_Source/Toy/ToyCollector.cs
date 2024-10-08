using TinyToy;
using UnityEngine;

public class ToyCollector : MonoBehaviour
{
    [SerializeField] private LayerMask toyLayerMask;
    [SerializeField] private ToyView view;
    [SerializeField] private Transform[] toyPlaces;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private Timer timer;

    private int _toyLayer;
    private int _toyCount;

    private void Awake()
    {
        _toyLayer = (int)Mathf.Log(toyLayerMask.value, 2);
    }

    private void Update()
    {
        if (_toyCount == 5)
        {
            winScreen.SetActive(true);
            Time.timeScale = 0;
            timer.StopTimer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == _toyLayer)
        {
            Toy currentToy;
            other.TryGetComponent<Toy>(out currentToy);
            if(currentToy != null)
            {
                currentToy.transform.parent = toyPlaces[_toyCount];
                currentToy.transform.localPosition = Vector3.zero;
                currentToy.transform.rotation = toyPlaces[_toyCount].rotation;
                currentToy.Rb.isKinematic = true;
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
