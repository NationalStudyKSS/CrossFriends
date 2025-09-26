using System;
using UnityEngine;

/// <summary>
/// Hero�� �������� �帧�� �����ϴ� Ŭ����
/// Hero�� ���� ��ǰ���� ������Ʈ�� ���� ������ �ʱ�ȭ �� ��ȣ�ۿ��� �����Ѵ�.
/// </summary>
public class Hero : MonoBehaviour
{
    [SerializeField] GridMover _mover;      // Hero�� �����̰� �ϴ� ������Ʈ
    [SerializeField] HeroAnimator _animator; // Hero�� �ִϸ��̼��� �����ϴ� ������Ʈ

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
    /// Hero�� ���� ������Ʈ��κ��� ������ ���� �Լ����� ��� Move �Լ��� ����
    /// </summary>
    /// <param name="direction"></param>
    public void Move(Vector3 direction)
    {
        _mover.Move(direction);
        _animator.PlayMove();

        CheckAndUpdatePosX();
        CheckAndUpdatePosZ();

        // Hero�� �̵� �������� �ٶ󺸰� ����
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
            Debug.Log("��ֹ��� �ε������ϴ�!");
        }
    }
}