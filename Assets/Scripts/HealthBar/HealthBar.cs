using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image health;
    [SerializeField] float aHealth;
    [SerializeField] float maxHealth;
    public void Update()
    {
        health.fillAmount = aHealth / maxHealth;
    }
}
