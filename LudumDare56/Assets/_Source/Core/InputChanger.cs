using UnityEngine;

public class InputChanger : MonoBehaviour
{
    [SerializeField] private AInputListener playerlistener;
    [SerializeField] private AInputListener puzzleListener;

    public void SwitchInput()
    {
        playerlistener.TurnInput();
        puzzleListener.TurnInput();
    }
}
