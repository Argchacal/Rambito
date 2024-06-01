using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gruntScript : MonoBehaviour
{
    public GameObject Jhon;
    private float LastShoot;
    public GameObject BulletPrefab;
    private int health = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Jhon == null)
        {
            return;
        }
        Debug.Log(transform.position.y);
        Vector3 direction = Jhon.transform.position - transform.position;
        //dice que john esta a la derecha
        if (direction.x >= 0.0f){
            transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
        }
        else{
            transform.localScale = new Vector3 (-1.0f, 1.0f, 1.0f);
        }
        //me dice la distancia, la posicion entre john y grund en absuluta por eso de damos
        float distance = Mathf.Abs( Jhon.transform.position.x - transform.position.x);
        if (distance < 1.0f && Time.time > LastShoot +0.35f)
        {
            Shoot();
            LastShoot= Time.time;
        }
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
}
