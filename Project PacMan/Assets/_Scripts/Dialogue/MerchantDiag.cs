using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MerchantDiag : MonoBehaviour
{
    public Dialogs[] merchantDialogs = new Dialogs[10];
    public GameObject p_Merchant;

    void Start()
    {
        // First entrance to the Shop
        merchantDialogs[0] = new Dialogs("Hello, and Welcome to my shop! On the right is my inventory where you can see my wares," +
            " their Stats and Bonuses and on the far right the Price", 0, 1);

        // Enough Money
        merchantDialogs[1] = new Dialogs("It’s All yours", 0, 2);
        merchantDialogs[2] = new Dialogs("I’ll take that off the shelf for you", 0, 3);

        // Not Enough Money
        merchantDialogs[3] = new Dialogs("You need money for that", 0, 4);
        merchantDialogs[4] = new Dialogs("That’s a little too rich for you", 0, 5);

        // Random Entry Dialogue
        merchantDialogs[5] = new Dialogs("My wares are almost guaranteed not to break", 0, 6);
        merchantDialogs[6] = new Dialogs("Last person that didn’t get any armor never returned. Can’t imagine why", 0, 7);
        merchantDialogs[7] = new Dialogs("I used to be an adventurer… But this was more profitable", 0, 8);

        // Leaving the Store
        merchantDialogs[8] = new Dialogs("Thanks for coming!", 0, 10);
        merchantDialogs[9] = new Dialogs("Come Agian! Your Money is Always Welcome Here!", 0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
