using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackPointController : MonoBehaviour
{
    public ItemPoint[] ItemPoints;

    public Vector3 GetItemPoint(CellType cellType)
    {
        Vector3 vector3 = Vector3.zero;
        foreach (var item in ItemPoints)
        {
            if (item.CellType.Equals(cellType))
                return item.Point.position;
        }
        return vector3;
    }
}
