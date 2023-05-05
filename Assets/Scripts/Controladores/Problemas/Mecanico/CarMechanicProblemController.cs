using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarMechanicProblemController : ProblemController
{
    private struct ProblemPosition
    {
        public Problema problem;
        public Transform position;

        public ProblemPosition(Problema problem, Transform position)
        {
            this.problem = problem;
            this.position = position;
        }
    }

    //Atributos
    private List<ProblemPosition> currentProblems = new List<ProblemPosition>();

    protected override void Update()
    {
        //Metodo update del padre
        base.Update();

        //Recorre todos los problemas
        for(int i=0; i<currentProblems.Count; i++)
        {
            //Si ya no existe el problema entonces lo quita de la lista
            if(currentProblems[i].problem == null)
            {
                currentProblems.RemoveAt(i);
            }
        }


        //Si todas las partes estan reparadas quiere decir que ganaste
        foreach(Transform origin in spawnOrigins)
        {
            CarElement element = origin.GetComponent<CarElement>();
            if (!element.repaired)
            {
                return;
            }
        }

        //Si llega aqui entonces ha ganado
        MinigameMenuManager.instance.VictoryMenu();
    }

    //Metodo personalizado para aparecer los objetos problemas
    protected override Problema CreateProblemObject()
    {
        //Guarda el index del origen donde se va a crear
        int spawnOriginIndex;

        //Obtiene la lista de index disponibles
        List<int> available = new List<int>();
        for(int i=0; i<spawnOrigins.Length; i++)
        {
            //Si no encuentra el origen en alguno de los elementos
            Transform availableOrigin = currentProblems.Find(problema => problema.position == spawnOrigins[i]).position;
            if (availableOrigin == null && !spawnOrigins[i].GetComponent<CarElement>().repaired)
            {
                //Guarda el origen disponible
                available.Add(i);
                //Debug.Log(i);
            }
        }
        //Debug.Log("--------------");

        //Solamente si hay espacios disponibles
        if(available.Count > 0)
        {
            //Obtiene el index
            spawnOriginIndex = Random.Range(0, available.Count);
            spawnOriginIndex = available[spawnOriginIndex];

            //Crea el objeto y le añade el componente Movable para moverlo en la direccion indicada por movementDirection
            GameObject problem = Instantiate(problemObject, spawnOrigins[spawnOriginIndex].position, Quaternion.identity);

            //Guarda el problema
            currentProblems.Add(new ProblemPosition(problem.GetComponent<Problema>(), spawnOrigins[spawnOriginIndex]));

            //Inicializa el objeto problema con un problema de la ronda actual
            problem.GetComponent<CarmMechanicProblem>().actualprblm = GetProblem();
            problem.GetComponent<CarmMechanicProblem>().currentCarElement = spawnOrigins[spawnOriginIndex].GetComponent<CarElement>(); ;

            return problem.GetComponent<CarmMechanicProblem>();
        }
        else
        

        return null;
    }
}
