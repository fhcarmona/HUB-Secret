using System;
using UnityEngine;

namespace RMS
{
    [Serializable]
    public class InventoryModel
    {
        public bool hasLantern { get; set; }
        public bool hasKeyCard { get; set; }
        public bool hasRadio { get; set; }
        public bool hasClipboard { get; set; }
        public int tokenQuantity { get; set; }

        public InventoryModel()
        {
            hasLantern = false;
            hasKeyCard = false;
            hasRadio = false;
            hasClipboard = false;
            tokenQuantity = 0;
        }

        public void Log()
        {
            Debug.Log($"hasLantern[{hasLantern}], hasKeyCard[{hasKeyCard}], hasRadio[{hasRadio}], hasClipboard[{hasClipboard}], tokenQuantity[{tokenQuantity}]");
        }
    }
}