using UnityEngine;

/// <summary>
/// PlayScene의 전반적인 흐름을 관리하는 클래스
/// 하위 클래스들을 컴포넌트로 갖고 있으며 초기화 및 상호작용을 관리한다.
/// </summary>
public class PlayScene : MonoBehaviour
{
    [SerializeField] Hero _hero;
    [SerializeField] PlayerInput _playerInput;
    [SerializeField] MapSpawner _mapSpawner;

    private void Start()
    {
        _playerInput.OnMoveEvent += _hero.Move;

        _playerInput.Initialize();
        _mapSpawner.Initialize(_hero.gameObject.transform.position);
    }
}