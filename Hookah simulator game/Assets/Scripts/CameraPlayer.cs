using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    /*public Transform characterHead;
    public Transform characterBody;*/
    public GameObject posicaoDoJogador;
    public bool puxandoOuSoltandoFumaca;

   /* float rotationX;
    float rotationY;
    float smoothX;
    float smoothY;*/

    private void LateUpdate()
    {
       // transform.position = characterHead.position;
        if (UI.inst.pressionandoOuSoltando)
        {
            puxandoOuSoltandoFumaca = true;
        }
        else 
        {
            puxandoOuSoltandoFumaca = false;
        }

        if (puxandoOuSoltandoFumaca == false)
        {
            if (UI.inst.objsNaCena[3] != null)
            {
                posicaoDoJogador.transform.localPosition = Vector3.Lerp(posicaoDoJogador.transform.localPosition, new Vector3(-0.79f, 0.1f, -5.32f), 0.3f);
            }
        }
        else
        {
            posicaoDoJogador.transform.localPosition = Vector3.Lerp(posicaoDoJogador.transform.localPosition, new Vector3(-0.79f, 0.1f, -6.5f), 0.3f);
        }
                 
    }
 
    /*void Update()
    {
        float verticalDelta = Input.GetAxis("Mouse Y");
        float horizontalDelta = Input.GetAxis("Mouse X");

        smoothX = horizontalDelta * 2;
        smoothY = verticalDelta * 2;

        rotationX += smoothX;
        rotationY += smoothY;

        rotationY = Mathf.Clamp(rotationY, -90, 90);

        characterBody.eulerAngles = new Vector3(0, rotationX, 0);

        transform.localEulerAngles = new Vector3(-rotationY,0, 0);
    }*/
}
