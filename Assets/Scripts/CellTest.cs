using UnityEngine;
using UnityEngine.EventSystems;

public class CellTest : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private CellType data;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Backpack.instance.DataCell = data;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Backpack.instance.DataCell = CellType.None;
    }
}
