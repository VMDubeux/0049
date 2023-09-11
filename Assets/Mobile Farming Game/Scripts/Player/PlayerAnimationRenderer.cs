using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationRenderer : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private ParticleSystem _seedsParticle;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void PlaySowAnimation() 
    {
        _seedsParticle.Play();
    }
}
