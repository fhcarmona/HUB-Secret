using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public TextMeshProUGUI clipboardPaper;
    [TextArea]
    public string[] paperContent;
    public int currentPaper;

    public const int initialPaper = 0;

    public void Start()
    {
        SetPaper(initialPaper);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Comma))
        {
            PreviousPaper();
        }
        else if (Input.GetKeyDown(KeyCode.Period))
        {
            NextPaper();
        }
    }

    public void SetPaper(int pageIndex)
    {
        if (paperContent?[pageIndex] != null)
        {
            clipboardPaper.text = paperContent[pageIndex];
        }
    }

    public void PreviousPaper()
    {
        if (currentPaper == 0)
            return;

        SetPaper(--currentPaper);
    }

    public void NextPaper()
    {
        if (currentPaper >= paperContent.Length)
            return;

        SetPaper(++currentPaper);
    }
}
