using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Count_Score : MonoBehaviour {

    public Text Scoreboard;
    public GameObject ball;

    private int PlayerScore = 0;
    private int EnemyScore = 0;

	
	void Start () {

        ball = GameObject.Find("Ball");
	}
	
	
	void Update () {
        
        if(ball.transform.position.x >= 16f)
        {
            PlayerScore++;
        }
        if(ball.transform.position.x <= -16f)
        {
            EnemyScore++;
        }

        Scoreboard.text = PlayerScore.ToString() + " - " + EnemyScore.ToString();

        // console
        print(PlayerScore + " , " + EnemyScore);
	}
}
