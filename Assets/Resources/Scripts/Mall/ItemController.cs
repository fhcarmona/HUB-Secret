using UnityEngine;

namespace RMS.Controller
{
    public class ItemController : MonoBehaviour
    {
        [Header("Item")]
        public string title;
        [TextArea]
        public string description;

        public void PickupItem()
        {
            if (name.Equals("keycard"))
            {
                DataPersistenceSystem.playerModel.inventory.hasKeyCard = true;
            }
            else if (name.Equals("radio"))
            {
                DataPersistenceSystem.playerModel.inventory.hasRadio = true;
            }

            Destroy(gameObject);
        }
    }
}
