using UnityEngine;
using UnityEngine.UI;

public class Accelerometer : MonoBehaviour
{

    // Move object using accelerometer
    public float speed = 10.0f;
    [SerializeField] private float JumpForce = 10f;                          // Amount of force added when the player jumps	
    private float jumpCount = 0;

    public Slider slider;

    private bool isJumping = false;
    //public bool canJump = true; //to be disabled when EndGame

    [SerializeField] private Quaternion baseRotation = new Quaternion(0, 0, 1, 0);
    private Rigidbody rb;

    void jump()
    {
        //if (!isJumping && jumpCount == 0 && canJump)
        if (!isJumping)
        {
            isJumping = true;
            jumpCount++;
            rb.AddForce(0f, JumpForce, 0f, ForceMode.Impulse);
            //FindObjectOfType<AudioManager>().Play("Jump");                  // I don't like the sound
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("ground")) { isJumping = false; }
        // if(collision.gameObject.CompareTag("cow"))
        //{
        //     slider.value += 5;
        //}
        for (int i = 0; i < 12; i++)
            if (collision.gameObject.CompareTag(i.ToString()))
            {
              //  FindObjectOfType<AudioManager>().Play("Cow");
                //Debug.Log("increased fuel");
                slider.value += 5;
            }
    }

    /*
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            jumpCount = 1;
            isJumping = true;
        }
    }
    */

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Input.gyro.enabled = true;
        InvokeRepeating("jump", 0f, 0.1f);
    }

    void Update()
    {
          Quaternion deviceRotation = DeviceRotation.Get();
      //   Gyroscope gyro= Gyroscope.
           transform.rotation = deviceRotation;
           //Debug.Log(transform.rotation);
           transform.rotation *= Quaternion.Euler(-90f, 0f, 0f);

           Vector3 dir = Vector3.zero;
        Debug.Log(Input.acceleration);

           // we assume that device is held parallel to the ground
           // and Home button is in the right hand

           // remap device acceleration axis to game coordinates:
           //  1) XY plane of the device is mapped onto XZ plane
           //  2) rotated 90 degrees around Y axis

           dir.z = Input.acceleration.y;
           dir.x = Input.acceleration.x;

         //Debug.Log(dir);

           // clamp acceleration vector to unit sphere
           if (dir.sqrMagnitude > 1)
               dir.Normalize();

           // Make it move 10 meters per second instead of 10 meters per frame...
           dir *= Time.deltaTime;

           // Move object
           //rb.AddForce(dir * speed);
           transform.Translate(dir * speed); 
          // transform.Rotate(new Vector3(90,0,0)); 
       
    }

}