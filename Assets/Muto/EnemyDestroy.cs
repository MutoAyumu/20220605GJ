using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    [SerializeField] ParticleSystem _system;

    public void Destroy()
    {
        if(_system)
        {
            _system.Play();
        }

        Destroy(this.gameObject);
    }
}
