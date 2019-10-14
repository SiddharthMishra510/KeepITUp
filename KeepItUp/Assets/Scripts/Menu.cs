using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{

    public GameObject MuteButton;
    public Sprite musicOnSprite;
    public Sprite musicOffSprite;
    public AudioClip SidTheme;
    public AudioClip SeraMejor;
    //public AudioSource[] audiosources;
    public TMP_Text text;
    
    public void Play()
    {
        FindObjectOfType<AudioManager>().Play("Touch");
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void MuteOrUnmute()
    {

        FindObjectOfType<AudioManager>().ToggleSound();
        UpdateIconandVolume();
    }

    private void UpdateIconandVolume()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 1)
        {
            Debug.Log("Muted");
            AudioListener.volume = 0;
            MuteButton.GetComponent<Image>().sprite = musicOffSprite;
        }
        else
        {
            Debug.Log("Unmuted");
            AudioListener.volume = 1;
            MuteButton.GetComponent<Image>().sprite = musicOnSprite;
        }
    }

    public void Tutorial()
    {
        SceneManager.LoadScene(2);
    }

    public void MusicSwitch()
    {
        foreach (AudioSource audiosource in FindObjectsOfType<AudioSource>())
        {
            //Debug.Log(audiosource.clip.name);

            if (audiosource.clip.name == "SidTheme")
            {
                //Debug.Log("SidTheme found");
                audiosource.clip = SeraMejor;
                audiosource.Play();
                text.text = "Now Playing: Será Mejor - Muchachito Bombo Infierno";
            }

            else if (audiosource.clip.name == "SeraMejor")
            {
                //Debug.Log("SeraMejor found");
                audiosource.clip = SidTheme;
                audiosource.Play();
                text.text = "Now Playing: Keep IT Up Theme - Siddharth Mishra";
            }
        }
    }

}