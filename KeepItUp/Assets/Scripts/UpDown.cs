using UnityEngine;

public class UpDown : MonoBehaviour
{
    public GameObject floor;
    GameObject firstObject, secondObject, thirdObject;
    Rigidbody rbf, rbs, rbt;
    public float upVel = 3f;
    private float belowVal;
    int first, second, third;
    private string flag;
    //string firstPrevTag, secondPrevTag, thirdPrevTag, firstNowTag, secondNowTag, thirdNowTag;
    
    void Start()
    {
        flag = "up";
        belowVal = GameObject.FindGameObjectWithTag("0").transform.position.y;
        randomGenerator();
    }

    int RandomRangeExcept(int min, int max, int except)
    {
        int number;
        do { number = Random.Range(min, max); } while (number == except);
        return number;
    }

    int RandomRangeExcept(int min, int max, int except1, int except2)
    {
        int number;
        do
        { number = Random.Range(min, max); } while (number == except1 || number == except2);
        return number;
    }

    public void randomGenerator()
    {
        first = Random.Range(0, 10);
        //Debug.Log(first);
        second = RandomRangeExcept(0, 10, first);
        //Debug.Log(second);
        third = RandomRangeExcept(0, 10, first, second);
        //Debug.Log(third);
        sendUp(first, second, third);
    }

    public void sendUp(int first, int second, int third)
    {
        rbf = GameObject.FindGameObjectWithTag(first.ToString()).GetComponent<Rigidbody>();
        rbs = GameObject.FindGameObjectWithTag(second.ToString()).GetComponent<Rigidbody>();
        rbt = GameObject.FindGameObjectWithTag(third.ToString()).GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (flag == "up")
        {
            rbf.velocity = new Vector3(0f, upVel, 0f);
            rbs.velocity = new Vector3(0f, upVel, 0f);
            rbt.velocity = new Vector3(0f, upVel, 0f);
        }
        if (rbf.transform.position.y >= floor.transform.position.y - 10f && rbf.transform.position.y <= floor.transform.position.y - 10f +4f)
        {
            flag = "down";
            rbf.velocity = new Vector3(0f, 0f, 0f);
            rbs.velocity = new Vector3(0f, 0f, 0f);
            rbt.velocity = new Vector3(0f, 0f, 0f);
        }
        if (flag == "down" )
        {
            rbf.velocity = new Vector3(0f, -upVel, 0f);
            rbs.velocity = new Vector3(0f, -upVel, 0f);
            rbt.velocity = new Vector3(0f, -upVel, 0f);
        }
        if (rbf.transform.position.y <= 1.24 && flag == "down")
        {
            rbf.velocity = new Vector3(0f, 0f, 0f);
            rbs.velocity = new Vector3(0f, 0f, 0f);
            rbt.velocity = new Vector3(0f, 0f, 0f);
            flag = "up";
            randomGenerator();
        }
    }
}
