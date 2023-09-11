using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileJoystick : MonoBehaviour
{
    [Header("Elements ")]
    [SerializeField] private RectTransform _joystickOutline;
    [SerializeField] private RectTransform _joystickKnob;

    [Header("Settings")]
    private Vector3 _clickedPosition;
    [SerializeField] float _moveFactor;
    private Vector3 _move;
    private bool canControl;

    void Start()
    {
        HideJoystick();
    }

    void Update()
    {
        if (canControl)
            ControlJoystick();
    }

    public void ClickedOnJoystickZoneCallback()
    {
        _clickedPosition = Input.mousePosition;
        _joystickOutline.position = _clickedPosition;

        ShowJoystick();
    }

    private void ShowJoystick()
    {
        _joystickOutline.gameObject.SetActive(true);
        canControl = true;
    }

    private void HideJoystick()
    {
        _joystickOutline.gameObject.SetActive(false);
        canControl = false;

        _move = Vector3.zero;
    }

    private void ControlJoystick()
    {
        Vector3 currentPosition = Input.mousePosition;
        Vector3 direction = currentPosition - _clickedPosition;

        float moveMagnitude = direction.magnitude * _moveFactor / Screen.width;

        moveMagnitude = Mathf.Min(moveMagnitude, _joystickOutline.rect.width / 8);

        _move = direction.normalized * moveMagnitude;

        Vector3 targetPosition = _clickedPosition + _move;

        _joystickKnob.position = targetPosition;

        if (Input.GetMouseButtonUp(0))
            HideJoystick();
    }

    public Vector3 GetMoveVector() 
    {
        return _move;
    }
}
