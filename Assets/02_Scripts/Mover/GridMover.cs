using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// Transform.position을 직접 변경하여
/// 이동 입력이 들어오면 해당 방향으로 1만큼 이동시키는 Mover
/// </summary>
public class GridMover : MonoBehaviour
{
    [SerializeField] private float _moveDuration = 0.15f; // 한 칸 이동 시간(초)
    bool _isMoving = false;

    public event Action<Vector3> OnMoved;

    /// <summary>
    /// 이동 입력이 들어오면 해당 방향으로 1만큼 이동시킨다.
    /// </summary>
    /// <param name="direction">이동할 방향</param>
    public void Move(Vector3 direction)
    {
        if (_isMoving || direction == Vector3.zero) return;

        Vector3 moveVector = direction.normalized;
        Vector3 targetPosition = transform.position + moveVector;
        StartCoroutine(MoveRoutine(targetPosition, moveVector));
    }

    /// <summary>
    /// 움직임을 코루틴으로 처리하여 부드럽게 이동시킨다.
    /// </summary>
    /// <param name="targetPosition"></param>
    /// <param name="moveVector"></param>
    /// <returns></returns>
    private IEnumerator MoveRoutine(Vector3 targetPosition, Vector3 moveVector)
    {
        _isMoving = true;
        Vector3 startPosition = transform.position;
        float elapsed = 0f;

        while (elapsed < _moveDuration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsed / _moveDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        _isMoving = false;
        OnMoved?.Invoke(moveVector);
    }
}