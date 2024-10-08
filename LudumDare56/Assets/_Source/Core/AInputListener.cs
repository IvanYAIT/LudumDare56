using UnityEngine;

public abstract class AInputListener : MonoBehaviour
{
    public bool _input;

    public virtual void TurnInput() =>
        _input = !_input;
}
