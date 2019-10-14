using UnityEngine;
using UnityEngine.UI;

public class JoystickMovement : MonoBehaviour
{

    public float speed = 10.0f;
    public float JumpForce = 10f;                          // Amount of force added when the player jumps	

    public Joystick joystick;
    private float xMovement;
    private float zMovement;

    public Slider slider;
    private Rigidbody rb;

    private float jumpCount = 0;
    private bool isJumping = false;                                          // public bool canJump = true; //to be disabled when EndGame

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
            if (collision.gameObject.CompareTag(i.ToString())) //For every normal cow touched, we add some fuel
            {
                //  FindObjectOfType<AudioManager>().Play("Cow");
                //Debug.Log("increased fuel");
                slider.value += 13;
            }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("jump", 0f, 0.1f);
    }


    private void Update()
    {
        xMovement = joystick.Horizontal;
        zMovement = joystick.Vertical;
        

    }

    private void FixedUpdate()
    {
        transform.Translate(xMovement * Time.deltaTime * speed, 0f, zMovement * Time.deltaTime * speed, Space.Self);
    }
}
