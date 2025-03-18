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
            Item item = null;
            Backpack.instance.Items.ToList().ForEach(x =>
            {
                if(x != null && x.ItemData.CellType == Backpack.instance.currentCellType)
                {
                    item = x;
                }
            });
            item.gameObject.SetActive(true);
            Backpack.instance.UploadItem(items.ToList().IndexOf(item));

        }
        catch (NullReferenceException ex)
        {
            Debug.Log("Слот пустой");
        }
    }
    //обновление UI в зависимости от инвенторя
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
