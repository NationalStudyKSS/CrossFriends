using UnityEngine;

/// <summary>
/// 장애물들이 공통으로 구현해야 하는 인터페이스
/// </summary>
public interface IObstacle
{ 
    //void SetTag(string tag); // 장애물 태그 설정 함수

    /// <summary>
    /// 이 인터페이스를 갖는 클래스는 OnTriggerEnter을 강제로 구현하세요
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other);

    /// <summary>
    /// OnTriggerEnter 시 호출되는 함수
    /// </summary>
    void OnHit();
}