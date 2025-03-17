using UnityEngine;

namespace Assets.Scripts.Models
{
    [System.Serializable]
    public class ItemData
    {
        public string ID;
        public string Name;
        public float Weight;
        public CellType CellType;
        public Sprite Sprite;

        public ItemData()
        {

        }
    }
}
