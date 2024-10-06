using UnityEngine;
using UnityEngine.UI;

public class TutorialData : MonoBehaviour
{
    [SerializeField] private GameObject baskteBallPuzzleTutor;
    [SerializeField] private GameObject bowPuzzleTutor;
    [SerializeField] private GameObject musicBoxPuzzleTutor;
    [SerializeField] private Button baskteBallPuzzleTutorBtn;
    [SerializeField] private Button bowPuzzleTutorBtn;
    [SerializeField] private Button musicBoxPuzzleTutorBtn;

    public GameObject BasketBAllPuzzleTutor => baskteBallPuzzleTutor;
    public GameObject BowPuzzleTutor => bowPuzzleTutor;
    public GameObject MusicBoxPuzzleTutor => musicBoxPuzzleTutor;
    public Button BaskteBallPuzzleTutorBtn => baskteBallPuzzleTutorBtn;
    public Button BowPuzzleTutorBtn => bowPuzzleTutorBtn;
    public Button MusicBoxPuzzleTutorBtn => musicBoxPuzzleTutorBtn;
}