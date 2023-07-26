using UnityEngine;

namespace RMS
{
    public class QuitController : MonoBehaviour
    {
        public void OnClickCancel()
        {
            gameObject.SetActive(false);
        }

        public void OnClickConfirm()
        {
            Application.Quit();
        }
    }
}
