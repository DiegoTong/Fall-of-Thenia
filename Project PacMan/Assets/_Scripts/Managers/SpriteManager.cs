using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpriteManager : MonoBehaviour
{
    public GameObject player;
    public Ability playerUsedAbility;
    public PlayerInfo playerstats;
    diegoinventory inventory;
    public GameObject turnbase;
    TurnBaseManager turnBaseManager;
    public Sprite normalBackground;
    public Sprite tutorialBackground;
    public Sprite SoliceBackground;
    public Sprite Ruma;
    public Sprite Boss;
    public Sprite minion;
    public Sprite Gwyn;
    public Sprite Ceryz;
    public Sprite Fredalf;
    public Sprite arrow;
    public Sprite blank;
    public Sprite C1;
    public Sprite C2;
    public Sprite C3;
    public Sprite F1;
    public Sprite F2;
    public Sprite F3;
    public Sprite G1;
    public Sprite G2;
    public Sprite G3;
    Text currentPlayerText;
    Image backgroundSR;
    SpriteRenderer minionSR;
    SpriteRenderer bossSR;
    Image characterPortrait;
    Animator minionAnim;
    Animator crystalAnim;
    public RuntimeAnimatorController rumaAnim;
    public RuntimeAnimatorController XOAnim;
    public RuntimeAnimatorController SoldierAnim;
    public RuntimeAnimatorController CrystalCTR;
    Image arrowPosition;
    Image arrowEnemySelect;
    Image skill1;
    Image skill2;
    Image skill3;
    Text Description;
    void Start()
    {
        turnbase = GameObject.FindGameObjectWithTag("TurnManager");
        turnBaseManager = turnbase.GetComponent<TurnBaseManager>();
        player = GameObject.FindGameObjectWithTag("PlayerInfo");
        playerstats = player.GetComponent<PlayerInfo>();
        inventory = player.GetComponent<diegoinventory>();
        enemyArrowBlank();
    }
    // 1 normal battle
    // 2 tutorial battle
    // 3 Solice battle
    // 4 Boss battle
    // else normal battle
    public void changePortrait(GameInfo currentCharacter)
    {
        characterPortrait = GameObject.FindGameObjectWithTag("CharacterPortrait").GetComponent<Image>();
        if (currentCharacter.id == 1)
        {
            characterPortrait.sprite = Gwyn;
        }
        else if (currentCharacter.id == 2)
        {

            characterPortrait.sprite = Fredalf;
        }
        else if (currentCharacter.id == 3)
        {

            characterPortrait.sprite = Ceryz;
        }
    }
    public void bakcgroundChange(int id)
    {
        minionSR = GameObject.FindGameObjectWithTag("EnemyUnit2").GetComponent<SpriteRenderer>();
        minionAnim = GameObject.FindGameObjectWithTag("EnemyUnit2").GetComponent<Animator>();
        bossSR = GameObject.FindGameObjectWithTag("Boss").GetComponent<SpriteRenderer>();
        bossSR.sprite = Boss;
        backgroundSR = GameObject.FindGameObjectWithTag("Background").GetComponent<Image>();
        if (id == 1)
        {
            backgroundSR.sprite = normalBackground;
            minionSR = GameObject.FindGameObjectWithTag("EnemyUnit1").GetComponent<SpriteRenderer>();
            minionAnim = GameObject.FindGameObjectWithTag("EnemyUnit1").GetComponent<Animator>();
            minionAnim.runtimeAnimatorController = XOAnim;
            minionSR.sprite = Boss;
            minionSR = GameObject.FindGameObjectWithTag("EnemyUnit2").GetComponent<SpriteRenderer>();
            minionAnim = GameObject.FindGameObjectWithTag("EnemyUnit2").GetComponent<Animator>();
            minionSR.sprite = minion;
            minionAnim.runtimeAnimatorController = SoldierAnim;
            minionSR = GameObject.FindGameObjectWithTag("EnemyUnit3").GetComponent<SpriteRenderer>();
            minionAnim = GameObject.FindGameObjectWithTag("EnemyUnit3").GetComponent<Animator>();
            minionSR.sprite = minion;
            minionAnim.runtimeAnimatorController = SoldierAnim;
        }
        else if (id == 2)
        {
            backgroundSR.sprite = tutorialBackground;
            minionSR = GameObject.FindGameObjectWithTag("EnemyUnit1").GetComponent<SpriteRenderer>();
            minionAnim = GameObject.FindGameObjectWithTag("EnemyUnit1").GetComponent<Animator>();
            minionAnim.runtimeAnimatorController = rumaAnim;
            minionSR.sprite = Ruma;
            minionSR = GameObject.FindGameObjectWithTag("EnemyUnit2").GetComponent<SpriteRenderer>();
            minionAnim = GameObject.FindGameObjectWithTag("EnemyUnit2").GetComponent<Animator>();
            minionAnim.runtimeAnimatorController = SoldierAnim;
            minionSR.sprite = Ruma;
            minionSR = GameObject.FindGameObjectWithTag("EnemyUnit3").GetComponent<SpriteRenderer>();
            minionAnim = GameObject.FindGameObjectWithTag("EnemyUnit3").GetComponent<Animator>();
            minionAnim.runtimeAnimatorController = SoldierAnim;
            minionSR.sprite = minion;
        }
        else if (id == 3)
        {
            backgroundSR.sprite = SoliceBackground;
            minionSR = GameObject.FindGameObjectWithTag("EnemyUnit1").GetComponent<SpriteRenderer>();
            minionAnim = GameObject.FindGameObjectWithTag("EnemyUnit1").GetComponent<Animator>();
            minionAnim.runtimeAnimatorController = XOAnim;
            minionSR.sprite = Boss;
            minionSR = GameObject.FindGameObjectWithTag("EnemyUnit2").GetComponent<SpriteRenderer>();
            minionAnim = GameObject.FindGameObjectWithTag("EnemyUnit2").GetComponent<Animator>();
            minionAnim.runtimeAnimatorController = SoldierAnim;
            minionSR.sprite = minion;
            minionSR = GameObject.FindGameObjectWithTag("EnemyUnit3").GetComponent<SpriteRenderer>();
            minionAnim = GameObject.FindGameObjectWithTag("EnemyUnit3").GetComponent<Animator>();
            minionAnim.runtimeAnimatorController = SoldierAnim;
            minionSR.sprite = minion;
        }
        else if (id ==4)
        {
            backgroundSR.sprite = tutorialBackground;
            bossSR = GameObject.FindGameObjectWithTag("Boss").GetComponent<SpriteRenderer>();
            bossSR.sprite = Boss;
        }
        else
        {
            backgroundSR.sprite = normalBackground;
            minionSR = GameObject.FindGameObjectWithTag("EnemyUnit1").GetComponent<SpriteRenderer>();
            minionAnim = GameObject.FindGameObjectWithTag("EnemyUnit1").GetComponent<Animator>();
            minionAnim.runtimeAnimatorController = SoldierAnim;
            minionSR.sprite = minion;
            minionSR = GameObject.FindGameObjectWithTag("EnemyUnit2").GetComponent<SpriteRenderer>();
            minionAnim = GameObject.FindGameObjectWithTag("EnemyUnit2").GetComponent<Animator>();
            minionAnim.runtimeAnimatorController = SoldierAnim;
            minionSR.sprite = minion;
            minionSR = GameObject.FindGameObjectWithTag("EnemyUnit3").GetComponent<SpriteRenderer>();
            minionAnim = GameObject.FindGameObjectWithTag("EnemyUnit3").GetComponent<Animator>();
            minionAnim.runtimeAnimatorController = SoldierAnim;
            minionSR.sprite = minion;
        }
    }

    public void ArrowPointsCurrent(GameInfo currentPlayer)
    {
        if(currentPlayer.id ==1)
        {
            crystalAnim = GameObject.Find("garrow1").GetComponent<Animator>();
            crystalAnim.runtimeAnimatorController = CrystalCTR;
            crystalAnim = GameObject.Find("garrow2").GetComponent<Animator>();
            crystalAnim.runtimeAnimatorController = null;
            crystalAnim = GameObject.Find("garrow3").GetComponent<Animator>();
            crystalAnim.runtimeAnimatorController = null;
            currentPlayerText = GameObject.Find("Current_Player_Text").GetComponent<Text>();
            currentPlayerText.text = currentPlayer.playerName;
        }
        else if (currentPlayer.id == 2)
        {
            crystalAnim = GameObject.Find("garrow1").GetComponent<Animator>();
            crystalAnim.runtimeAnimatorController = null;
            crystalAnim = GameObject.Find("garrow2").GetComponent<Animator>();
            crystalAnim.runtimeAnimatorController = CrystalCTR;
            crystalAnim = GameObject.Find("garrow3").GetComponent<Animator>();
            crystalAnim.runtimeAnimatorController = null;
            currentPlayerText.text = currentPlayer.playerName;
        }
        else if (currentPlayer.id == 3)
        {
            crystalAnim = GameObject.Find("garrow1").GetComponent<Animator>();
            crystalAnim.runtimeAnimatorController = null;
            crystalAnim = GameObject.Find("garrow2").GetComponent<Animator>();
            crystalAnim.runtimeAnimatorController = null;
            crystalAnim = GameObject.Find("garrow3").GetComponent<Animator>();
            crystalAnim.runtimeAnimatorController = CrystalCTR;
            currentPlayerText.text = currentPlayer.playerName;
        }
    }

    public void selectEnemy1()
    {
        crystalAnim = GameObject.Find("barrow1").GetComponent<Animator>();
        crystalAnim.runtimeAnimatorController = CrystalCTR;
        crystalAnim = GameObject.Find("barrow2").GetComponent<Animator>();
        crystalAnim.runtimeAnimatorController = null;
        crystalAnim = GameObject.Find("barrow3").GetComponent<Animator>();
        crystalAnim.runtimeAnimatorController = null;
        currentPlayerText = GameObject.Find("Current_Player_Text").GetComponent<Text>();
        Debug.Log("enter");
    }
    public void selectEnemy2()
    {
        crystalAnim = GameObject.Find("barrow1").GetComponent<Animator>();
        crystalAnim.runtimeAnimatorController = null;
        crystalAnim = GameObject.Find("barrow2").GetComponent<Animator>();
        crystalAnim.runtimeAnimatorController = CrystalCTR;
        crystalAnim = GameObject.Find("barrow3").GetComponent<Animator>();
        crystalAnim.runtimeAnimatorController = null;
        Debug.Log("enter");
    }
    public void selectEnemy3()
    {
        crystalAnim = GameObject.Find("barrow1").GetComponent<Animator>();
        crystalAnim.runtimeAnimatorController = null;
        crystalAnim = GameObject.Find("barrow2").GetComponent<Animator>();
        crystalAnim.runtimeAnimatorController = null;
        crystalAnim = GameObject.Find("barrow3").GetComponent<Animator>();
        crystalAnim.runtimeAnimatorController = CrystalCTR;
        arrowEnemySelect = GameObject.Find("barrow4").GetComponent<Image>();
        arrowEnemySelect.sprite = blank;
    }

    public void enemyArrowBlank()
    {
        crystalAnim = GameObject.Find("barrow1").GetComponent<Animator>();
        crystalAnim.runtimeAnimatorController = null;
        crystalAnim = GameObject.Find("barrow2").GetComponent<Animator>();
        crystalAnim.runtimeAnimatorController = null;
        crystalAnim = GameObject.Find("barrow3").GetComponent<Animator>();
        crystalAnim.runtimeAnimatorController = null;
        crystalAnim = GameObject.Find("barrow4").GetComponent<Animator>();
        crystalAnim.runtimeAnimatorController = null;
    }

    public void changeSpriteGwyn()
    {
        skill1 = GameObject.Find("Skill1").GetComponent<Image>();
        skill1.sprite = G1;
        skill2 = GameObject.Find("Skill2").GetComponent<Image>();
        skill2.sprite = G2;
        skill3 = GameObject.Find("Skill3").GetComponent<Image>();
        skill3.sprite = G3;

    }
    public void changeSpriteCeryz()
    {
        skill1 = GameObject.Find("Skill1").GetComponent<Image>();
        skill1.sprite = C1;
        skill2 = GameObject.Find("Skill2").GetComponent<Image>();
        skill2.sprite = C2;
        skill3 = GameObject.Find("Skill3").GetComponent<Image>();
        skill3.sprite = C3;
    }
    public void changeSpriteFredalf()
    {
        skill1 = GameObject.Find("Skill1").GetComponent<Image>();
        skill1.sprite = F1;
        skill2 = GameObject.Find("Skill2").GetComponent<Image>();
        skill2.sprite = F2;
        skill3 = GameObject.Find("Skill3").GetComponent<Image>();
        skill3.sprite = F3;
    }

    public void changeDescriptionTextAttack()
    {
        Description = GameObject.Find("DescriptionText").GetComponent<Text>();
        Description.text = "Attacked an Enemy";
    }

    public void changeDescriptionTextAbility1()
    {
        if (turnBaseManager.activePlayer.playerName == playerstats.playerInfo["Gwyn"].playerName)
        {
            Description = GameObject.Find("DescriptionText").GetComponent<Text>();
            playerUsedAbility = new TargetShot();
            Description.text = playerUsedAbility.AbilityName +": "+playerUsedAbility.AbilityDescription + " Ability cost: " + playerUsedAbility.AbilityCost;
        }
        if (turnBaseManager.activePlayer.playerName == playerstats.playerInfo["Fredalf"].playerName)
        {
            Description = GameObject.Find("DescriptionText").GetComponent<Text>();
            playerUsedAbility = new ToArms();
            Description.text = playerUsedAbility.AbilityName + ": " + playerUsedAbility.AbilityDescription + " Ability cost: " + playerUsedAbility.AbilityCost;
        }
        if (turnBaseManager.activePlayer.playerName == playerstats.playerInfo["Ceryz"].playerName)
        {
            Description = GameObject.Find("DescriptionText").GetComponent<Text>();
            playerUsedAbility = new FireBall();
            Description.text = playerUsedAbility.AbilityName + ": " + playerUsedAbility.AbilityDescription + " Ability cost: " + playerUsedAbility.AbilityCost;
        }
    }

    public void changeDescriptionTextAbility2()
    {
        if (turnBaseManager.activePlayer.playerName == playerstats.playerInfo["Gwyn"].playerName)
        {
            Description = GameObject.Find("DescriptionText").GetComponent<Text>();
            playerUsedAbility = new Reload();
            Description.text = playerUsedAbility.AbilityName + ": " + playerUsedAbility.AbilityDescription + " Ability cost: " + playerUsedAbility.AbilityCost;
        }
        if (turnBaseManager.activePlayer.playerName == playerstats.playerInfo["Fredalf"].playerName)
        {
            Description = GameObject.Find("DescriptionText").GetComponent<Text>();
            playerUsedAbility = new Rally();
            Description.text = playerUsedAbility.AbilityName + ": " + playerUsedAbility.AbilityDescription + " Ability cost: " + playerUsedAbility.AbilityCost;
        }
        if (turnBaseManager.activePlayer.playerName == playerstats.playerInfo["Ceryz"].playerName)
        {
            Description = GameObject.Find("DescriptionText").GetComponent<Text>();
            playerUsedAbility = new TargetHealing();
            Description.text = playerUsedAbility.AbilityName + ": " + playerUsedAbility.AbilityDescription + " Ability cost: " + playerUsedAbility.AbilityCost;
        }
    }

    public void changeDescriptionTextAbility3()
    {
        if (turnBaseManager.activePlayer.playerName == playerstats.playerInfo["Gwyn"].playerName)
        {
            Description = GameObject.Find("DescriptionText").GetComponent<Text>();
            playerUsedAbility = new EndlessBarrage();
            Description.text = playerUsedAbility.AbilityName + ": " + playerUsedAbility.AbilityDescription + " Ability cost: " + playerUsedAbility.AbilityCost;
        }
        if (turnBaseManager.activePlayer.playerName == playerstats.playerInfo["Fredalf"].playerName)
        {
            Description = GameObject.Find("DescriptionText").GetComponent<Text>();
            playerUsedAbility = new WarCry();
            Description.text = playerUsedAbility.AbilityName + ": " + playerUsedAbility.AbilityDescription + " Ability cost: " + playerUsedAbility.AbilityCost;
        }
        if (turnBaseManager.activePlayer.playerName == playerstats.playerInfo["Ceryz"].playerName)
        {
            Description = GameObject.Find("DescriptionText").GetComponent<Text>();
            playerUsedAbility = new HollyHealing();
            Description.text = playerUsedAbility.AbilityName + ": " + playerUsedAbility.AbilityDescription + " Ability cost: " + playerUsedAbility.AbilityCost;
        }
    }
    public void changeDescriptionItem1()
    {
        Description = GameObject.Find("DescriptionText").GetComponent<Text>();
        Description.text = inventory.Items["Potion"].itemName +": "+inventory.Items["Potion"].itemDesc;
    }
    public void changeDescriptionItem2()
    {
        Description = GameObject.Find("DescriptionText").GetComponent<Text>();
        Description.text = inventory.Items["RevivalShard"].itemName + ": " + inventory.Items["RevivalShard"].itemDesc;
    }
    public void changeDescriptionItem3()
    {
        Description = GameObject.Find("DescriptionText").GetComponent<Text>();
        Description.text = inventory.Items["CrystalShard"].itemName + ": " + inventory.Items["CrystalShard"].itemDesc;
    }
    public void changeDescriptionItem4()
    {
        Description = GameObject.Find("DescriptionText").GetComponent<Text>();
        Description.text = inventory.Items["MegaPotion"].itemName + ": " + inventory.Items["MegaPotion"].itemDesc;
    }
    public void changeDescriptionItem5()
    {
        Description = GameObject.Find("DescriptionText").GetComponent<Text>();
        Description.text = inventory.Items["MegaCrystalShard"].itemName + ": " + inventory.Items["MegaCrystalShard"].itemDesc;
    }
    public void changeDescriptionMisc()
    {
        Description = GameObject.Find("DescriptionText").GetComponent<Text>();
        Description.text = "Hi";
    }
    public void changeDescriptionFailedToRun()
    {
        Description = GameObject.Find("DescriptionText").GetComponent<Text>();
        Description.text = "Failed to run Away";
    }
}
