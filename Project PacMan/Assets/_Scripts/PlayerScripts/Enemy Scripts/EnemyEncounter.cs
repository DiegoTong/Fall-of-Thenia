using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEncounter : MonoBehaviour
{
    public static EnemyEncounter instance = null;
    PlayerStats enemy1;
    PlayerStats enemy2;
    PlayerStats enemy3;
    PlayerStats boss;
    public Dictionary<int, PlayerStats> enemyParty = new Dictionary<int, PlayerStats>();
    public int encounterID;
    public int numberOfEncoutners;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void NumberOfEnemies(int encounterNumber, int sprite)
    {
        numberOfEncoutners = encounterNumber;
        if (encounterNumber != 4)
        {
            if (encounterNumber == 1)
            {
                enemy1 = new PlayerStats(true, 1, 1, 10, 20, 300, 0, 10, 1, 0);
                enemy2 = new PlayerStats(false, 1, 1, 10, 20, 300, 0, 10, 2, 0);
                enemy3 = new PlayerStats(false, 1, 1, 10, 10, 300, 0, 10, 3, 0);
            }
            if (encounterNumber == 2)
            {
                enemy1 = new PlayerStats(true, 1, 1, 10, 20, 300, 0, 10, 1, 0);
                enemy2 = new PlayerStats(true, 1, 1, 10, 20, 300, 0, 10, 2, 0);
                enemy3 = new PlayerStats(false, 1, 1, 10, 20, 300, 0, 10, 3, 0);
            }
            if (encounterNumber == 3)
            {
                enemy1 = new PlayerStats(true, 1, 1, 10, 10, 300, 0, 10, 1, 0);
                enemy2 = new PlayerStats(true, 1, 1, 10, 10, 300, 0, 10, 2, 0);
                enemy3 = new PlayerStats(true, 1, 1, 10, 10, 300, 0, 10, 3, 0);
            }
            enemyParty.Add(1, enemy1);
            enemyParty.Add(2, enemy2);
            enemyParty.Add(3, enemy3);
        }
        else
        {
            boss = new PlayerStats(true, 1, 1, 1, 10, 1000, 0, 10, 1, 1);
            enemy2 = new PlayerStats(false, 1, 1, 10, 10, 0, 0, 10, 2, 0);
            enemy3 = new PlayerStats(false, 1, 1, 10, 10, 0, 0, 10, 3, 0);
            enemyParty.Add(1, boss);
            enemyParty.Add(2, enemy2);
            enemyParty.Add(3, enemy3);
        }
        encounterID = sprite;
    }
    public void ClearEnemies()
    {
        enemyParty.Remove(1);
        enemyParty.Remove(2);
        enemyParty.Remove(3);
    }
}
