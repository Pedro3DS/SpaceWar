using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float shootCadense;
    private Rigidbody2D rb2d;
    private Animator anim;

    private bool alive = true;

    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject explosion;

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
        float horizontalMovement = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(rb2d.velocity.x, verticalMovement * speed);
        rb2d.velocity = new Vector2(horizontalMovement * speed, rb2d.velocity.y);
        if (verticalMovement > 0)
        {
            anim.SetBool("Up", true);
        }
        else if (verticalMovement < 0)
        {
            anim.SetBool("Down", true);
        }
        else
        {
            anim.SetBool("Up", false);
            anim.SetBool("Down", false);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Asteroid"))
        {
            anim.SetBool("Die", true);
        }
    }

    private void Die()
    {
        alive = false;
        Destroy(gameObject);
    }

}
