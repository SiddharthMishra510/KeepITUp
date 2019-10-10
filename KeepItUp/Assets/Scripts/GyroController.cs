using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GyroController : MonoBehaviour
{
    [SerializeField] private float JumpForce = 10f;                          // Amount of force added when the player jumps		
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float maxSpeed = 10f;
    [SerializeField]
    private float upSpeed = 2f;
    public Slider slider;
    private bool isJumping = false;

    private Rigidbody rb;

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
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Input.gyro.enabled = true;
        InvokeRepeating("jump", 0f, 0.1f);
    }

    void Update()
    {
        Quaternion deviceRotation = DeviceRotation.Get();

        transform.rotation = deviceRotation;
        transform.rotation *= Quaternion.Euler(-90f, 0f, 0f);

        //Vector3 direction = rotation * Vector3.forward;

        if (rb.velocity.x <= maxSpeed && rb.velocity.z <= maxSpeed)
            rb.AddForce(new Vector3(transform.up.x, 0, transform.up.z) * speed, ForceMode.Impulse);
        else rb.velocity = Vector3.zero;

    }
}
