using System;
using UnityEngine;

/// <summary>
/// Transform.Translate로 움직이는 물체를 움직이게 하는 Mover 클래스
/// </summary>
public class TransformMover : Mover
{
    public override event Action<Vector3> OnMoved;

    /// <summary>
    /// Transform.Translate로 움직이는 함수
    /// </summary>
    /// <param name="direction">움직일 방향</param>
    public override void Move(Vector3 direction)
    {
        transform.Translate(direction * _moveSpeed * Time.deltaTime);
        OnMoved?.Invoke(direction.normalized);
    }
}
