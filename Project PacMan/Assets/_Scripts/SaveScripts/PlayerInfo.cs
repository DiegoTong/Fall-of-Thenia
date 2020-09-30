using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo instance = null;
    string playerName = "Place Holder";
    int playerLevel;
    public static int gold = 0;
    public static int stamina;
    public static int magic;
    public static int power;
    public static int health;
    public static int speed;
    public static int armor;
    public List<Ability> playerAbilities = new List<Ability>();
    public Ability playermove1 = new Attack();
    public Ability playermove2 = new SpecialAttack();
    public Ability playermove3 = new EndlessBarrage();
    public Ability playermove4 = new WarCry();
    public Ability playermove5 = new HollyHealing();
    public Dictionary<string, GameInfo> playerInfo = new Dictionary<string, GameInfo>();
    GameInfo pi1;
    GameInfo pi2;
    GameInfo pi3;
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
        // playerName; playerLevel = 0;stamina = 0;magic = 0;power = 0; health = 0;speed = 0;armor = 0;order = 0;id = 0; ability;
        DontDestroyOnLoad(gameObject);
        pi1 = new GameInfo("Gwyn", 1, 1, 50, 40, 310, 5, 0, 0, 1,310, new EndlessBarrage());
        playerInfo.Add("Gwyn", pi1);
        pi2 = new GameInfo("Fredalf", 1, 5, 50, 40, 320, 1, 10, 0, 2,320, new WarCry());
        playerInfo.Add("Fredalf", pi2);
        pi3 = new GameInfo("Ceryz", 1, 5, 50, 40, 330, 0, 0, 0, 3,330, new HollyHealing());
        playerInfo.Add("Ceryz", pi3);
    }

    public string PlayerName
    {
        get { return playerName; }
    }

    public int PlayerLevel
    {
        get { return playerLevel; }
        set { playerLevel = value; }
    }
    public int Stamina
    {
        get { return stamina; }
        set { stamina = value; }
    }

    public int Magic
    {
        get { return magic; }
        set { magic = value; }
    }
    public int Health
    {
        get { return stamina; }
        set { stamina = value; }
    }
    public int Speed
    {
        get { return stamina; }
        set { stamina = value; }
    }
    public int Armor
    {
        get { return stamina; }
        set { stamina = value; }
    }
    public int Power
    {
        get { return power; }
        set { power = value; }
    }
    public int Gold
    {
        get { return gold; }
        set { gold = value; }
    }
    public void RestorePreferences()
    {

    }
}
