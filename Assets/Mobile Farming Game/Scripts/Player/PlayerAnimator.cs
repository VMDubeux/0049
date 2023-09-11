using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Animator _animator;
    [SerializeField] private ParticleSystem _waterParticle;

    [Header("Settings")]
    [SerializeField] private float _moveSpeedMultiplier;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ManageAnimations(Vector3 moveVector) 
    {
        if (moveVector.magnitude > 0)
        {
            _animator.SetFloat("moveSpeed", moveVector.magnitude * _moveSpeedMultiplier);
            PlayRunAnimation();

            _animator.transform.forward = moveVector.normalized;
        }
        else 
        {
            PlayIdleAnimation();
        }
    }

    private void PlayRunAnimation() 
    {
        _animator.Play("Run");
    }

    private void PlayIdleAnimation() 
    {
        _animator.Play("Idle");
    }

    public void PlaySowAnimation() 
    {
        _animator.SetLayerWeight(1, 1);
    }

    public void StopSowAnimation() 
    {
        _animator.SetLayerWeight(1, 0);
    }

    public void PlayWaterAnimation()
    {
        _animator.SetLayerWeight(2, 1);
    }

    public void StopWaterAnimation() 
    {
        _animator.SetLayerWeight(2, 0);
        _waterParticle.Stop();
    }
}
