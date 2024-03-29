using UnityEngine;

public class SecurityCameraSystem : MonoBehaviour
{
    [SerializeField] private Camera primaryCamera;
    [SerializeField] private Camera secondaryCamera;
    [SerializeField] private PlayerMovement playerMovement;

    private bool isPlayerLooking;
    private Material originalMaterial;
    private Renderer cameraRenderer;

    public void Start()
    {
        cameraRenderer = GetComponent<Renderer>();
        originalMaterial = cameraRenderer.material;
    }

    public void Update()
    {
        if (!isPlayerLooking)
            return;

        if (Input.anyKeyDown)
            ChangeCamera();
    }

    private void ChangeToSecondaryCamera()
    {
        if (cameraRenderer.material == originalMaterial)
        {
            primaryCamera.gameObject.SetActive(false);
            secondaryCamera.gameObject.SetActive(true);

            isPlayerLooking = true;
            playerMovement.gameObject.SetActive(false);
        }
    }

    private void ChangeToPrimaryCamera()
    {
        secondaryCamera.gameObject.SetActive(false);
        primaryCamera.gameObject.SetActive(true);

        isPlayerLooking = false;
        playerMovement.gameObject.SetActive(true);
    }

    public void ChangeCamera()
    {
        if (primaryCamera == null || secondaryCamera == null)
            return;

        if (!primaryCamera.isActiveAndEnabled)
            ChangeToPrimaryCamera();
        else
            ChangeToSecondaryCamera();
    }
}
