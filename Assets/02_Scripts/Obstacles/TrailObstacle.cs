using UnityEngine;

/// <summary>
/// 숲길에 있는 장애물
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
        Debug.Log("나무에 부딪혔습니다!");
        // 애니메이션 및 게임오버 처리
    }
}