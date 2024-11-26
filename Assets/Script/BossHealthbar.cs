using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public Slider healthBar;
    public Bosscontrollers boss;

    void Start()
    {
        healthBar.maxValue = boss.maxHealth;
        healthBar.value = boss.maxHealth;
    }

    void Update()
    {
        healthBar.value = boss.currentHealth;
    }
}

