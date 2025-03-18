using System;
using System.Linq;
using UnityEngine;

public class BackpackUI : MonoBehaviour
{
    [SerializeField] private Item[] items;
    [SerializeField] private CellUI[] cellUIs;
    [SerializeField] private Canvas canvas;
    private void OnMouseDown()
    {
        canvas.gameObject.SetActive(true);
    }
    private void OnMouseUp()
    {
        try
        {
            canvas.gameObject.SetActive(false);
            //логика
            if (Backpack.instance.currentCellType.Equals(CellType.None)) return;
            string itemname = Backpack.instance.Items.FirstOrDefault(x => x.ItemData.CellType.Equals(Backpack.instance.currentCellType)).ToString();
            Debug.Log(itemname);
        }
        catch (NullReferenceException ex)
        {
            Debug.Log("Слот пустой");
        }
    }
    public void ChangeView(Item[] newItems)
    {
        items = newItems;
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null) continue;

            if (items[i].ItemData.CellType.Equals(cellUIs[i].CellType))
            {
                cellUIs[i].ChangeIcon(items[i].ItemData.Icon);
            }
        }
    }
}
