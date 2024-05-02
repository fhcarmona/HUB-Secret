using UnityEngine;

public class IntroManager : MonoBehaviour
{
    public GameObject[] screens;

    private int steps = -1;

    private void Start()
    {
        ShowCurrentStep();
    }

    private void ShowCurrentStep()
    {
        steps++;

        for (int index = 0; index < screens.Length; index++)
            screens[index].SetActive(index == steps);        
    }

    public void ContinueButton()
    {
        ShowCurrentStep();
    }    
}
