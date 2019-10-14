using TMPro;
using UnityEngine;

public class HighScoreUpdater : MonoBehaviour
{

    public GameObject TextHolder;

    private void Start()
    {
        TextMeshProUGUI HighScoreText = TextHolder.GetComponent<TextMeshProUGUI>();
        HighScoreText.text = ((int)PlayerPrefs.GetFloat("HighScore", 0)).ToString();
    }

    /*
    void Update()
    {
        HighScoreText.text = PlayerPrefs.GetFloat("HighScore", 0).ToString();
    }
    */

}
