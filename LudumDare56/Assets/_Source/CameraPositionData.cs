using UnityEngine;

public class CameraPositionData : MonoBehaviour
{
    [SerializeField] private Transform basketBallPuzzleCamera;
    [SerializeField] private Transform bowPuzzleCamera;

    public Transform BasketBallPuzzleCamera => basketBallPuzzleCamera;
    public Transform BowPuzzleCamera => bowPuzzleCamera;
}
