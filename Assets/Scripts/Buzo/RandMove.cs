using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandMove : MonoBehaviour
{
    private float Xmax = 5f;
    private float Xmin = -5f;
    private float Ymax = 5f;
    private float Ymin = -5f;
    private float tChange = 0; // force new direction in the first Update
    private float randX;
    private float randY;
    private float speedbase = 1.5f;
    private float speed = 0.01f;
    public Rigidbody2D rb;
    private Vector2 movement;
    
    
    void Update()
    {
        // Cambia direccion en intervalos aleatorios
        if (Time.time >= tChange)
        {
            randX = Random.Range(-2.0f, 2.0f);
            randY = Random.Range(-2.0f, 2.0f);

            tChange = Time.time + Random.Range(0.5f, 1.5f);
        }
       
            speedbase += speed * Time.deltaTime;
            
         
        movement = new Vector2(randX, randY);
        transform.Translate(movement * speedbase * Time.deltaTime);
        // Si llega a algun limite que revierta la direccion
        if (transform.position.x >= Xmax || transform.position.x <= Xmin)
        {
            randX = -randX;
        }
        if (transform.position.y >= Ymax || transform.position.y <= Ymin)
        {
            randY = -randY;
        }
        rb.transform.position = new Vector2(Mathf.Clamp(transform.position.x, Xmin, Xmax), Mathf.Clamp(transform.position.y, Ymin, Ymax));
        
    }

   


}

    