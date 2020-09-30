using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

enum chars
{
    CERYZ = 0,
    GWYN,
    RUMA,
    FREDALF,
    GWYNANDCERYZ,
    NOKSOLDIER,
    GLENN,
    GARLAND,
    COMMANDERBRETT,
    CIV,

    NUM_CHARACTERS
}


public class FirstSpeach : MonoBehaviour
{

    public Dialogs[] introDiag = new Dialogs[100];

    //// leave empty lines to seperate different convos
    //{"second Convo", CERYZ, RUMA, -1} //-1 means end of convo 
    public static bool breakBarrier = false;

    public Text speachText;
    public int nextDialog = 0;
    // Character Portraits
    public GameObject p_Ceryz;
    public GameObject p_Gwyn;
    public GameObject p_Ruma;
    public GameObject p_Fredalf;
    public GameObject p_GwynAndCeryz;
    public GameObject p_Glenn;

    public GameObject button;
    public Animator animator;

    SceneTransitions scenetransitions;


    // Fairly large due too amount of dialogue
    // Don't change the order of the dialogues!!!!!!
    private void Start()
    {
        scenetransitions = GameObject.FindGameObjectWithTag("PlayerInfo").GetComponent<SceneTransitions>();
        // Convo 1 - Leads to tutorial Batle
        // Cutscene 1-1
        introDiag[0] = new Dialogs("We gather here today, to witness two of our finest apprentices, " +
            "Gwyn and Ceryz, Transend to the rank of scholar.", (int)chars.RUMA, 1);
        introDiag[1] = new Dialogs("Over the last few years they have proven time and again their" +
            " abilities in the fields of medicine, combat and academics. ", (int)chars.RUMA, 2);
        introDiag[2] = new Dialogs("Today they must face me for their final test to prove one last " +
            "time that they are ready to set forth on their journey to further their studies. ", (int)chars.RUMA, 3);
        introDiag[3] = new Dialogs("We’re honored to be facing you today.", (int)chars.CERYZ, 4);
        introDiag[4] = new Dialogs("We hope to be able to live up to your expectations.", (int)chars.GWYN, 5);
        introDiag[5] = new Dialogs("I have no doubts that you both will be able to exceed my expectations…Now, lets begin.", (int)chars.RUMA, 6);


        // Convo 2 - After Tutorial battle
        // Cutscene 1-2
        introDiag[6] = new Dialogs("Congratulations! As I expected both of you have fully exceeded my expectations.", (int)chars.RUMA, 7);
        introDiag[7] = new Dialogs("Thank you *Bow*", (int)chars.GWYNANDCERYZ, 8);
        introDiag[8] = new Dialogs("You have both made me so proud. Gwyn, my daughter, from the moment you first opened" +
            " your eyes, I knew you were destined for greatness.", (int)chars.RUMA, 9);
        introDiag[9] = new Dialogs("Your skills with a bow are unmatched and your kindness and beauty are fit for a queen I know " +
            "if your father was here, he would be honored to call you his daughter.", (int)chars.RUMA, 10);
        introDiag[10] = new Dialogs("Thank You Mother", (int)chars.GWYN, 11);
        introDiag[11] = new Dialogs("Ceryz, ever since that fateful night that tragically claimed your parents and brought you into " +
            "my care, I have watched you grow to become one of the best mages I have ever seen", (int)chars.RUMA, 12);
        introDiag[12] = new Dialogs("Though it was fire that claimed your family, like the mighty Phoenix you have risen " +
            "from the ashes to harness and claim those fires as your own.", (int)chars.RUMA, 13);
        introDiag[13] = new Dialogs("Thank you Ruma", (int)chars.CERYZ, 14);
        introDiag[14] = new Dialogs("But alas, I have taught you everything that I know. It is time for you to venture forth to learn " +
            "from the other elders. I offer you these last parting gifts to aid in your journey.", (int)chars.RUMA, 15);
        introDiag[15] = new Dialogs("Now go forth to Solise and speak with Elder Bolina, she will further your training and help you " +
            "both to hone your skills.", (int)chars.RUMA, 16);
        introDiag[16] = new Dialogs("Thank you mother, I promise I will return soon.", (int)chars.GWYN, 17);
        introDiag[17] = new Dialogs("Thank you Ruma, for everything you’ve done, I hope to one day be able to pay you back.", (int)chars.CERYZ, 18);
        introDiag[18] = new Dialogs("Goodbye my children, May your journey be a safe one.", (int)chars.RUMA, 19);

        // Convo 3 - Journey to the burnt forest
        // Cutscene 1-3-1
        introDiag[19] = new Dialogs("We’ve made it to the border, do you want to stop for food now or push on to Solise? There " +
            "should be a good fishing spot just up ahead, on the edge where our borders meet.", (int)chars.CERYZ, 20);

        introDiag[20] = new Dialogs(" ... ", (int)chars.GWYN, 21);
        introDiag[21] = new Dialogs("Is everything alright? It’s not like you to pass up on decent meal.", (int)chars.CERYZ, 22);
        introDiag[22] = new Dialogs("Don’t you find it strange how quiet it is? This place is usually crawling with wild life, " +
            "but we haven’t run into anything, not even a bird or deer which heavily populate the area.", (int)chars.GWYN, 23);
        introDiag[23] = new Dialogs("Now that you mention it something does feel a bit off, its as if the forest its self has " +
            "just stopped with time.", (int)chars.CERYZ, 24);

        introDiag[24] = new Dialogs("Look just above the tree line, there seems to be a big cloud of smoke hovering around Solise, we should hurry! *Runs off*", (int)chars.GWYN, 25);
        introDiag[25] = new Dialogs("WAIT, ugh, always just goes running off before even examining the situation, for all we know they’re setting up " +
            "a feast for our arrival or anything really. Doesn’t always have to mean danger.", (int)chars.CERYZ, 26);

        // Transitions to Cutscene 1-3-2

        introDiag[26] = new Dialogs("*huff* *huff*, by the primordials, I swear you’ll be the death of me.", (int)chars.CERYZ, 27);
        introDiag[27] = new Dialogs("*gasp*.", (int)chars.CERYZ, 28);
        introDiag[28] = new Dialogs("No, who could have done this. We should check for survivors, at the very least we can find someone alive, who can hopefully fill " +
            "us in on what happened, then report back to my mother.", (int)chars.GWYN, 29);
        introDiag[29] = new Dialogs("If you would have just handed over the Zotun crystal, this could have all been avoided!", (int)chars.NOKSOLDIER, 30);
        introDiag[30] = new Dialogs("What was that? I think I heard something coming from over there.", (int)chars.GWYN, 31);

        // Transitions to Cutscene 1-3-3

        introDiag[31] = new Dialogs("Back away from him now!", (int)chars.GWYN, 32);
        introDiag[32] = new Dialogs("looks like we’ve got some more stragglers", (int)chars.NOKSOLDIER, 33);
        introDiag[33] = new Dialogs("you heard Garland, no survivors. Wiggs, Blank dispose of them quickly.", (int)chars.NOKSOLDIER, 34);
        introDiag[34] = new Dialogs("YESSIR!", (int)chars.NOKSOLDIER, 35); // Transition to Village Battle

        //Convo 4 - After Village Combat

        introDiag[35] = new Dialogs("Ceryz, quickly try and heal his wounds", (int)chars.GWYN, 36);
        //*a green aura on the bottom of screen*
        introDiag[36] = new Dialogs("I was able to stop bleeding, but I don’t think he’ll last much longer unless we can get him to a proper doctor.", (int)chars.CERYZ, 37);
        introDiag[37] = new Dialogs("Are you able to speak?", (int)chars.GWYN, 38);
        introDiag[38] = new Dialogs("..Y..Yes", (int)chars.CIV, 39);
        introDiag[39] = new Dialogs("What happened here? Why did the noks attack you guys?", (int)chars.GWYN, 40);
        introDiag[40] = new Dialogs("Th…They Came for the crystal… Slaughtered everyone when we refused..", (int)chars.CIV, 41);
        introDiag[41] = new Dialogs("What would they want with the Zotun crystals?", (int)chars.CERYZ, 42);
        introDiag[42] = new Dialogs("Their powers… The crystals…they want to refine the crystals…please…you must warn the other villages…*Dies*", (int)chars.CIV, 43);
        introDiag[43] = new Dialogs("Come on, we need to go warn Ruma", (int)chars.CERYZ, 44);

        // Convo 5 - Return to Ruma
        introDiag[44] = new Dialogs("Ruma!", (int)chars.CERYZ, 45);
        introDiag[45] = new Dialogs("Ceryz? What are you doing back so soon?", (int)chars.RUMA, 46);
        introDiag[46] = new Dialogs("its Solise, its been attacked!", (int)chars.CERYZ, 47);
        introDiag[47] = new Dialogs("It’s the noks, they slaughtered the entire village and took their zotun crystal!", (int)chars.GWYN, 48);
        introDiag[48] = new Dialogs("Girls, please calm down, now one at a time what is going on?", (int)chars.RUMA, 49);
        introDiag[49] = new Dialogs("The noks, they violated the treaty and attacked S and stole their crystal.", (int)chars.CERYZ, 50);
        introDiag[50] = new Dialogs("By the primordials... what of the villagers? What of Bolina?", (int)chars.GWYN, 51);
        introDiag[51] = new Dialogs("Im sorry mother, there were no survivors. By the time we got there the noks were “cleaning up” their mess...", (int)chars.GWYN, 52);
        introDiag[52] = new Dialogs("There were a few stragglers, we managed to fend them off and heal one man, but unfortunately he succumbed to " +
            "his wounds, but before he passed he wanted us to give you the message that the Noks are collecting the Crystals of zotun.", (int)chars.GWYN, 53);
        introDiag[53] = new Dialogs("But why? These artifacts are practically useless to them?", (int)chars.RUMA, 54);
        introDiag[54] = new Dialogs("they want to try and refine them, so that they can try and harness their power to absorb the elements.", (int)chars.GWYN, 55);
        introDiag[55] = new Dialogs("that’s impossible… *Sigh* Gwyn, Ceryz, I need you two to head east to Lothar and warn Glenn of what has happened," +
            " with the treaty broken we must prepare for the coming battles.", (int)chars.GWYN, 56);

        // Convo 6 - Talking to glen


        introDiag[56] = new Dialogs("Elder Glen!", (int)chars.CERYZ, 57);
        introDiag[57] = new Dialogs("Gwyn, Ceryz! I haven’t seen you two in quite some time, shouldn’t you be in Solise?", (int)chars.GLENN, 58);
        introDiag[58] = new Dialogs("That’s why were here, Solise has been raided by the Noks", (int)chars.GWYN, 59);
        introDiag[59] = new Dialogs("That is grave news indeed… What aboot survivors?", (int)chars.GLENN, 60);
        introDiag[60] = new Dialogs("None……", (int)chars.GWYN, 61);
        introDiag[61] = new Dialogs("This is troubling indeed eh…Do you know the purpose of the raid?", (int)chars.GLENN, 62);
        introDiag[62] = new Dialogs("The Noks are trying to gather the Zotun crystals, Elder Ruma asked us to inform you as there could be more attacks.", (int)chars.CERYZ, 63);
        introDiag[63] = new Dialogs("To be expected, I’ll begin sending messengers to the other elders to rally the War council… Thank you for telling me. ", (int)chars.GLENN, 64);
        introDiag[64] = new Dialogs("Its getting dark out, you two should bunk down here for the night, the woods would be specially unsafe with the Noks prowling about", (int)chars.GLENN, 65);
        introDiag[65] = new Dialogs("Thank you elder.", (int)chars.CERYZ, 66);
        introDiag[66] = new Dialogs("In the morning you two should head back to Tolpos, Ruma may need you if the Noks attack there", (int)chars.GLENN, 67);

        // The Next Day transition

        introDiag[67] = new Dialogs("Good morning, I hope the two of you slept well. I dispatched the riders before the break of dawn, most should reach their " +
            "destinations by nightfall.", (int)chars.GLENN, 68);
        introDiag[68] = new Dialogs("I’ve also prepared some potions for your journey back just in case you run into any trouble.", (int)chars.GLENN, 69);
        introDiag[69] = new Dialogs("*Yawn* Thank you elder, before we go do you think we have time for a bite to eat?", (int)chars.CERYZ, 70);
        introDiag[70] = new Dialogs("*Smack* Always thinking with your stomach", (int)chars.GWYN, 71);
        introDiag[71] = new Dialogs("Glad to see you two haven’t changed. Of course, there’s time for a meal, eat up and then head back to Tolpos. " +
            "I’m sure Ruma is worried about you.", (int)chars.GLENN, 72);

        // Convo 7 - Return to the Village

        // in the forest
        introDiag[72] = new Dialogs("Oh no", (int)chars.CERYZ, 73);
        introDiag[73] = new Dialogs("Cmon we need to hurry", (int)chars.GWYN, 74);

        // in the city
        introDiag[74] = new Dialogs("Come on everyone this way!!", (int)chars.FREDALF, 75);
        introDiag[75] = new Dialogs("Gwyn Ceryz its nice to see that your safe.", (int)chars.FREDALF, 76);
        introDiag[76] = new Dialogs("Whats going on?", (int)chars.CERYZ, 77);
        introDiag[77] = new Dialogs("It’s the Noks, They came out of nowhere demanding the crystal. Ruma and the rest of the town guard stayed behind to buy us time", (int)chars.FREDALF, 78);
        introDiag[78] = new Dialogs("Come on Ceryz! we have to find my mom!", (int)chars.GWYN, 79);
        introDiag[79] = new Dialogs("Don’t be stupid, you’ll be shot", (int)chars.FREDALF, 80);
        introDiag[80] = new Dialogs("We have to do something, Sitti—", (int)chars.GWYN, 81);
        introDiag[81] = new Dialogs("Watch out!! There’s more coming from the side!!", (int)chars.GWYN, 82);
        // Transition to Forest Battle Scene

        // Convo 8 - heading into the village
        // in the forest
        introDiag[82] = new Dialogs("There That’s Dealt with. Head to the city then meet up with your mother, I’ll escort the Civilians away and meet back up with you there", (int)chars.FREDALF, 83);
        // transition to village with Garland Brett and Ruma
        introDiag[83] = new Dialogs("All you had to do was give over the crystal", (int)chars.GARLAND, 84);
        introDiag[84] = new Dialogs("We would never hand it over to the likes of you…", (int)chars.RUMA, 85);
        introDiag[85] = new Dialogs("You’d rather die and risk the lives of your entire village then hand over one measly crystal? ", (int)chars.GARLAND, 86);
        // Enter Gwyn and Ceryz
        introDiag[86] = new Dialogs("So be it ", (int)chars.GARLAND, 87); // Audio CLip of Gunfire
        introDiag[87] = new Dialogs("MOTHER!?!?", (int)chars.GWYN, 88);
        introDiag[88] = new Dialogs("Commander, there appear to be some stragglers, take care of them I’ll be back with the Crystal.", (int)chars.GARLAND, 89);
        //  Enter Fredalf
        introDiag[89] = new Dialogs("You heartless Bastards!", (int)chars.CERYZ, 90);
        introDiag[90] = new Dialogs("You'll Die for that!", (int)chars.FREDALF, 91);

        // Convo 9 - Epilogue
        introDiag[91] = new Dialogs("Ceryz use your healing spell hurry!", (int)chars.GWYN, 92);
        introDiag[92] = new Dialogs("I’m trying but she’s hurt bad!", (int)chars.CERYZ, 93);
        introDiag[93] = new Dialogs("Calm now…children…No healing spell… could save me now…you need to go.. there’s more coming.", (int)chars.RUMA, 94);
        introDiag[94] = new Dialogs("No I wont leave you! We’re getting you out of here!", (int)chars.GWYN, 95);
        introDiag[95] = new Dialogs("I’ll only slow you down…Guard, get them out of here…now.", (int)chars.RUMA, 96);
        introDiag[96] = new Dialogs("Yes elder… Ceryz, Gwyn come on we have to go", (int)chars.FREDALF, 97);
        introDiag[97] = new Dialogs("Gwyn, I know your hurting but there’s more coming and if we don’t go now we’re going to end up dead too *Grabs her arm*", (int)chars.GWYN, 98);
        introDiag[98] = new Dialogs("NO!LET ME GO!!", (int)chars.CERYZ, 99);

      
        p_Ceryz.SetActive(false);
        p_Ruma.SetActive(false);
        p_Gwyn.SetActive(false);
        p_Fredalf.SetActive(false);
        p_GwynAndCeryz.SetActive(false);
        setText();
    }

    void setPortrait(int portraitNum)
    {
        switch (portraitNum)
        {
            case 0:
                p_Ceryz.SetActive(true);
                p_Ruma.SetActive(false);
                p_Gwyn.SetActive(false);
                p_Fredalf.SetActive(false);
                p_GwynAndCeryz.SetActive(false);
                p_Glenn.SetActive(false);
                break;
            case 1:
                p_Ceryz.SetActive(false);
                p_Ruma.SetActive(false);
                p_Gwyn.SetActive(true);
                p_Fredalf.SetActive(false);
                p_GwynAndCeryz.SetActive(false);
                p_Glenn.SetActive(false);
                break;
            case 2:
                p_Ceryz.SetActive(false);
                p_Ruma.SetActive(true);
                p_Gwyn.SetActive(false);
                p_Fredalf.SetActive(false);
                p_GwynAndCeryz.SetActive(false);
                p_Glenn.SetActive(false);
                break;
            case 3:
                p_Ceryz.SetActive(false);
                p_Ruma.SetActive(false);
                p_Gwyn.SetActive(false);
                p_Fredalf.SetActive(true);
                p_GwynAndCeryz.SetActive(false);
                p_Glenn.SetActive(false);
                break;
            case 4:
                p_Ceryz.SetActive(false);
                p_Ruma.SetActive(false);
                p_Gwyn.SetActive(false);
                p_Fredalf.SetActive(false);
                p_GwynAndCeryz.SetActive(true);
                p_Glenn.SetActive(false);
                break;
            case 5:
                p_Ceryz.SetActive(false);
                p_Ruma.SetActive(false);
                p_Gwyn.SetActive(false);
                p_Fredalf.SetActive(false);
                p_GwynAndCeryz.SetActive(true);
                p_Glenn.SetActive(false);
                break;
            case 6:
                p_Ceryz.SetActive(false);
                p_Ruma.SetActive(false);
                p_Gwyn.SetActive(false);
                p_Fredalf.SetActive(false);
                p_GwynAndCeryz.SetActive(false);
                p_Glenn.SetActive(true);
                break;

        };
    }


    // Use to check the Dialogues that have transitions... 
    // All diags with transitions are labeled with a comment
    void CheckDiagForTransition(int diagID)
    {
        switch (diagID)
        {
            // Graduation Speach
            case 7:
                button.SetActive(false);
                StartCoroutine(timeDelay(0, 4.0f));
                break;
            // After Tutorial Battle
            case 19:
                button.SetActive(false);
                StartCoroutine(timeDelay(1, 4.0f));
                break;
                // Forest Before Solise
            case 27:
                button.SetActive(false);
                StartCoroutine(timeDelay(2, 4.0f));
                break;
                // In Solise
            case 32:
                button.SetActive(false);
                StartCoroutine(timeDelay(3, 4.0f));
                break;
                // Directly before the battle for Solise
            case 36:
                button.SetActive(false);
                StartCoroutine(timeDelay(4, 4.0f));
                break;
                // After Battle Solise
            case 45:
                button.SetActive(false);
                StartCoroutine(timeDelay(1, 4.0f));
                break;
                // Return To Ruma
            case 57:
                button.SetActive(false);
                StartCoroutine(timeDelay(1, 4.0f));
                break;
            // Glenn A
            case 68:
                button.SetActive(false);
                StartCoroutine(timeDelay(5, 4.0f));
                break;
            case 73:
                button.SetActive(false);
                StartCoroutine(timeDelay(1, 4.0f));
                break;
            case 75:
                button.SetActive(false);
                StartCoroutine(timeDelay(6, 4.0f));
                break;
            // Tolpos Ambush
            case 83:
                button.SetActive(false);
                StartCoroutine(timeDelay(10, 4.0f));
                break;
            // After the Ambush
            case 84:
                button.SetActive(false);
                StartCoroutine(timeDelay(7, 4.0f));
                break;
            // After Rumas Death
            case 90:
                button.SetActive(false);
                StartCoroutine(timeDelay(10, 4.0f));
                break;
            
            case 98:
                button.SetActive(false);
                StartCoroutine(timeDelay(1, 4.0f));
                break;

            default:
                break;

        };
    }

    public void FadeOut()
    {
        animator.SetTrigger("FadeOuttrigger");
    }

    public IEnumerator fade(float time)
    {
        FadeOut();
        yield return new WaitForSeconds(time);
    }

    IEnumerator timeDelay(int sceneID, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        StartCoroutine(fade(1.0f));
        yield return new WaitForSeconds(1.0f);
        switch (sceneID)
        {
            // Add additional Scenes for transitions here as another case
            case 0:
                scenetransitions.LoadTutorialScene();
                break;
            case 1:
                SceneManager.LoadScene("SampleScene");
                break;
            case 2:
                SceneManager.LoadScene("F_BurningVillage2");
                break;
            case 3:
                SceneManager.LoadScene("F_BurningVillage3");
                break;
            case 4:
                scenetransitions.LoadSoliceBattleScene();
                break;
            case 5:
                SceneManager.LoadScene("F_TalkingToGlennB");
                break;
            case 6:
                SceneManager.LoadScene("F_Fredalf");
                break;
            case 7:
                SceneManager.LoadScene("F_RumasDeath");
                break;
            case 10:
                scenetransitions.LoadBossBattle();
                break;

        };
    }

    public void setText()
    {

        setPortrait(introDiag[nextDialog].speakingCharID);
        speachText.text = introDiag[nextDialog].textDisplayed; // Sets the text to the right Dialogue

        nextDialog = introDiag[nextDialog].nextDialogID;
        CheckDiagForTransition(introDiag[nextDialog].nextDialogID);
    }
}