using UnityEngine;
using UnityEngine.Events;

public class Backpack : MonoBehaviour
{
    public static Backpack instance;
    [SerializeField] private Item[] items = new Item[] { };
    [SerializeField] private BackpackPointController backpackPointController;
    public CellType currentCellType;
    public UnityEvent<Item[]> OnInventoryChanged;
    public Item[] Items
    {
        get
        {
            return items;
        }
        set
        {
            items = value;
            OnInventoryChanged?.Invoke(value);
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void PutItem(Item item)
    {
        int index = item.ItemData.CellType switch
        {
            CellType.One => 0,
            CellType.Two => 1,
            CellType.Three => 2,
            _ => 0
        };
        Item[] newItems = Items;
        newItems[index] = item;
        Vector3 vector3 = backpackPointController.GetItemPoint(item.ItemData.CellType);
        item.transform.SetParent(transform);
        item.PutToUpload(vector3, 2f, true);
        Items = newItems;
    }

    public Item UploadItem(int index)
    {
        var item = Items[index] ?? new Item();

        Item[] newItems = Items;
        newItems[index] = null;
        Items = newItems;
        item.PutToUpload(new Vector3(0,2,0), 2f, false);
        item.transform.SetParent(null);
        return item;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.TryGetComponent(out Item component))
        {
            PutItem(component);
        }
    }
}
