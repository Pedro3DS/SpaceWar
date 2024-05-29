using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Vector3 rotation = transform.localEulerAngles;
        rotation.z += Time.deltaTime * 5f;
        transform.localEulerAngles = rotation;
    }

    //private void OnCollisionEnter2D(Collision2D other)
    //{

    //    Debug.Log(other.gameObject.tag);
    //    //if(other.gameObject.tag == "Player")
    //    //{
    //    //    Destroy(other.gameObject);
    //    //}
    //}

    

    private void Movement()
    {
        rb2d.velocity = Vector3.left * speed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
