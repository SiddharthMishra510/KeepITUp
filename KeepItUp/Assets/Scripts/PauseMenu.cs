using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool isPaused = false;
    public GameObject PauseMenuUI;
    public GameObject joystick;
    public GameManager GameManager;

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Menu()
    {
        //Debug.Log("Menu");
       // gameManager.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void JoystickLeft()
    {
        PlayerPrefs.SetInt("JoystickLeft", 1);
        RectTransform rt = joystick.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector3(-400, -115, 0); //Joystick position on the left
    }

    public void JoystickRight()
    {
        PlayerPrefs.SetInt("JoystickLeft", 0);
        RectTransform rt = joystick.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector3 (400, -115, 0); //Joystick position on the right
    }

}
