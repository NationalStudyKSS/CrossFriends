using UnityEngine;

/// <summary>
/// ���濡 �ִ� ��ֹ�
/// </summary>
public class TrailObstacle : MonoBehaviour, IObstacle
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Hero"))
        {
            OnHit();
        }
    }

    public void OnHit()
    {
        Debug.Log("������ �ε������ϴ�!");
        // �ִϸ��̼� �� ���ӿ��� ó��
    }
}