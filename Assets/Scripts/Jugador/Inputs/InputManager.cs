using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //private A_controlador controlador; 
    private char tecla ='\0';
   
    public void Update()
    {

        //Si no estan activados el menu de pausa y el menu de gameover
        if (!MinigameMenuManager.instance.IsPaused && !MinigameMenuManager.instance.GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                tecla = ' ';
                //Debug.Log(tecla);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                tecla = 'a';
                //Debug.Log(getTecla()); 
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                tecla = 'b';
                //Debug.Log(tecla);
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                tecla = 'c';
                //Debug.Log(tecla);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                tecla = 'd';
                //Debug.Log(tecla);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                tecla = 'e';
                //Debug.Log(tecla);
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                tecla = 'f';
                //Debug.Log(tecla);
            }

            if (Input.GetKeyDown(KeyCode.G))
            {
                tecla = 'g';
                //Debug.Log(tecla);
            }

            if (Input.GetKeyDown(KeyCode.H))
            {
                tecla = 'h';
                //Debug.Log(tecla);
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                tecla = 'i';
                //Debug.Log(tecla);
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                tecla = 'j';
                //Debug.Log(tecla);
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                tecla = 'k';
                //Debug.Log(tecla);
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                tecla = 'l';
                //Debug.Log(tecla);
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                tecla = 'm';
                //Debug.Log(tecla);
            }

            if (Input.GetKeyDown(KeyCode.N))
            {
                tecla = 'n';
                //Debug.Log(tecla);
            }

            if (Input.GetKeyDown(KeyCode.O))
            {
                tecla = 'o';
                //Debug.Log(tecla);
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                tecla = 'p';
                //Debug.Log(tecla);
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                tecla = 'q';
                //Debug.Log(tecla);
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                tecla = 'r';
                //Debug.Log(tecla);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                tecla = 's';
                //Debug.Log(tecla);
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                tecla = 't';
                //Debug.Log(tecla);
            }

            if (Input.GetKeyDown(KeyCode.U))
            {
                tecla = 'u';
                //Debug.Log(tecla);
            }

            if (Input.GetKeyDown(KeyCode.V))
            {
                tecla = 'v';
                //Debug.Log(tecla);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                tecla = 'w';
                //Debug.Log(tecla);
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                tecla = 'x';
                //Debug.Log(tecla);
            }

            if (Input.GetKeyDown(KeyCode.Y))
            {
                tecla = 'y';
                //Debug.Log(tecla);
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                tecla = 'z';
                //Debug.Log(tecla);
            }

            if (tecla != '\0')
            {
                ProblemController.instance.SetInputChar(tecla);
                tecla = '\0';
            }
        }
    }

    
    public char getTecla()
    {
        return tecla;
    }
}
