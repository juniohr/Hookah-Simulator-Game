using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolinha : MonoBehaviour
{
    public ParticleSystem particle;
    public Transform chegada;
    public float random;
    public Vector3 randomVetor;
        
    void Start()
    {
        particle.Play();
        randomVetor = new Vector3(Random.Range(-8, -12), Random.Range(1.3f, 2.3f), transform.position.z + 5);
        random = Random.Range(0.002f, 0.006f);
        Destroy(gameObject, 6);
    }
    void FixedUpdate()
    {
        transform.position = Vector3.Slerp(transform.position, randomVetor, random);
    }
}
