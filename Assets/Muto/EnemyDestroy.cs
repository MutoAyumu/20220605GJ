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
            var s = Instantiate(_system);
            Destroy(s, 3);
        }

        Destroy(this.gameObject);
    }
}
