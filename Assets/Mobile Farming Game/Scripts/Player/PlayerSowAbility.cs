using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimator))]
public class PlayerSowAbility : MonoBehaviour
{
    [Header("Elements")]
    private PlayerAnimator _playerAnimator;

    [Header("Settings")]
    private CropField _currentCropField;

    void Start()
    {
        _playerAnimator = GetComponent<PlayerAnimator>();

        SeedsParticles.onSeedsCollided += SeedsCollidedCallbak;

        CropField.onFullySown += CropFieldFullySownCallback;
    }

    private void OnDestroy()
    {
        SeedsParticles.onSeedsCollided -= SeedsCollidedCallbak;

        CropField.onFullySown -= CropFieldFullySownCallback;
    }

    void Update()
    {

    }

    private void SeedsCollidedCallbak(Vector3[] seedsPositions) 
    {
        if (_currentCropField == null)
            return;

        _currentCropField.SeedsCollidedCallback(seedsPositions);
    }

    private void CropFieldFullySownCallback(CropField cropField) 
    {
        if(cropField == _currentCropField)
            _playerAnimator.StopSowAnimation();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CropField") && other.GetComponent<CropField>().IsEmpty())
        {
            _playerAnimator.PlaySowAnimation();
            _currentCropField = other.GetComponent<CropField>();
        }
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
