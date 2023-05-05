using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public static HealthController instance;
    public Image healthBar;
    public float maxHealth = 100f;
    public float health = 100f;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //Evita que el valor este fuera de los limites
        health = Mathf.Clamp(health, 0, maxHealth);
    }

    private void Update()
    {
        //Actualiza el indicador de vida
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, health / maxHealth, 0.2f);
    }

    public void TakeDamage(float _damageAmount)
    {
        //Descuenta la vida
        health -= _damageAmount;

        //Evita que el valor este fuera de los limites
        health = Mathf.Clamp(health, 0, maxHealth);
    }
}
