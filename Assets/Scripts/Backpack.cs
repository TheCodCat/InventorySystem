using UnityEngine;
using UnityEngine.Events;

public class Backpack : MonoBehaviour
{
    public static Backpack instance;
    [SerializeField] private Item[] items = new Item[] { };
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
        Items = newItems;
    }

    public Item PickUpItem(int index)
    {
        return Items[index] ?? new Item();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.TryGetComponent(out Item component))
        {
            PutItem(component);
            component.gameObject.SetActive(false);
        }
    }
}
