using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParticles : MonoBehaviour
{
    [SerializeField] private ParticleScript particle;
    void OnEnable()
    {
        BallsInField.DestroyForParicle += SpawnParticl;

    }
    void OnDisable()
    {
        BallsInField.DestroyForParicle -= SpawnParticl;
    }

    void SpawnParticl(Transform pos)
    {
        Instantiate(particle, pos.position, pos.rotation);
    }
}
