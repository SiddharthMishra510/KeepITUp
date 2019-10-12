//INCOMPLETE SCRIPT

using UnityEngine;
using UnityEngine.UI;

public class TouchMovement : MonoBehaviour
{

    [SerializeField] private float JumpForce = 2f;                          // Amount of force added when the player jumps	
    private float jumpCount = 0;
    public float speed = 10f;
    Vector3 dir;
    Touch t;
    private Rigidbody rb;
    public Slider slider;
    private bool isJumping = false;

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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("jump", 0f, 0.1f);
        dir = Vector3.zero;
    }

    void Update()
    {

        foreach (Touch touch in Input.touches)
        {
            Vector3 dir = Vector3.zero;
            dir.z = touch.position.y;
            dir.x = touch.position.x;

            Debug.Log("touch.position.y= " + touch.position.y);
            Debug.Log("touch.position.x= " + touch.position.x);
            if (dir.sqrMagnitude > 1)
                dir.Normalize();
            dir *= Time.deltaTime;
            transform.Translate(dir * speed, Space.Self);

        }
    }

}
