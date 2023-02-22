using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuHandler : MonoBehaviour
{
    public static MenuHandler menuHandler;


    public string PreviousName;
    public string CurrentName;
    public int CurrentHighScore;
    public int PreviousHighscore;
    private void Awake()
    {

        // start of new code
        if (menuHandler != null)
        {
            Destroy(gameObject);
            return;
        }
        LoadScore();
        // end of new cod
        menuHandler = this;
        DontDestroyOnLoad(gameObject);

        //// start of new code
        //if (Instance != null)
        //{
        //    Destroy(gameObject);
        //    return;
        //}
        //LoadColor();
        //// end of new cod
        //Instance = this;
        //DontDestroyOnLoad(gameObject);

    }

    [System.Serializable]
    class SaveData
    {
        public int HighScore;
        public string Name;
    }

    public void SaveScore()
    {
        if (CurrentHighScore > PreviousHighscore)
        {

            SaveData data = new SaveData();
            data.Name = CurrentName;
            data.HighScore = CurrentHighScore;

            string json = JsonUtility.ToJson(data);

            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            PreviousHighscore = data.HighScore;
            PreviousName = data.Name;
            //scoreText.text = data.Name + "  :  " + data.HighScore;
    

        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
