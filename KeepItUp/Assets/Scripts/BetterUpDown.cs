using UnityEngine;

public class BetterUpDown : MonoBehaviour
{

    public GameObject floor;
    public GameObject badCow;
    public GameObject cow1, cow2, cow3, illCow;
    GameObject firstObject, secondObject, thirdObject;
    Rigidbody rbf, rbs, rbt;

    public float vel = 3f;
    public float howMuchAboveFloor;
    int first, second, third;
    public int goUpTimer = 6;
    public int howManyCows = 10;
    private string replacedCowTag;

    public Vector3 initalposition1, initalposition2, initalposition3;

    public CowBehaviour script1, script2, script3;

    bool randomCalled = false;
   
    void Start()
    {
        illCow = GameObject.FindGameObjectWithTag("badcow");
        //Debug.Log(maxHeight);
        //randomGenerator();
        InvokeRepeating("randomGenerator", 3f, goUpTimer); // TODO Adjust Timing Here
        //ResetTag();
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
        first = Random.Range(0, howManyCows);
        second = RandomRangeExcept(0, howManyCows, first);
        third = RandomRangeExcept(0, howManyCows, first, second);
        sendUp(first, second, third);
    }

    public void sendUp(int first, int second, int third)
    {
        cow1 = GameObject.FindGameObjectWithTag(first.ToString());
        cow2 = GameObject.FindGameObjectWithTag(second.ToString());
        cow3 = GameObject.FindGameObjectWithTag(third.ToString());
        script1 = cow1.GetComponent<CowBehaviour>();
        script2 = cow2.GetComponent<CowBehaviour>();
        script1.toMove = true;
        script2.toMove = true;
        float randomvalue = Random.Range(0, 100);

        if(randomvalue>80.0f)
        {
            //Debug.Log("changed cow//ill cow up");
            badCow.transform.position = cow3.transform.position;
            badCow.tag = cow3.tag;
            replacedCowTag = cow3.tag;
            cow3.tag = "999";
            BadCowBehaviour script4 = badCow.GetComponent<BadCowBehaviour>();
            script4.toMove = true;
            Invoke("ResetTag",4);
        }
        else
        {
            script3 = cow3.GetComponent<CowBehaviour>();
            script3.toMove = true;
        }
    }

    void ResetTag()
    {
        //Debug.Log("called resettag");
        cow3.tag = replacedCowTag;
        illCow.tag = "badcow";
    }
}
