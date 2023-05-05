using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Problema : MonoBehaviour
{    
    public GameObject DispBox;   //es donde se va a mostrar al player que letra /o palabra debe escribir
    public string actualprblm;
    public float lifetime = 3.5f;
    
    private int index = 0;
    protected bool caducado = false;

    private void Update()
    {
        StartCoroutine(CountDown());//Inicia el countdown

        //Actualiza el displaybox
        DispBox.GetComponent<Text>().text = "";
        for (int i=index; i<actualprblm.Length; i++)
        {
            DispBox.GetComponent<Text>().text += actualprblm[i];
        }

        //Comprueba si ya se resolvio el problema
        if(index >= actualprblm.Length)
        {
            //Lo cuenta el el contador de problemas resueltos
            ProblemController.instance.solvedProblems++;

            Destroy(DispBox);
            Destroy(gameObject);
        }   
    }

    IEnumerator CountDown()//Cuenta atras 3.5 segundos y hace lo mismo que en el update
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(DispBox);
        Destroy(gameObject);

        //Si aun no ha hecho daño al jugador
        if (!caducado)
        {
            //Lo cuenta en el contador de problemas no resueltos
            ProblemController.instance.failedProblems++;

            //Daña al jugador
            HealthController.instance.TakeDamage(ProblemController.instance.damagePerFailedProblem);
            Debug.Log(HealthController.instance.name);
            caducado = true;
        }
    }

    //Metodo para comprobar si el caracter es el siguiente
    public bool Compare(char _sol)
    {
        //Debug.Log(actualprblm[index]);
        if(actualprblm[index] == _sol && actualprblm.Length > 0 && index < actualprblm.Length && !caducado)
        {
            index++;
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si aun no ha hecho daño al jugador
        if (!caducado)
        {
            //Lo cuenta en el contador de problemas no resueltos
            ProblemController.instance.failedProblems++;

            //Daña al jugador
            HealthController.instance.TakeDamage(ProblemController.instance.damagePerFailedProblem);
            caducado = true;
        }
    }

    public bool Caducado
    {
        get { return caducado; }
    }
}
