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
        public bool hasArtifact { get; set; }
        public bool hasClipboard { get; set; }
        public int tokenQuantity { get; set; }

        public InventoryModel()
        {
            hasLantern = false;
            hasKeyCard = false;
            hasRadio = false;
            hasArtifact = false;
            hasClipboard = false;
            tokenQuantity = 0;
        }

        public void Log()
        {
            Debug.Log($"hasLantern[{hasLantern}], hasKeyCard[{hasKeyCard}], hasRadio[{hasRadio}], hasArtifact[{hasArtifact}], hasClipboard[{hasClipboard}], tokenQuantity[{tokenQuantity}]");
        }
    }
}