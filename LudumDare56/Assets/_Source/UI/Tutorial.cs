using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private Transform[] tutorialPages;
    [SerializeField] private Transform leftPagePosition;
    [SerializeField] private Transform rightPagePosition;
    [SerializeField] private Button nextBtn;
    [SerializeField] private Button backBtn;
    [SerializeField] private GameObject mainMenuPanel;

    private int _curentPage;
    private Vector3 centerPos;

    void Start()
    {
        _curentPage = 0;
        nextBtn.onClick.AddListener(Next);
        backBtn.onClick.AddListener(Back);
        centerPos = tutorialPages[0].position;
    }

    private void OnDestroy()
    {
        nextBtn.onClick.RemoveListener(Next);
        backBtn.onClick.RemoveListener(Back);
    }

    private void Next()
    {
        _curentPage++;
        if (_curentPage >= tutorialPages.Length)
        {
            ResetPages();
        }
        else
        {
            nextBtn.interactable = false;
            backBtn.interactable = false;
            tutorialPages[_curentPage].DOMove(tutorialPages[_curentPage - 1].position, 1);
            tutorialPages[_curentPage-1].DOMove(leftPagePosition.position, 1).OnComplete(() =>
            {
                nextBtn.interactable = true;
                backBtn.interactable = true;
            });
        }
    }

    private void Back()
    {
        _curentPage--;
        if (_curentPage < 0)
        {
            ResetPages();
        }
        else
        {
            nextBtn.interactable = false;
            backBtn.interactable = false;
            tutorialPages[_curentPage].DOMove(tutorialPages[_curentPage + 1].position, 1);
            tutorialPages[_curentPage + 1].DOMove(rightPagePosition.position, 1).OnComplete(() =>
            {
                nextBtn.interactable = true;
                backBtn.interactable = true;
            });
        }
    }

    private void ResetPages()
    {
        gameObject.SetActive(false);
        mainMenuPanel.SetActive(true);
        _curentPage = 0;
        for (int i = 0; i < tutorialPages.Length; i++)
        {
            if (i == 0)
                tutorialPages[i].position = centerPos;
            else
                tutorialPages[i].position = rightPagePosition.position;
        }
    }
}
