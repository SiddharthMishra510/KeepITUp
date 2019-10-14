using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{

    public GameObject UFO;
    public GameObject CountdownUI;
    public GameObject GameManager;
    public GameObject TextHolder;
    //public GameObject Score;
    //public GameObject FuelSlider;

    public  float timeLeft =3.0f;

    void Start()
    {
        TextMeshProUGUI Text = TextHolder.GetComponent<TextMeshProUGUI>();
        //Score.SetActive(false);
        //FuelSider.SetActive(false);
        //timeLeft = 3.0f;
        //Time.timeScale = 0f;
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        TextHolder.GetComponent<TextMeshProUGUI>().text = (timeLeft).ToString("0");
        if (timeLeft < 1)
        {
            //Debug.Log("game starts");
            CountdownUI.SetActive(false);
            GameManager.GetComponent<ScoreController>().enabled = true;
            //UFO.GetComponent<Accelerometer>().enabled = true;
        }
    }

}