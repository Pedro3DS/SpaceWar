using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private int damage;

    [SerializeField] private TMP_Text countText;

    private Animator animator;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Asteroid"))
        {
            Destroy(other.gameObject);
            rb2d.velocity = Vector3.zero;
            animator.SetBool("Destroy", true);
            Debug.Log(double.Parse(countText.text)+1);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void Explode()
    {
        Destroy(gameObject);
    }
}
