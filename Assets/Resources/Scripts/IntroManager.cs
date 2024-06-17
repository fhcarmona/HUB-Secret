using RMS;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public GameObject[] screens;

    private int steps = -1;

    private const string mainMenuSceneName = "MainMenu";

    private void Awake()
    {
        ShowCurrentStep();
    }

    private void ShowCurrentStep()
    {
        steps++;

        if (steps == screens.Length)
            SceneManager.LoadScene(mainMenuSceneName);

        for (int index = 0; index < screens.Length; index++)
            screens[index].SetActive(index == steps);        
    }

    public void ContinueButton()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.clickUI, default);
        ShowCurrentStep();
    }    
}
