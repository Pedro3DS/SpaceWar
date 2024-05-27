using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb2d;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float verticalMovement = Input.GetAxis("Vertical");
        rb2d.velocity = new Vector2(rb2d.velocity.x, verticalMovement * speed);
        if (verticalMovement != 0)
        {
            anim.SetBool("Up", true);
        }
        else
        {
            anim.SetBool("Down", true);
        }
        anim.SetBool("Down", false);
        anim.SetBool("Up", false);
    }
}