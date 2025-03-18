using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CellUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public CellType CellType;
    [SerializeField] private Image icon;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Backpack.instance.currentCellType = CellType;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Backpack.instance.currentCellType = CellType.None;
    }
    public void ChangeIcon(Sprite sprite)
    {
        icon.sprite = sprite;
    }
}
