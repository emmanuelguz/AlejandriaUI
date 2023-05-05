using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ProblemController : MonoBehaviour
{
    //Estructura para crear un problema e indicar la dificultad del problema
    [System.Serializable]
    public struct ProblemSetup
    {
        public string problem;
        [Range(1,6)]
        public int difficulty;
    }

    //Atributos
    public static ProblemController instance;

    [Header("Round Settings")]
    public int round;
    public int solvedProblems;
    public int failedProblems;
    public float roundDuration;
    public ProblemSetup[] problems;

    [Header("Game Settings")]
    [Range(1,6)]
    public int difficulty = 1;
    public float speedMultiplierPerDifficultyLevel = 0.2f;
    public float problemMultiplierPerDifficultyLevel = 0.6f;
    public int roundsPerDifficultyLevel = 3;
    public int damagePerFailedProblem = 10;

    [Header("Generation Settings")]
    public Vector2 movementDirection;
    public GameObject problemObject;
    public Transform[] spawnOrigins;


    private List<string> currentProblems = new List<string>();
    private float elapsedTime = 0;
    private float roundElapsedTIme = 0;
    private float currentSpeed;
    private float currentProblemsPerSecond;
    private bool gameover = false;

    HealthController PlayerHealth;

    private void Awake()
    {
        instance = this;
        NextRound();
    }

    protected virtual void Update()
    {
        //Se ejecuta solamente si no ha terminado el juego
        if (!gameover)
        {
            //Calcula los valores de currentSpeed y problemsPerSeconds en funcion de la dificultad;
            currentSpeed = speedMultiplierPerDifficultyLevel * difficulty;
            currentProblemsPerSecond = problemMultiplierPerDifficultyLevel * difficulty;

            //Calcula el tiempo que tiene que esperar entre cada objeto para generar otro problema
            //Se calcula en tiempo real en caso de que currentProblemsPerSecond se actualice por aumentar la dificultad
            float waitTime = 1f / currentProblemsPerSecond;

            //Cuenta el tiempo de la ronda
            roundElapsedTIme += Time.deltaTime;

            //Cuenta el tiempo
            elapsedTime += Time.deltaTime;

            //Si el tiempo es mayor o igual al tiempo de espera waitTime entonces puede crear un nuevo objeto
            if (elapsedTime >= waitTime)
            {
                //Reinicia el contador y crea el objeto problema
                elapsedTime = 0;
                CreateProblemObject();
            }

            //Si es momento de pasar a la siguiente ronda
            if(roundElapsedTIme >= roundDuration)
            {
                //Cambia a la siguiente ronda
                NextRound();
                roundElapsedTIme = 0;
            }
        }

        //Comprueba si no ha perdido
        FinishGame();
    }

    //Crea un objeto problema que se puede mover
    protected virtual Problema CreateProblemObject()
    {
        //Elige un origen en donde crearlo
        int spawnOriginIndex = Random.Range(0, spawnOrigins.Length);

        //Crea el objeto y le añade el componente Movable para moverlo en la direccion indicada por movementDirection
        GameObject problem = Instantiate(problemObject, spawnOrigins[spawnOriginIndex].position, Quaternion.identity);

        //Inicializa el objeto problema con un problema de la ronda actual
        problem.GetComponent<Problema>().actualprblm = GetProblem();

        return problem.GetComponent<Problema>();
    }

    //Genera los problemas para cada ronda
    private void GenerateProblems()
    {
        //Reinicia la lista de problemas actuales
        currentProblems.Clear();
        
        //Busca en los problemas alguno que coincida con la dificultad actual
        foreach(ProblemSetup setup in problems)
        {
            //Comprueba que este en el rango de dificultad actual y lo agrega
            if(setup.difficulty >= difficulty && setup.difficulty <= difficulty + 1)
            {
                currentProblems.Add(setup.problem);
            }
        }

        //Si ninguno coincide con la dificultad entonces coloca los que sea
        if(currentProblems.Count <= 0)
        {
            foreach (ProblemSetup setup in problems)
            {
                currentProblems.Add(setup.problem);
            }
        }
    }

    //Guarda el caracter con la tecla que se acaba de presionar
    public void SetInputChar(char inputChar)
    {
        //Obtiene todos los objetos tipo problema
        Problema[] problems = FindObjectsOfType<Problema>();

        //Recorre todos los objetos para buscar cual es el que tiene el caracter enviado
        for(int i=problems.Length - 1; i>=0; i--)
        {
            //Si el caracter coincide entonces no hace nada mas que terminar la busqueda
            if (problems[i].Compare(inputChar))
            {
                return;
            }
        }

        //Si no encontro nada entonces le hace daño al jugador
        HealthController.instance.TakeDamage(damagePerFailedProblem);
    }

    //Continua a la siguiente ronda
    public void NextRound()
    {
        //Aumenta el contador de la ronda
        round++;

        //Agrega un grado de dificultad cada 3 rondas
        if (round % roundsPerDifficultyLevel == 0 && round != 0)
        {
            difficulty++;
        }

        //Genera los problemas de la ronda
        GenerateProblems();
    }

    //Busca en la lista de problemas a resolver para ver si lo contiene
    public bool SearchProblem(string problem)
    {
        return currentProblems.Contains(problem);
    }

    //Obtiene un problema de la lista de problemas actuales
    public string GetProblem()
    {
        //Obtiene un index aleatoreo
        int problemIndex = Random.Range(0, currentProblems.Count);
        return currentProblems[problemIndex];
    }

    //Termina el juego
    public void FinishGame()
    {
        //Si no tiene vida el jugador entonces pierte
        if(HealthController.instance.health <= 0)
        {
            //Indica que termina el juego y asi evita generar mas objetos
            gameover = true;

            //Activa el menu de gameover
            MinigameMenuManager.instance.GameOverMenu();
        }
    }

    //Retornala velocidad actual de los objetos
    public float CurrentSpeed
    {
        get
        {
            return currentSpeed;
        }
    }

    //Retorna la cantidad de objetos por segundo actual
    public float CurrentProblemsPerSecond
    {
        get
        {
            return currentProblemsPerSecond;
        }
    }

    public bool GameOver
    {
        get { return gameover; }
    }
}
