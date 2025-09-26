using System;
using UnityEngine;

/// <summary>
/// Hero의 전반적인 흐름을 관리하는 클래스
/// Hero의 하위 부품들을 컴포넌트로 갖고 있으며 초기화 및 상호작용을 관리한다.
/// </summary>
public class Hero : MonoBehaviour
{
    [SerializeField] GridMover _mover;      // Hero를 움직이게 하는 컴포넌트
    [SerializeField] HeroAnimator _animator; // Hero의 애니메이션을 관리하는 컴포넌트

    [SerializeField] int _minX;
    [SerializeField] int _maxX;
    [SerializeField] int _minZ;
    [SerializeField] int _maxZ;

    public event Action<int> minXChanged;
    public event Action<int> maxXChanged;
    public event Action<int> minZChanged;
    public event Action<int> maxZChanged;

    public void Initialize()
    {
        _minX = 0;
        _maxX = 0;
        _minZ = 0;
        _maxZ = 0;
    }

    /// <summary>
    /// Hero의 하위 컴포넌트들로부터 움직임 관련 함수들을 모아 Move 함수로 관리
    /// </summary>
    /// <param name="direction"></param>
    public void Move(Vector3 direction)
    {
        _mover.Move(direction);
        _animator.PlayMove();

        CheckAndUpdatePosX();
        CheckAndUpdatePosZ();

        // Hero의 이동 방향으로 바라보게 설정
        transform.forward = direction;
    }

    void CheckAndUpdatePosX()
    {
        if(transform.position.x < _minX)
        {
            _minX = (int)transform.position.x;
            minXChanged?.Invoke(_minX);
        }
        else if(transform.position.x > _maxX)
        {
            _maxX = (int)transform.position.x;
            maxXChanged?.Invoke(_maxX);
        }
    }

    void CheckAndUpdatePosZ()
    {
        if(transform.position.z < _minZ)
        {
            _minZ = (int)transform.position.z;
            minZChanged?.Invoke(_minZ);
        }
        else if(transform.position.z > _maxZ)
        {
            _maxZ = (int)transform.position.z;
            maxZChanged?.Invoke(_maxZ);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("장애물에 부딪혔습니다!");
        }
    }
}