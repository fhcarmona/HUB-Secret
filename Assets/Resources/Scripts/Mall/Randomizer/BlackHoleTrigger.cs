using FMOD.Studio;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackHoleTrigger : MonoBehaviour
{
    public EventManager eventManager;
    public GameObject gameOverScreen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(GameOver());
        }
    }

    private IEnumerator GameOver()
    {
        eventManager.eventInstance.stop(STOP_MODE.IMMEDIATE);
        gameOverScreen.SetActive(true);

        yield return new WaitForSeconds(5);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("MainMenu");
    }


}
