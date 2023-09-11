using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationRenderer : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private ParticleSystem _seedsParticle;
    [SerializeField] private ParticleSystem _waterParticle;

    private void PlaySowAnimation() 
    {
        _seedsParticle.Play();
    }
    
    private void PlayWaterAnimation() 
    {
        _waterParticle.Play();
    }
}
