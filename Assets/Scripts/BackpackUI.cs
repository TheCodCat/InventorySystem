using UnityEngine;

public class BackpackUI : MonoBehaviour
{
    [SerializeField] private Item[] items;
    [SerializeField] private Canvas canvas;
    private void OnMouseDown()
    {
        canvas.gameObject.SetActive(true);
    }
    public void ChangeView(Item[] newItems)
    {
        Debug.Log("34234");
        items = newItems;
    }
}
