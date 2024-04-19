using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public Text highScore;
    public InputField playerName;
    // Start is called before the first frame update

    void Start()
    {
        
        playerName.onValueChanged.AddListener(delegate { UpdatePlayerName(playerName.text); } );
        playerName.text = DataManager.Instance.pName;
        highScore.text="Best Score : "+ DataManager.Instance.highScore.ToString();
    }

    public void UpdatePlayerName(string Name)
    {
        DataManager.Instance.pName = Name;
    }
    // Update is called once per frame

    public void StartNew()
    {
        DataManager.Instance.SaveProgress();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        DataManager.Instance.SaveProgress();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
