using System;
using System.Linq;
using UnityEngine;

public class BackpackUI : MonoBehaviour
{
    [SerializeField] private Item[] items;//массив предметов
    [SerializeField] private CellUI[] cellUIs;//массив клеток
    [SerializeField] private Canvas canvas;//канвас
    private void OnMouseDown()
    {
        Backpack.instance.currentCellType = CellType.None;
        canvas.gameObject.SetActive(true);// включение инвенторя
    }
    private void OnMouseUp()
    {
        try
        {
            canvas.gameObject.SetActive(false);//выключение инвенторя
            //логика
            if (Backpack.instance.currentCellType.Equals(CellType.None)) return;
            Item item = null;
            Backpack.instance.Items.ToList().ForEach(x =>
            {
                if (x != null && x.ItemData.CellType == Backpack.instance.currentCellType)
                {
                    item = x;
                }
            });
            item.gameObject.SetActive(true);
            Backpack.instance.UploadItem(items.ToList().IndexOf(item));//добавление в инвентарь

        }
        catch (NullReferenceException ex)
        {
            Debug.Log("Слот пустой");
        }
    }
    //обновление UI в зависимости от инвенторя
    public void ChangeView(Item[] newItems)//смена иконки
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
