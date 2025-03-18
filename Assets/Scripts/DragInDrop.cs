using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;

public class DragInDrop : MonoBehaviour
{
    [SerializeField] private PlaneDrag planeDrag;//префаб поверхности
    [SerializeField] private PlaneDrag planeDragTemp;// временная поверхность на сцене
    [SerializeField] private LayerMask layerMask;// маска слоя
    [SerializeField] private bool isGrag;// перемещается ли предмет
    [SerializeField] private Vector3 offset;// оффсет от центра предмета
    [SerializeField] private Rigidbody body;// физика предмета
    [SerializeField] private Item item;// предмет
    private Camera camera;//камера
    private CancellationTokenSource cancellationTokenSource;// токен для ассинхронки

    private void Start()
    {
        camera = Camera.main;
    }
    private async void OnMouseDown()
    {
        if (item.State == ItemState.PutUpload) return;
        cancellationTokenSource = new CancellationTokenSource();
        planeDragTemp = Instantiate(planeDrag, transform.position, Quaternion.identity);
        Vector3 backpackPos = Backpack.instance.transform.position;
        planeDragTemp.transform.LookAt(backpackPos);
        isGrag = true;
        body.isKinematic = true;
        offset = GetOffset();
        await Drag(cancellationTokenSource);
    }
    private void OnMouseUp()
    {
        if (item.State == ItemState.PutUpload) return;
        isGrag = false;
        cancellationTokenSource.Cancel();
        body.isKinematic = false;
        Destroy(planeDragTemp.gameObject);
    }
    private async UniTask Drag(CancellationTokenSource cancellationToken)//перемещение
    {
        if (cancellationTokenSource.IsCancellationRequested || item.State != ItemState.None)
        {
            cancellationToken.Dispose();
            return;
        }
        else
        {
            item.State = ItemState.Drag;
            while (!cancellationTokenSource.IsCancellationRequested)
            {
                await UniTask.Yield();
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hitInfo, 10, layerMask))
                {
                    body.MovePosition(hitInfo.point + offset);
                }
            }
            item.State = ItemState.None;
        }
    }
    private Vector3 GetOffset()// получение оффета
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 10, layerMask))
        {
            offset = hitInfo.point - transform.position;
            return offset;
        }
        else
            return Vector3.zero;
    }
}
