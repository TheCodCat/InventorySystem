using UnityEngine;

[CreateAssetMenu(menuName = "Item", fileName = "New item", order = 1)]
public class ItemData : ScriptableObject
{
    public string Name;
    public int ID;
    public CellType CellType;
    public float Weight;
    public Sprite Icon;
}
