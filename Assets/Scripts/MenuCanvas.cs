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

public class MenuCanvas : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public Button startButton;
    public Button quitButton;
    public TMP_InputField input;


    



    // Start is called before the first frame update
    void Start()
    {


        scoreText.text = MenuHandler.menuHandler.PreviousName + " : " + MenuHandler.menuHandler.PreviousHighscore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNew()
    {
        MenuHandler.menuHandler.CurrentName = input.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
