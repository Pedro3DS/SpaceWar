using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float shootCadense;
    [SerializeField] private float nextShoot;
    private Rigidbody2D rb2d;
    private Animator anim;
    public double counter = 0000000000000000000;

    [SerializeField] private GameObject bullet;

    [SerializeField] private TMP_Text countText;


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
        Shooting();
        countText.text = $"{counter}";
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

    private void Shooting()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextShoot)
        {

            nextShoot = Time.time + shootCadense;

            Vector2 direction = Vector2.right;
            if (gameObject.GetComponent<SpriteRenderer>().flipX)
            {
                direction = Vector2.left;
            }

            Vector3 spawnPosition = transform.position + new Vector3(direction.x, direction.y, 0f);


            GameObject newBullet = Instantiate(bullet, spawnPosition, Quaternion.identity);


            Rigidbody2D bulletRB = newBullet.GetComponent<Rigidbody2D>();
            bulletRB.velocity = direction * 10;
            Destroy(bulletRB,2);
        }
    }

    private void Die()
    {
        Debug.Log("Moreu");
        Destroy(gameObject);
    }

}
