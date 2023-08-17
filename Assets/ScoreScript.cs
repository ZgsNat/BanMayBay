using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public TMP_Text ScoreText;
    int Score = 0;
    public static ScoreScript instance;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = "Score: " + Score.ToString();
    }
    private void Awake()
    {
        instance = this;
    }
    public void AddPoint()
    {
        Score += 1;
        ScoreText.text = "Score: " + Score.ToString();
    }
    // Update is called once per frame
    public InsideMenu insideMenu;
    void Update()
    {
        if(Score == 16)
        {
            insideMenu.SetGame();
            //Time.timeScale = 0;
            ResetPoint();
        }
    }
    public void ResetPoint()
    {
        Score = 0;
    }
}
