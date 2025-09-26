using System;
using UnityEngine;

/// <summary>
/// Transform.Translate�� �����̴� ��ü�� �����̰� �ϴ� Mover Ŭ����
/// </summary>
public class TransformMover : Mover
{
    public override event Action<Vector3> OnMoved;

    /// <summary>
    /// Transform.Translate�� �����̴� �Լ�
    /// </summary>
    /// <param name="direction">������ ����</param>
    public override void Move(Vector3 direction)
    {
        transform.Translate(direction * _moveSpeed * Time.deltaTime);
        OnMoved?.Invoke(direction.normalized);
    }
}
