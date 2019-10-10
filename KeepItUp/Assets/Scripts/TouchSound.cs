using UnityEngine;

public class TouchSound : MonoBehaviour
{

    void Update()
    {
         if(Input.touchCount > 0)
        {
            for(int i = 0; i<=Input.touchCount; i++)
                FindObjectOfType<AudioManager>().Play("Touch");
        }
    }

}
