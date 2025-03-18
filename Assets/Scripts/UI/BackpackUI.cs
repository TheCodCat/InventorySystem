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
        Backpack.instance.currentCellType = CellType.None;
        canvas.gameObject.SetActive(true);
    }
    private void OnMouseUp()
    {
        try
        {
            canvas.gameObject.SetActive(false);
            //логика
            if (Backpack.instance.currentCellType.Equals(CellType.None)) return;

            var item = Backpack.instance.Items.FirstOrDefault(x => x.ItemData.CellType.Equals(Backpack.instance.currentCellType));
            item.gameObject.SetActive(true);
            Backpack.instance.UploadItem(items.ToList().IndexOf(item));
            Debug.Log(item.ItemData.Name);

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
            if (items[i] == null)
            {
                cellUIs[i].ChangeIcon(null);
                continue;
            }

            if (items[i].ItemData.CellType.Equals(cellUIs[i].CellType))
            {
                cellUIs[i].ChangeIcon(items[i].ItemData.Icon);
            }
        }
    }
}
