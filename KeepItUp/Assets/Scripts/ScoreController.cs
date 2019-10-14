using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{

    public Text score;
    float currentscore = 0;
    

    void Start()
    {
        //highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        //Debug.Log("Score");
        score.text = "0";
    }

    void Update()
    {
        currentscore = float.Parse(score.text);
        currentscore += Time.deltaTime * 10;
        score.text = System.Math.Ceiling(currentscore).ToString();

        if(currentscore > PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", currentscore);
            
            Debug.Log(PlayerPrefs.GetFloat("HighScore", 0));
        }
    }

}
