using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerAnimator))]
public class PlayerController : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private MobileJoystick _joystick;
    private CharacterController _characterController;
    private PlayerAnimator _playerAnimator;

    [Header ("Settings")]
    [SerializeField] private float _moveSpeed;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _playerAnimator = GetComponent<PlayerAnimator>();
    }

    void Update()
    {
        ManageMovement();
    }

    private void ManageMovement()
    {
        Vector3 moveVector = _joystick.GetMoveVector() * _moveSpeed * Time.deltaTime / Screen.width;

        moveVector.z = moveVector.y;
        moveVector.y = 0;

        _characterController.Move(moveVector);

        _playerAnimator.ManageAnimations(moveVector);
    }
}
