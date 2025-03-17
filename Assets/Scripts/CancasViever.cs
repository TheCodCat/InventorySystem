using UnityEngine;

public class CancasViever : MonoBehaviour
{
    private Camera camera;
    private bool isMove;

    private void Start()
    {
        camera = Camera.main;
    }
    private void Update()
    {
        if(isMove)
            transform.LookAt(camera.transform);
    }
    private void OnEnable()
    {
        isMove = true;
    }
    private void OnDisable()
    {
        isMove= false;
    }
}
