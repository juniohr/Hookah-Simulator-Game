using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcess : MonoBehaviour
{
    public Volume v;
    public Bloom b;
    public float value;
    void Start()
    {
        v = GetComponent<Volume>();
        v.profile.TryGet(out b);
    }

    // Update is called once per frame
    void Update()
    {
        b.intensity.value = value;
    }
}
