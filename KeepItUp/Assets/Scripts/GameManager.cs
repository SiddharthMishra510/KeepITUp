using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

	bool gameHasEnded = false;

    public GameObject UFO;
    public GameObject Fill;
    public Slider slider;
    public float restartDelay = 1f;
    public float decreaseValue = 3f;
    public float minY;
    Rigidbody rbUFO;

    void Start()
    {
        rbUFO = UFO.GetComponent<Rigidbody>();
        //  Debug.Log("fuel is" + slider.value);
        InvokeRepeating("DecreaseFuel", 3, 2);
    }

    private void FixedUpdate()
    {
        //Debug.Log(slider.value);
        if (rbUFO.transform.position.y <= minY)
        {
            EndGame();
        }
    }

    private void Update()
    {
        //Debug.Log("fuel is" + slider.value);
        if (slider.value == 0)
        {
         //   UFO.GetComponent<Accelerometer>().canJump = false;
            Invoke("EndGame", 2f);
        }
    }

    void DecreaseFuel()
    {
        slider.value -= decreaseValue;

        if (slider.value < 5f)
            slider.value = 0;

        if(slider.value >= 60)
        {
            Fill.GetComponent<Image>().color = Color.green;
        }
        else if (slider.value >= 35)
        {
            Fill.GetComponent<Image>().color = Color.yellow;
        }
        else
        {
            Fill.GetComponent<Image>().color = Color.red;
        }
    }

    public void EndGame ()
	{
		if (gameHasEnded == false)
		{
            try
            {
                FindObjectOfType<AudioManager>().Play("Lose");
            }
            catch(Exception e)
            {
               
            }

            gameHasEnded = true;
			Invoke("Restart", restartDelay);
		}
	}

	void Restart ()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

}
