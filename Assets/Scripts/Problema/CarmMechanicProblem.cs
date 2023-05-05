using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarmMechanicProblem : Problema
{
    public CarElement currentCarElement;

    private void OnDestroy()
    {
        //Si no esta caducado entonces lo agrega a la parte que se reparo
        if (!caducado)
        {
            currentCarElement.currentProblemsCount++;
        }
    }
}
