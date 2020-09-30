using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sliders : MonoBehaviour
{
    Slider healthBar;
    Text healthText;
    Slider ManaBar;
    Text ManaText;
    int maxHealth;
    int maxMana;
    int enemyMaxHealth;
    Slider enemyHealth1;
    Slider enemyHealth2;
    Slider enemyHealth3;
    Slider bossHealth;
    Slider Ceryz;
    Slider Gwyn;
    Slider Fredalf;
    // Start is called before the first frame update
    void Start()
    {
        //playerstats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>();
        healthBar = GameObject.FindGameObjectWithTag("healthBar").GetComponent<Slider>();
        healthText = GameObject.FindGameObjectWithTag("HealthBarText").GetComponent<Text>();
        ManaBar = GameObject.FindGameObjectWithTag("ManaBar").GetComponent<Slider>();
        ManaText = GameObject.FindGameObjectWithTag("ManaText").GetComponent<Text>();
        maxHealth = 0;
        maxMana = 0;
        enemyMaxHealth = 300;
        enemyHealth1 = GameObject.FindGameObjectWithTag("EnemySlider1").GetComponent<Slider>();
        enemyHealth2 = GameObject.FindGameObjectWithTag("EnemySlider2").GetComponent<Slider>();
        enemyHealth3 = GameObject.FindGameObjectWithTag("EnemySlider3").GetComponent<Slider>();
        bossHealth = GameObject.FindGameObjectWithTag("BossSlider").GetComponent<Slider>();
        Gwyn = GameObject.FindGameObjectWithTag("Slider1").GetComponent<Slider>();
        Fredalf = GameObject.FindGameObjectWithTag("Slider2").GetComponent<Slider>();
        Ceryz = GameObject.FindGameObjectWithTag("Slider3").GetComponent<Slider>();
    }
    public void showHealth(GameInfo activePlayer)
    {

        if (activePlayer.id == 1)
        {
            maxHealth = activePlayer.maxHealth;
            healthBar.maxValue = maxHealth;
            Gwyn.maxValue = maxHealth;
            Gwyn.value = activePlayer.health;
        }
        else if (activePlayer.id == 2)
        {
            maxHealth = activePlayer.maxHealth;
            healthBar.maxValue = maxHealth;
            Fredalf.maxValue = maxHealth;
            Fredalf.value = activePlayer.health;
        }
        else if (activePlayer.id == 3)
        {
            maxHealth = activePlayer.maxHealth;
            healthBar.maxValue = maxHealth;
            Ceryz.maxValue = maxHealth;
            Ceryz.value = activePlayer.health;
        }
        healthBar.value = activePlayer.health;
        healthText.text = activePlayer.health.ToString() + " / " + maxHealth;
    }
    public void showMana(GameInfo activePlayer)
    {
        if (activePlayer.id == 1)
        {
            maxMana = 50;
            ManaBar.maxValue = maxMana;
            if (activePlayer.magic >= 50)
            {
                activePlayer.magic = 50;
            }
        }
        else if (activePlayer.id == 2)
        {
            if (activePlayer.magic >= 50)
            {
                activePlayer.magic = 50;
            }
            maxMana = 50;
            ManaBar.maxValue = maxMana;
        }
        else if (activePlayer.id == 3)
        {
            if (activePlayer.magic >= 50)
            {
                activePlayer.magic = 50;
            }
            maxMana = 50;
            ManaBar.maxValue = maxMana;
        }
        else
        {
            maxMana = 100;
        }
        ManaBar.value = activePlayer.magic;
        ManaText.text = activePlayer.magic.ToString() + " / " + maxMana;
    }
    // Update is called once per frame

    public void enemyHealth(PlayerStats enemy)
    {
        if (enemy.id == 1)
        {
            bossHealth.maxValue = 1000;
            bossHealth.value = enemy.health;
        }
        else
        {
            if (enemy.order == 1)
            {
                enemyHealth1.maxValue = enemyMaxHealth;
                enemyHealth1.value = enemy.health;
            }
            if (enemy.order == 2)
            {
                enemyHealth2.maxValue = enemyMaxHealth;
                enemyHealth2.value = enemy.health;
            }
            if (enemy.order == 3)
            {
                enemyHealth3.maxValue = enemyMaxHealth;
                enemyHealth3.value = enemy.health;
            }
        }

    }
}