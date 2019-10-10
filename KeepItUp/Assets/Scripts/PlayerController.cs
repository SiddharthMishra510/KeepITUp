using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float JumpForce = 10f;                          // Amount of force added when the player jumps		
    private Rigidbody rb;
    private Vector3 Vel = Vector3.zero;
    private float distanceGround;
    private float actualDistance;
    private bool isJumping = false;
    public float moveSpeed = 3f;
    public Slider slider;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        distanceGround = GetComponent<Collider>().bounds.extents.y;
        Vector3 toObjectVector = transform.position - Camera.main.transform.position;
        Vector3 linearDistanceVector = Vector3.Project(toObjectVector, Camera.main.transform.forward);
        actualDistance = linearDistanceVector.magnitude;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("jump", 0f, 0.1f);
    }

    void jump()
    {
        if (!isJumping)
        {
            isJumping = true;
            rb.AddForce(0f, JumpForce, 0f, ForceMode.Impulse);
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
                //Debug.Log("increased fuel");
                slider.value += 5;
            }
        if(collision.gameObject.CompareTag("badcow"))
        {
            slider.value -= 5;
        }
    }

    public void Move(Vector3 mousePosition)
    {
        mousePosition.z = actualDistance;
        Vector3 MouseDirection = Camera.main.ScreenToWorldPoint(mousePosition) - transform.position;
        //rb.AddForce(Camera.main.ScreenToWorldPoint(mousePosition).x - transform.position.x, transform.position.y, Camera.main.ScreenToWorldPoint(mousePosition).z - transform.position.z);
        rb.velocity = new Vector3(MouseDirection.x * moveSpeed, rb.velocity.y, MouseDirection.z * moveSpeed);
        //Vel = new Vector3((Camera.main.ScreenToWorldPoint(mousePosition).x - transform.position.x), rb.velocity.y, (Camera.main.ScreenToWorldPoint(mousePosition).z - transform.position.z)).normalized;
        //rb.velocity = new Vector3(Vel.x * moveSpeed * Time.smoothDeltaTime, rb.velocity.y, Vel.z * moveSpeed * Time.smoothDeltaTime);
    }
}