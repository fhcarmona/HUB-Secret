using FMOD.Studio;
using RMS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class CameraEvent : MonoBehaviour
{
    private Material originalMaterial;
    private Material replaceMaterial;
    private Renderer rendererComponent;
    private EventInstance whiteNoise;

    private const string AudioParamName = "CommunicationType";
    private const string MaterialName = "Material/Alien/WhiteNoise";

    public void Start()
    {
        rendererComponent = GetComponent<Renderer>();
        originalMaterial = rendererComponent.material;
        replaceMaterial = (Material) Resources.Load(MaterialName, typeof(Material)); ;
        whiteNoise = AudioManager.instance.CreateEventInstance(FMODEvents.instance.whiteNoise, transform.position);

        StartCoroutine(ExecuteEvent());
    }

    public IEnumerator ExecuteEvent()
    {
        EventInstance commEvent;

        rendererComponent.material = replaceMaterial;
        whiteNoise.start();

        yield return new WaitForSeconds(Random.Range(3, 6));

        commEvent = AudioManager.instance.PlayOneShot(FMODEvents.instance.strangeLanguage, transform.position, AudioParamName, Random.Range(0, 5));
        commEvent.getPlaybackState(out PLAYBACK_STATE state);

        while (state != PLAYBACK_STATE.STOPPED)
        {
            commEvent.getPlaybackState(out state);
            yield return new WaitForSeconds(1);
        }

        yield return new WaitUntil(() => state == PLAYBACK_STATE.STOPPED);

        whiteNoise.stop(STOP_MODE.IMMEDIATE);
        rendererComponent.material = originalMaterial;
        Destroy(this);
    }
}
