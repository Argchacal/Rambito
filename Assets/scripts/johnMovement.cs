using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jhonMovement : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    private float horizontal;
    public float Speed;
    public float JumpForce;
    private bool Groudead;
    private Animator Animator;
    public GameObject BulletPrefab;
    private float LastShoot;
    private int health = 5 ;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal")* Speed;//es el moviminto sin suavisado -1 0 1
        if (horizontal < 0.0f ) 
        {
            transform.localScale= new Vector3( -1.0f, 1.0f,1.0f);
        }
        else if (horizontal > 0.0f)
        {
            transform.localScale= new Vector3( 1.0f, 1.0f,1.0f);
        }      
        //Debug.Log(transform.position.y);
        if (transform.position.y < -0.7f)
        {
            Destroy(gameObject);
        }
        // horizontal nos dice si esta en movimiento o no si es tru
        Animator.SetBool("running", horizontal != 0.0f);

        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);       
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Groudead = true;
        }
        else Groudead = false;

        if (Input.GetKeyDown(KeyCode.W) && Groudead){
            jump();
        }
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > LastShoot +0.25f) {
            Shoot();
            LastShoot= Time.time;
        }

    }
    private void jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f) 
        { 
            direction = Vector2.right;
        }
        else
        {
            direction = Vector2.left;
        }
    
        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<bulletScript>().SetDirection(direction);    
    }
    public void Hit()
    {
        health = health-1;
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2 (horizontal, Rigidbody2D.velocity.y);
    }
}
