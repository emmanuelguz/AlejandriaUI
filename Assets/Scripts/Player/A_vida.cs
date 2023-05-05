using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_vida : MonoBehaviour
{
    public static A_vida instance;
    public float health = 100f;

    private void Awake()
    {
        instance = this;
    }

    public void TakeDamage(float _damageAmount)
    {
        if (health <= 0)
        {
            ProblemController.instance.FinishGame();
        }
        else
        {
            health -= _damageAmount;
        }
    }
}
