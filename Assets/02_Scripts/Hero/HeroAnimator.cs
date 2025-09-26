using UnityEngine;

/// <summary>
/// Hero의 애니메이션을 관리하는 클래스
/// </summary>
public class HeroAnimator : MonoBehaviour
{
    [SerializeField] Animator _animator;

    /// <summary>
    /// 움직일 때 재생되는 애니메이션
    /// </summary>
    public void PlayMove()
    {
        _animator.SetTrigger("Move");
    }
}
