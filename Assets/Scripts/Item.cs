using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemData ItemData;//������ ��������
    public ItemState State = ItemState.None;//��������� ��������
    [SerializeField] private Rigidbody rb;// ������
    public async void PutToUpload(Vector3 vector3, float duraction, bool put)// ����� ��������/����������� ��������
    {
        State = ItemState.PutUpload;
        if (put)
        {
            rb.isKinematic = true;
            transform.DOMove(vector3, duraction);
        }
        else
        {
            transform.DOMove(vector3, duraction);
            await UniTask.Delay(TimeSpan.FromSeconds(duraction));
            rb.isKinematic = false;
        }
        State = ItemState.None;
    }
}
