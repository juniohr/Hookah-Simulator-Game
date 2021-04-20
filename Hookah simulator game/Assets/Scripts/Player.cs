using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    public CharacterController controller;
    public Image alvo;
    public Camera cam;
    public Animator anim;
    public GameObject obj;
    public bool podePegar = false;
    public bool naoPegar = false;
    private GameObject obj2;

    Vector3 forward;
    Vector3 strafe;
    Vector3 vertical;

    float gravity;
    float jumpSpeed;
    float maxJumpHeight = 2;
    float timeToMaxHeight = 0.5f;
   

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
        gravity = (-2 * maxJumpHeight) / (timeToMaxHeight * timeToMaxHeight);
        jumpSpeed = (maxJumpHeight) / timeToMaxHeight;
    }

    void Update()
    {
        Move();
       // Mira();
    }

     void Move()
    {
        vertical += gravity * Time.deltaTime * Vector3.up;
        float forwardInput = Input.GetAxisRaw("Vertical");
        float strafeInput = Input.GetAxisRaw("Horizontal");

        forward = forwardInput * speed * transform.forward;
        strafe = strafeInput * speed * transform.right;


        if (controller.isGrounded)
        {
            vertical = Vector3.down;
        }

        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            vertical = jumpSpeed * Vector3.up;
        }

        Vector3 finalVelocity = forward + strafe + vertical;
        controller.Move(finalVelocity * Time.deltaTime);
    }

    void Mira()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
       
        if (Physics.Raycast(ray,out hit,20))
        {
            if (hit.collider.gameObject.layer == 8 && hit.distance <= 10)
            {
                alvo.color = Color.red;
                if (Input.GetKeyDown(KeyCode.K) && podePegar == false)
                {
                    podePegar = true;

                    if (podePegar)
                    {
                        hit.collider.gameObject.transform.parent = obj.transform;
                        hit.collider.gameObject.transform.localPosition = new Vector3(-0.0006f, 0.00194f, 0.00149f);
                        obj2 = hit.collider.gameObject;
                    }
                }
                if (Input.GetKeyDown(KeyCode.L) && podePegar)
                {
                    podePegar = false;
                    if (podePegar == false) 
                    {
                        obj2.transform.parent = null;
                    }
                }
            }
            else
            {
                alvo.color = Color.white;
            }       
        }
        else
        {
            alvo.color = Color.white;
        }
    }
}
