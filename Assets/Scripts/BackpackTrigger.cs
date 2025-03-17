using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BackpackTrigger : MonoBehaviour
{
    private CellData cellData;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if(other.transform.TryGetComponent(out Item component))
        {
            cellData = Backpack.instance.CellDatas.FirstOrDefault(x => x.CellType.Equals(component.ItemData.CellType));
            cellData.ItemData = component.ItemData;
            Backpack.instance.OnChangeInventory?.Invoke(component.ItemData.CellType, true);
        }
    }
}
