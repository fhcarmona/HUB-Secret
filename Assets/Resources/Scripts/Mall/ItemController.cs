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
            Debug.Log($"PickupItem.name: {name.ToLower()}");
            if (name.ToLower().Equals("keycard"))
            {
                DataPersistenceSystem.playerModel.inventory.hasKeyCard = true;
            }
            else if (name.ToLower().Equals("radio"))
            {
                DataPersistenceSystem.playerModel.inventory.hasRadio = true;
            }
            else if (name.ToLower().Equals("artifact"))
            {
                DataPersistenceSystem.playerModel.inventory.hasArtifact = true;
            }

            Destroy(gameObject);
        }
    }
}
