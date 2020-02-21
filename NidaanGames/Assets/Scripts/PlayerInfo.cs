using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {

    UserBehavior user = new UserBehavior();
    public int authenticationNumber;
    public bool male;
    public int age;
    public bool headphones;
    public int volume;
    public List<int> testResults;
    public int levelNumber;
    private string FilePath;

    private void Start()
    {
        FilePath = Path.Combine(Application.persistentDataPath, "PlayerInfo.json");
    }
  

    public void GenderMale(bool male)
    {
            user.gender = male;
            SaveData();
    }
    public void AgeCatagory(int age)
    {
        user.age = age;
        SaveData();
    }
    public void SaveData()
    {
        string jsonString = JsonUtility.ToJson(user);
        File.WriteAllText(FilePath, jsonString);
    }

    public void RetrievData()
    {
        string jsonString = File.ReadAllText(FilePath);
        JsonUtility.FromJsonOverwrite(jsonString, user);
        Debug.Log(FilePath);
        male = user.gender;
    }
}
