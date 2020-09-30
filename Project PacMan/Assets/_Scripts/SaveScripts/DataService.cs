using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;// Required fro reading/writing to files.
using System.Collections.Generic; // Used for Lists

namespace EX1
{    
    public class DataService : MonoBehaviour
    {
        private static DataService _instance = null;
        public static DataService Instance
        {
            get
            {
                // If the instance of this class doesn't exist
                if (_instance == null)
                {
                    // Check the scene for a Game Object with this class
                    _instance = FindObjectOfType<DataService>();

                    // If none is found in the scene then create a new Game Object
                    // and add this class to it.
                    if (_instance == null)
                    {
                        GameObject go = new GameObject(typeof(DataService).ToString());
                        _instance = go.AddComponent<DataService>();
                    }
                }

                return _instance;
            }
        }

        public PlayerInfo prefs { get; private set; }
        private void Awake()
        {
            if (Instance != this)
            {
                Destroy(this);
            }
            else
            {
                DontDestroyOnLoad(gameObject);

                prefs = new PlayerInfo();
                prefs.RestorePreferences();
                // In Unity 5.4 OnLevelWasLoaded has been deprecated and the action
                // now occurs through this callback.
#if UNITY_5_4_OR_NEWER
                SceneManager.sceneLoaded += OnLevelFinishedLoading;
#endif
            }
        }

        void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
        {
            OnLevelFinishedLoading(); // test
        }

        void OnLevelFinishedLoading()
        {
            prefs.RestorePreferences();

            // If we haven't loaded any SaveData yet then load it. 
            // This also sets the currentProfile number.
            if (SaveData == null)
                LoadSaveData();

            // Set the player's progress if this is not the main menu scene.
            // In my project this is scene 0 and scene 1
            Scene activeScene = SceneManager.GetActiveScene();
            if (activeScene.buildIndex > 1)
            {
                SaveData.lastLevel = activeScene.path.Replace("Assets/", "").Replace(".unity", "");
            }

            // Write the save data to file, saving the player's stats and progress.
            WriteSaveData();
        }        
        // The currently loaded Save Data.       
        public SaveData SaveData { get; private set; }
       
        // Use this to prevent reloading the data when a new scene loads.       
        bool isDataLoaded = false;

       
        // Store the currently loaded profile number here.    
        public int currentlyLoadedProfileNumber { get; private set; }

        
        //The maximum number of profiles we'll allow our users to have.       
        public const int MAX_NUMBER_OF_PROFILES = 3;        
    
        public void LoadSaveData(int profileNumber = 0)
        {
            if (isDataLoaded && profileNumber == currentlyLoadedProfileNumber)
                return;

            // Automatically load the first available profile.
            if (profileNumber <= 0)
            {
                // We iterate through the possible profile numbers in case one with a lower number
                // no longer exists.
                for (int i = 1; i <= MAX_NUMBER_OF_PROFILES; i++)
                {
                    if (File.Exists(GetSaveDataFilePath(i)))
                    {
                        // Once the file is found, load it from the calculated file name.
                        SaveData = SaveData.ReadFromFile(GetSaveDataFilePath(i));
                        // And set the current profile number for later use when we save.
                        currentlyLoadedProfileNumber = i;
                        break;
                    }
                }
            }
            else
            {
                // If the profileNumber parameter is supplied then we'll look to see if that exists.
                if (File.Exists(GetSaveDataFilePath(profileNumber)))
                {
                    // If the file exists then load the SaveData from the calculated file name.
                    SaveData = SaveData.ReadFromFile(GetSaveDataFilePath(profileNumber));

                }
                else
                {
                    // Otherwise just return a new
                    SaveData = new SaveData();
                }

                // And set the current profile number for later use when we save.
                currentlyLoadedProfileNumber = profileNumber;
            }
        }

       
        // The base name of our save data files.     
        private const string SAVE_DATA_FILE_NAME_BASE = "savedata";
      
        //The extension of our save data files.       
        private const string SAVE_DATA_FILE_EXTENSION = ".txt";

     
        // The directory our save data files will be stored in.        
        private string SAVE_DATA_DIRECTORY { get { return Application.dataPath + "/saves/"; } }        
        
        public string GetSaveDataFilePath(int profileNumber)
        {
            // If the profile number is less than 1 then throw an exception.
            if (profileNumber < 1)
                throw new System.ArgumentException("profileNumber must be greater than 1. Was: " + profileNumber);

            // Ensure that the directory exists.
            if (!Directory.Exists(SAVE_DATA_DIRECTORY))
                Directory.CreateDirectory(SAVE_DATA_DIRECTORY);

            // Construct the string representation of the directory + file name.
            return SAVE_DATA_DIRECTORY + SAVE_DATA_FILE_NAME_BASE + profileNumber.ToString() + SAVE_DATA_FILE_EXTENSION;
        }
        
        public void WriteSaveData()
        {
           
            if (currentlyLoadedProfileNumber <= 0)
            {
                for (int i = 1; i <= MAX_NUMBER_OF_PROFILES; i++)
                {
                    if (!File.Exists(GetSaveDataFilePath(i)))
                    {
                        currentlyLoadedProfileNumber = i;
                        break;
                    }
                }
            }
           
            if (currentlyLoadedProfileNumber <= 0)
            {
                throw new System.Exception("Cannot WriteSaveData. No available profiles and currentlyLoadedProfile = 0");
            }
            else
            {               
                if (SaveData == null)
                    SaveData = new SaveData();

                // Finally save it to th file using the constructed path + file name
                SaveData.WriteToFile(GetSaveDataFilePath(currentlyLoadedProfileNumber));
            }
        }
    }
}


