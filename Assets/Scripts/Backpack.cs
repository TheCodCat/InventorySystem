using UnityEngine;

public class Backpack : MonoBehaviour
{
    public static Backpack instance;
    [SerializeField] private Canvas canvas;
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
