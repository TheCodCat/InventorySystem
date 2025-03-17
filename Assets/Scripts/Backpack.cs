using Assets.Scripts.Models;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    public static Backpack instance;
    public CellType DataCell;
    [SerializeField] private Canvas canvas;
    [SerializeField] private CellData[] cellDatas;
    public CellData[] CellDatas
    {
        get
        {
            return cellDatas;
        }
        set
        {
            cellDatas = value;
        }
    }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);
    }
    public Vector3 GetPosition()
    {
        return transform.position;
    }
    private void OnMouseDown()
    {
        canvas.gameObject.SetActive(true);
    }
    private void OnMouseUp()
    {
        canvas.gameObject.SetActive(false);
    }
}
