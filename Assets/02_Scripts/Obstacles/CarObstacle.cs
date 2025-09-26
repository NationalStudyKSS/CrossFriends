using UnityEngine;

/// <summary>
/// 장애물인 자동차 클래스
/// </summary>
public class CarObstacle : MonoBehaviour, IObstacle
{
    [SerializeField] Mover _mover;  // 자동차를 움직이게 하는 Mover 컴포넌트
    [SerializeField] float _minMoveSpeed = 1f; // 최소 이동 속도
    [SerializeField] float _maxMoveSpeed = 5f; // 최대 이동 속도

    private void Update()
    {
        _mover.SetMoveSpeed(GetRandomMoveSpeed());
        _mover.Move(GetRandomLeftOrRight());
    }

    /// <summary>
    /// 왼쪽이나 오른쪽 중 랜덤한 방향을 반환하는 함수
    /// </summary>
    /// <returns>랜덤한 좌우 방향</returns>
    public Vector3 GetRandomLeftOrRight()
    {
        Vector3 randomLeftOrRight = Random.value < 0.5f ? Vector3.left : Vector3.right;

        return randomLeftOrRight;
    }

    /// <summary>
    /// 최소 이동 속도와 최대 이동 속도 사이의 랜덤한 이동 속도를 반환하는 함수
    /// </summary>
    /// <returns>랜덤한 float형의 MoveSpeed</returns>
    public float GetRandomMoveSpeed()
    {
        return Random.Range(_minMoveSpeed, _maxMoveSpeed);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hero"))
        {
            OnHit();
        }
    }

    public void OnHit()
    {
        Debug.Log("자동차에 부딪혔습니다!");
        // 애니메이션 및 게임오버 처리
    }
}