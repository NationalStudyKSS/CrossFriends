using System;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 플레이어의 입력을 받아 처리하고
/// 이벤트를 발생시키는 클래스
/// </summary>
public class PlayerInput : MonoBehaviour
{
    //    [SerializeField] float _inputCooldown = 0.2f;

    //    float _lastInputTime;

    //    Vector3 _moveInput;

    //    public event Action<Vector3> OnMoveEvent;

    //    public void Initialize()
    //    {
    //        _lastInputTime = -_inputCooldown;
    //        _moveInput = Vector3.zero;
    //    }

    //    /// <summary>
    //    /// 이동 입력이 들어오면 호출되는 함수
    //    /// 이동 입력이 들어올때마다 OnMoveEvent 이벤트를 발생시킨다.
    //    /// </summary>
    //    /// <param name="inputValue"></param>
    //    public void OnMove(InputValue inputValue)
    //    {
    //        // 중복 입력 방지용 쿨타임 체크
    //        if (Time.time - _lastInputTime < _inputCooldown)
    //        {
    //            //Debug.Log("여기서 return(이유 : 쿨타임)");
    //            return;
    //        }

    //        Vector2 inputVector = inputValue.Get<Vector2>();

    //        // x, y 중 절대값이 더 큰 쪽만 남김(대각선 이동 방지)
    //        if (Mathf.Abs(inputVector.x) > Mathf.Abs(inputVector.y))
    //        {
    //            inputVector.y = 0;
    //        }
    //        else
    //        {
    //            inputVector.x = 0;
    //        }

    //        // 이동 입력 벡터 생성(x입력은 그대로, y입력은 z축으로 변환)
    //        _moveInput = new Vector3(inputVector.x, 0, inputVector.y);

    //        // 키를 떼었을 때 입력이 (0,0)으로 들어오므로
    //        // 떼었을 때는 이벤트 발생시키지 않음
    //        if (_moveInput == Vector3.zero)
    //        {
    //            return;
    //        }

    //        _lastInputTime = Time.time;

    //        Debug.Log($"이동 입력 들어옴: {_moveInput}");
    //        OnMoveEvent?.Invoke(_moveInput);
    //    }
    [SerializeField] InputSystem_Actions _playerInputActions;

    public event Action<Vector3> OnMoveEvent;

    private void Awake()
    {
        _playerInputActions = new InputSystem_Actions();
    }

    public void Initialize()
    {

    }

    private void OnEnable()
    {
        _playerInputActions.Player.Enable();
        _playerInputActions.Player.Move.performed += OnMovePerformed;
    }

    private void OnDisable()
    {
        _playerInputActions.Player.Move.performed -= OnMovePerformed;
        _playerInputActions.Player.Disable();
    }

    void OnMovePerformed(InputAction.CallbackContext context)
    {
        Vector2 inputVector = context.ReadValue<Vector2>();
        
        // x, y 중 절대값이 더 큰 쪽만 남김(대각선 이동 방지)
        if (Mathf.Abs(inputVector.x) > Mathf.Abs(inputVector.y))
        {
            inputVector.y = 0;
        }
        else
        {
            inputVector.x = 0;
        }

        Vector3 moveInput = new Vector3(inputVector.x, 0, inputVector.y);

        // 이전 입력과 다를 때만 이벤트 발생
        if (moveInput != Vector3.zero)
        {
            Debug.Log($"이동 입력 들어옴: {moveInput}");
            OnMoveEvent?.Invoke(moveInput);
        }
    }
}
