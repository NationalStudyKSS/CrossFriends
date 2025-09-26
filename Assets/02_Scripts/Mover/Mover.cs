using System;
using UnityEngine;

/// <summary>
/// 이 스크립트를 컴포넌트로 갖는 게임 오브젝트를 움직이게 하는 클래스
/// </summary>
public abstract class Mover : MonoBehaviour
{
    [SerializeField] protected float _moveSpeed;

    public float MoveSpeed => _moveSpeed;

    public abstract event Action<Vector3> OnMoved;   // 이동했을 때 발생하는 이벤트
    
    public abstract void Move(Vector3 direction);

    public void SetMoveSpeed(float moveSpeed)
    {
        _moveSpeed = moveSpeed;
    }
}
