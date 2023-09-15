using RMS.Controller;
using TMPro;
using UnityEngine;

namespace RMS.Player
{
    public class InteractiveObjects : MonoBehaviour
    {
        public GameObject hitPopup;

        private TextMeshProUGUI[] popupTMP;
        private bool isRaycastHitting;
        private RaycastHit hit;

        private const int rayDistance = 2; // Units

        public void Awake()
        {
            popupTMP = hitPopup.GetComponentsInChildren<TextMeshProUGUI>(true);
        }

        public void Update()
        {
            isRaycastHitting = GetRaycastObject(out hit);

            SetRaycastDescription();
            CheckInteractionAction();
        }

        public void SetRaycastDescription()
        {
            // Hit interactive object
            if (isRaycastHitting)
            {
                if (hit.transform.TryGetComponent(out ItemController popup))
                {
                    hitPopup.SetActive(true);

                    popupTMP[0].text = popup.title;
                    popupTMP[1].text = popup.description;
                }
            }
            else
            {
                hitPopup.SetActive(false);
            }
        }

        public void CheckInteractionAction()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (isRaycastHitting)
                {
                    if (hit.transform.TryGetComponent(out DoorController door))
                        door.ChangeDoorAnimation();
                }
            }
        }

        public bool GetRaycastObject(out RaycastHit hit)
        {
            return Physics.Raycast(transform.position, transform.rotation * new Vector3(0, 0, rayDistance), out hit, rayDistance);
        }
    }
}