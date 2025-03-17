using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;

public class DragInDrop : MonoBehaviour
{
    [SerializeField] private PlaneDrag planeDrag;
    [SerializeField] private PlaneDrag planeDragTemp;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private bool isGrag;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Rigidbody body;
    private Camera camera;
    private CancellationTokenSource cancellationTokenSource;

    private void Start()
    {
        camera = Camera.main;
    }
    private async void OnMouseDown()
    {
        cancellationTokenSource = new CancellationTokenSource();
        planeDragTemp = Instantiate(planeDrag, transform.position, Quaternion.identity);
        Vector3 backpackPos = Backpack.instance.GetPosition();
        planeDragTemp.transform.LookAt(backpackPos);
        isGrag = true;
        body.isKinematic = true;
        offset = GetOffset();
        await Drag(cancellationTokenSource);
    }
    private void OnMouseUp()
    {
        isGrag = false;
        cancellationTokenSource.Cancel();
        body.isKinematic = false;
        Destroy(planeDragTemp.gameObject);
    }
    private async UniTask Drag(CancellationTokenSource cancellationToken)
    {
        if (cancellationTokenSource.IsCancellationRequested)
        {
            cancellationToken.Dispose();
            return;
        }
        else
        {
            while (!cancellationTokenSource.IsCancellationRequested)
            {
                await UniTask.Yield();
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hitInfo, 10, layerMask))
                {
                    body.MovePosition(hitInfo.point + offset);
                }
            }
        }
    }
    private Vector3 GetOffset()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin,ray.direction * 10, Color.red);
        if(Physics.Raycast(ray, out RaycastHit hitInfo, 10, layerMask))
        {
            offset = hitInfo.point - transform.position;
            return offset;
        }
        else
            return Vector3.zero;
    }
}
