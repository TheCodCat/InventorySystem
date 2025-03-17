using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CellUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private CellType data;
    [SerializeField] private Image image;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Backpack.instance.DataCell = data;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Backpack.instance.DataCell = CellType.None;
    }
    public void ChangeView(CellType cell, bool value)
    {
        if (cell.Equals(data))
        {
            if (value)
            {
                image.sprite = Backpack.instance.CellDatas.FirstOrDefault(x => x.CellType.Equals(cell)).ItemData.Sprite;
            }
            else
                image.sprite = null;
        }
    }
}
