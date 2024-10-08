using UnityEngine;

public class CameraPositionData : MonoBehaviour
{
    [SerializeField] private Transform basketBallPuzzleCamera;
    [SerializeField] private Transform bowPuzzleCamera;
    [SerializeField] private Transform musicBoxCamera;

    public Transform BasketBallPuzzleCamera => basketBallPuzzleCamera;
    public Transform BowPuzzleCamera => bowPuzzleCamera;
    public Transform MusicBoxCamera => musicBoxCamera;
}
