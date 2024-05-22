using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dust : MonoBehaviour
{    

    private DustSettings _ds;
    private ParticleSystem _particleSystem;
    public void Init(DustSettings ds) { 
        _ds = ds;

        transform.localScale *= _ds.scale;   

        _particleSystem = GetComponent<ParticleSystem>();
        ParticleSystem.MainModule _main = _particleSystem.main;
        
        _main.startColor = _ds.color;
        _main.startLifetime = _ds.lifetime;
    
        
    }    
}