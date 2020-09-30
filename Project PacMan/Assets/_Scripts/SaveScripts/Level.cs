using UnityEngine;
using System.IO; // Required fro reading/writing to files.
using System.Collections.Generic; // Used for Lists



/// <summary>
/// The different types of powerups a player can have.
/// </summary>
public enum perks
{
    
}

public class SaveData
{

    public const string DEFAULT_LEVEL = "level1";
    private const int DEFAULT_MONEY = 0;
    private const int DEFAULT_HEALTH = 0;
    private const int DEFAULT_ARMOR = 100;
    private const int DEFAULT_MANA = 100;
    private const int DEFAULT_LIVES = 1;
    

    public int money = DEFAULT_MONEY;
    public int health = DEFAULT_HEALTH;
    public string lastLevel = DEFAULT_LEVEL;
    public List<perks> perks = new List<perks>();
    public int lives = DEFAULT_LIVES;

    private const bool DEBUG_ON = true;
    
    public void WriteToFile(string filePath)
    {
        string json = JsonUtility.ToJson(this, true);

        // Write that JSON string to the specified file.
        File.WriteAllText(filePath, json);

        if (DEBUG_ON)
            Debug.LogFormat("WriteToFile({0}) -- data:\n{1}", filePath, json);
    }
    public static SaveData ReadFromFile(string filePath)
    {
		// If the file doesn't exist default object.
		if (!File.Exists(filePath))
		{
			Debug.LogErrorFormat("ReadFromFile({0}) -- file not found, returning new object", filePath);
			return new SaveData();
    }
		else
		{
			// If the file does exist then read file to a string.
			string contents = File.ReadAllText(filePath); 
			
			if (DEBUG_ON)
                Debug.LogFormat("ReadFromFile({0})\ncontents:\n{1}", filePath, contents);
 
			// If the file is empty return a new SaveData object.
			if (string.IsNullOrEmpty(contents))
			{
				Debug.LogErrorFormat("File: '{0}' is empty. Returning default SaveData");
				return new SaveData();
			}
 
			// Use JsonUtility to convert the string to a new SaveData object.
			return JsonUtility.FromJson<SaveData>(contents);
		}
    }
    public bool IsDefault()
    {
        return (
            money == DEFAULT_MONEY &&
            health == DEFAULT_HEALTH &&
            lives == DEFAULT_LIVES &&
            lastLevel == DEFAULT_LEVEL &&
            perks.Count == 0);
    }   
    
    public override string ToString()
    {
        string[] perksStrings = new string[perks.Count];
        for (int i = 0; i < perks.Count; i++)
        {
            perksStrings[i] = perks[i].ToString();
        }

        return string.Format(
            "money: {0}\nhealth: {1}\nlives: {2}\nperks: {3}\nlastLevel: {4}",
            money,
            health,
            lives,
            "[" + string.Join(",", perksStrings) + "]",
            lastLevel
            );
    }
}


