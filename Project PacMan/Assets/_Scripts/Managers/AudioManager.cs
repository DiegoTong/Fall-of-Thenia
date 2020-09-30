using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; //Only needed for the AudioMixer.  Not any other sound feature including Play, Mute, Audio Clip, and Audio Source.

public class AudioManager : MonoBehaviour
{
    public AudioSource mSource; //Music Source
    public AudioSource sSource; // SFX Source

    [Header("Master Volume: 20f is Max Volume, -80f if Mute.")]
    public float Master_Volume = 0f;
    public enum AudioChoiceSFX
    {
        FredalfBAttack,
        GwynBAttack,
        CeryzBAttack,
        EnemyAttack,
        PlayerAndEnemyHit
        //Adding More based on current game states requirements and SFX additions
    }

    [Header("Music")]
    public AudioClip[] Location_Music;
    /*
    0 = Main Menu Theme
    1 = Forest Theme
    2 = 
    3 = 
    4 = 
    5 = 
    6 = 
    7 = 
    */
    [Space(10)]
    public AudioClip[] Boss_Music;
    /*
    0 = First Boss Theme
    1 = Second Boss Theme
    2 = Third Boss Theme
    */

    [Space(10)]
    public AudioClip[] Basic_Combat_Music;
    /*
    0 = Basic Combat Music
    1 = High Intensity Combat Music(?)
    2 = Ominous Tension Combat Music(?)
    */
    [Space(10)]
    [Header("Sound Effects")]
    public AudioClip[] Player_Sound_Effects;
    /*
    0 = Gwyn Basic Attack
    1 = Fredalf Basic Attack
    3 = Ceryz Basic Attack
    4 = 
    5 =
    6 = 
    7 = 
    8 = 
    9 =
    15 = Player Hit           
     */

    [Space(10)]
    public AudioClip[] Enemy_Sound_Effects;
    /*
    0 = Arrow Basic Attack
    1 = Magic Basic Attack
    2 = Sword Basic Attack
    */
    [Space(10)]
    public AudioClip[] Misc_Sound_Effects;
    /*
    0 = Menu Button Navigation
    1 = 

    */
    [Space(10)]
    [Header("Audio Mixer")]
    public AudioMixer mixer;


    [Header("Volume and Pitch")]

    //To use Master Volume
    //float newVolume = GUILayout.HorizontalSlider (am.masterVolumeBGM , 0.0, 2.0);
    // if(newVolume != am.masterVolumeBGM ) { //The volume have changed
    //am.masterVolumeBGM = newVolume;
    //Call a function to update audio's volume for BGM

    public static AudioManager instance = null;
    public static AudioManager Instance
    {
        get { return instance; }
    }




    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    public void CombatBasicAttack(AudioChoiceSFX Player)
    {

        switch (Player)
        {
            case (AudioChoiceSFX.GwynBAttack):
                sSource.PlayOneShot(Player_Sound_Effects[0]);
                break;
            case (AudioChoiceSFX.FredalfBAttack):
                sSource.PlayOneShot(Player_Sound_Effects[1]);
                break;
            case (AudioChoiceSFX.CeryzBAttack):
                sSource.PlayOneShot(Player_Sound_Effects[2]);
                break;
        }
    }


    private void Update()
    {
        ChangeVolume("Music");
        ChangeVolume("SFX");
    }

    public void PlayMusic(int number, string Type) // 0 through to 10(?)  0 will be the main theme track while 10 will be the final location
    {
        mSource.loop = true;

        if (Type == "Location")
        {
            mSource.Stop();
            mSource.clip = Location_Music[number];
            mSource.Play();
        }
        else if (Type == "Combat")
        {
            mSource.Stop();
            mSource.clip = Basic_Combat_Music[number];
            mSource.Play();
        }
        else if (Type == "Boss")
        {
            mSource.Stop();
            mSource.clip = Boss_Music[number];
            mSource.Play();
        }
        else
        {
            Debug.Log("Invalid Audio Type.  Please use either 'Location', 'Combat' or 'Boss'.");
        }


    }

    public void TempPlayMusic(AudioClip clip, bool loop, bool play)
    {
        mSource.clip = clip;
        mSource.loop = loop;

        if (play == true)
        {
            mSource.Play();
        }
        else
        {
            mSource.Play();
        }

    }

    public void MuteSound(string AudioChoice)
    {
        if (AudioChoice == "Music")
        {
            AudioManager.instance.mixer.SetFloat("MusicParam", 0f);
        }
        else if (AudioChoice == "SFX")
        {
            AudioManager.instance.mixer.SetFloat("SFXParam", 0f);
        }
        else
        {
            Debug.Log("Invalid Audio Type.  Please use either 'Music' or 'SFX'.");
        }
    }

    public void ChangeVolume(string AudioType)
    {
        if (AudioType == "Music")
        {
            AudioManager.instance.mixer.SetFloat("MusicParam", Master_Volume);
        }
        else if (AudioType == "SFX")
        {
            AudioManager.instance.mixer.SetFloat("SFXParam", Master_Volume);
        }
        else
        {
            Debug.Log("Invalid Audio Type.  Please use either 'Music' or 'SFX'.");
        }
    }

    public void PlayGeneralSFX(AudioClip clip)
    {
        sSource.pitch = Random.Range(0.80f, 1.20f);
        sSource.PlayOneShot(clip);
    }



}
