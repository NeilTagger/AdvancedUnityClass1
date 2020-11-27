using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Ball")]
    public GameObject ball;

    [Header("Player 1")]
    public GameObject Player1Paddle;
    public GameObject Player1Goal;

    [Header("Player 2")]
    public GameObject Player2Paddle;
    public GameObject Player2Goal;

    [Header("ScoreUI")]
    public TextMeshProUGUI Player1Text;
    public TextMeshProUGUI Player2Text;

    GameScore gameScore;

    public void Player1Scored()
    {
        gameScore.Player1Score++;
        Player1Text.text = gameScore.Player1Score.ToString();
        ResetPosition();
        WriteScoreToJSon();
    }

    public void Player2Scored()
    {
        gameScore.Player2Score++;
        Player2Text.text = gameScore.Player2Score.ToString();
        ResetPosition();
        WriteScoreToJSon();
    }

    private void ResetPosition()
    {
        ball.GetComponent<Ball>().Reset();
        Player1Paddle.GetComponent<Paddle>().Reset();
        Player2Paddle.GetComponent<Paddle>().Reset();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameScore = new GameScore();
        gameScore.Player1Score = 0;
        gameScore.Player2Score = 0;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WriteScoreToJSon()
    {
        string json = JsonUtility.ToJson(gameScore);

        using (StreamWriter file = File.CreateText(Directory.GetCurrentDirectory() + "\\Save.txt"))
        {
            file.Write(json);
        }
    }
}
