using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour
{
    //Atributos
    public Vector2 movementDirection;
    public float speed;

    private void Update()
    {
        //Desplaza el objeto en la direccion movementDirection con velocidad speed usando su componente transform
        transform.position += new Vector3(movementDirection.x, movementDirection.y, 0) * speed * Time.deltaTime;

        //Actualiza la velocidad dependiendo de de la velocidad actual del controlador
        speed = ProblemController.instance.CurrentSpeed;
    }
}
