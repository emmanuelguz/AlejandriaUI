using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostmanProblemController : ProblemController
{
    protected override void Update()
    {
        //Update del padre
        base.Update();

        /*AQUI VA EL CODIGO PERSONALIZADO PARA EL MINIJUEGO DEL CARTERO*/
    }

    //Metodo para instanciar problemas
    protected override Problema CreateProblemObject()
    {
        //Crea el problema con el metodo del padre
        Problema problem = base.CreateProblemObject();

        //Agrega el script movable para que se pueda mover por la escena
        problem.gameObject.AddComponent<Movable>().movementDirection = movementDirection;

        return problem;
    }
}
