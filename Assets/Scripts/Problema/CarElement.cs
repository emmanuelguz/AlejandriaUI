using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarElement : MonoBehaviour
{
    public SpriteRenderer destroyedPart;
    public SpriteRenderer newPart;
    public int requieredProblems = 3;
    public int currentProblemsCount = 0;
    public bool repaired = false;


    private void Update()
    {
        if(currentProblemsCount >= requieredProblems)
        {
            Repair();
        }
    }

    //Metodo para reparar
    public void Repair()
    {
        repaired = true;
        destroyedPart.enabled = false;
        newPart.enabled = true;
    }
}
