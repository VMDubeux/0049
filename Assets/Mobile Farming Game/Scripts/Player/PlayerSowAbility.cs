using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(PlayerToolSelector))]
public class PlayerSowAbility : MonoBehaviour
{
    [Header("Elements")]
    private PlayerAnimator _playerAnimator;
    private PlayerToolSelector _playerToolSelector;

    [Header("Settings")]
    private CropField _currentCropField;

    void Start()
    {
        _playerAnimator = GetComponent<PlayerAnimator>();
        _playerToolSelector = GetComponent<PlayerToolSelector>();

        SeedsParticles.onSeedsCollided += SeedsCollidedCallbak;

        CropField.onFullySown += CropFieldFullySownCallback;

        _playerToolSelector.OnToolSelected += ToolSelectedCallback;
    }

    private void OnDestroy()
    {
        SeedsParticles.onSeedsCollided -= SeedsCollidedCallbak;

        CropField.onFullySown -= CropFieldFullySownCallback;

        _playerToolSelector.OnToolSelected -= ToolSelectedCallback;
    }

    void Update()
    {

    }

    private void ToolSelectedCallback(PlayerToolSelector.Tool selectedTool) 
    {
        if(!_playerToolSelector.CanSow())
            _playerAnimator.StopSowAnimation();
    }

    private void SeedsCollidedCallbak(Vector3[] seedsPositions)
    {
        if (_currentCropField == null)
            return;

        _currentCropField.SeedsCollidedCallback(seedsPositions);
    }

    private void CropFieldFullySownCallback(CropField cropField)
    {
        if (cropField == _currentCropField)
            _playerAnimator.StopSowAnimation();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CropField") && other.GetComponent<CropField>().IsEmpty())
        {
            _currentCropField = other.GetComponent<CropField>();
            EnteredCropField(_currentCropField);
        }
    }

    private void EnteredCropField(CropField cropField)
    {
        if (_playerToolSelector.CanSow())
            _playerAnimator.PlaySowAnimation();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("CropField") && other.GetComponent<CropField>().IsEmpty())
            EnteredCropField(other.GetComponent<CropField>());
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CropField"))
        {
            _playerAnimator.StopSowAnimation();
            _currentCropField = null;
        }
    }
}
