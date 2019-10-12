using UnityEngine;
using UnityEngine.UI;

public class BadCowBehaviour : MonoBehaviour
{

    private Vector3 initialposition;
    //public float rotation = 50f;
    public bool toMove = true;
    public bool goUp = true;
    Rigidbody rb;
    Vector3 positiveVelocity = new Vector3(0, 1f, 0);
    Vector3 negativeVelocity = new Vector3(0, -1f, 0);
    private float minHeight;
    private float maxHeight;
    //public Text score;
    public Slider slider;

    void Start()
    {
        initialposition = transform.position;
        minHeight = transform.position.y;
        maxHeight = (float)(12.67 + 1); // TODO Change with floor position;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //rotate the cow
        //transform.Rotate(0, rotation * Time.deltaTime, 0);
        if (toMove)
            if (goUp)
                cowGoUp();
            else
                cowGoDown();
    }

    void cowGoUp()
    {
        rb.velocity = positiveVelocity;
        if (transform.position.y >= maxHeight)
            goUp = false;
    }

    void cowGoDown()
    {
        rb.velocity = negativeVelocity;
        if (transform.position.y <= initialposition.y)
            ResetCow();
    }

    public void ResetCow()
    {
        goUp = true;
        rb.velocity = Vector3.zero;
        transform.position = initialposition;
        toMove = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Ill cow Collision");
        goUp = false;
        //float currentscore = float.Parse(score.text);  //Changing the score
        //currentscore -= 100f;
        //if (currentscore < 0)
        //   currentscore = 0f;
        //Debug.Log(currentscore);
        //score.text = currentscore.ToString();
        slider.value -= 40; //For every ill cow touched, we decrease fuel
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);

        transform.position = initialposition;
    }
}
