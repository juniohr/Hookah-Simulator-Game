using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciar : MonoBehaviour
{
    public GameObject seraDestruido;
    public static Instanciar inst;
    void Start()
    {
        inst = this;
        Debug.Log("Olá");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Rosh>())
        {
            seraDestruido = other.gameObject;
        }
    }
}
