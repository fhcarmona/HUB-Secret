using System;
using UnityEngine;

namespace RMS
{
    [Serializable]
    public class PlayerModel
    {
        public float xPosition { get; set; }
        public float yPosition { get; set; }
        public float zPosition { get; set; }
        public float xRotation { get; set; }
        public float yRotation { get; set; }
        public float zRotation { get; set; }
        public float wRotation { get; set; }
        public InventoryModel inventory { get; set; }
        public QuestModel quest { get; set; }

        public PlayerModel()
        {
            xPosition = 2.5f;
            yPosition = 4.5f;
            zPosition = 11;
            xRotation = 0;
            yRotation = 1;
            zRotation = 0;
            wRotation = 0;
            inventory = new InventoryModel();
            quest = new QuestModel
            {
                route = new bool[6]
            };
        }

        public void Log()
        {
            Debug.Log($"PlayerPosition[{xPosition}, {yPosition}, {zPosition}], PlayerRotation[{xRotation}, {yRotation}, {zRotation}, {wRotation}]");
            inventory.Log();
        }
    }
}