using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{ 
    private Rigidbody2D Rigidbody2D;
    public float speed;
    private Vector2 Direction;
    public AudioClip Sound;
    
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);//PlayOneShot(Sound) sirve para lanzar efetos de sonidos.
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * speed;
    }
    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }
    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)         
    {
        jhonMovement Jhon = collision.GetComponent<jhonMovement>();
        gruntScript Grund = collision.GetComponent<gruntScript>();
        if(Jhon != null)
        {
            Debug.Log("muere johonnn");
            Jhon.Hit();
        }
        if(Grund != null)
        {
            Debug.Log("muere grund");
            Grund.Hit();
        }
        DestroyBullet();
        
    }
}

