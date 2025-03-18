using UnityEngine;

[CreateAssetMenu(menuName = "Item", fileName = "New item", order = 1)]
public class ItemData : ScriptableObject//данные предмета
{
    public string Name;//название
    public int ID;//ид
    public CellType CellType;//тип
    public float Weight;//вес
    public Sprite Icon;//иконка
}
