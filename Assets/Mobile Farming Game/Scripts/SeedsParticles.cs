using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class SeedsParticles : MonoBehaviour
{
    public static Action<Vector3[]> onSeedsCollided;

    private void OnParticleCollision(GameObject other)
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();

        List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();
        int collisionAmount = ps.GetCollisionEvents(other, collisionEvents);

        Vector3[] collisionPosition = new Vector3[collisionAmount];

        for (int i = 0; i < collisionAmount; i++)
            collisionPosition[i] = collisionEvents[i].intersection;

        onSeedsCollided?.Invoke(collisionPosition);
    }
}
