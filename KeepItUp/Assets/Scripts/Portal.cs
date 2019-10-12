using UnityEngine;

public class Portal : MonoBehaviour
{

    public Material mat;
    //public GameObject cow;
    //public GameObject illCow;
    public float posColorChange;
    public float posColorRevert;
    public string Tag;
    //Color redColor;
    //Color whiteColor;

    private void Start()
    {
        //Color redColor = new Color(255f, 0f, 0f, 0.5f);
        //Color whiteColor = new Color(255f, 255f, 255f, 0.5f);
        //mat.color = whiteColor;
        mat.color = Color.white;
    }

    void Update()
    {
        GameObject cow = GameObject.FindGameObjectWithTag(Tag);
        //if(cow.transform.position.y >= posColorChange || illCow.transform.position.y >= posColorChange)
        if (cow.transform.position.y >= posColorChange)
        {
            mat.color = Color.red;
            //mat.color = redColor;
           // Debug.Log("red ran");
        }
        //else if (cow.transform.position.y <= posColorRevert || illCow.transform.position.y <= posColorChange)
        else if (cow.transform.position.y <= posColorRevert)
        {
            mat.color = Color.white;
            //mat.color = whiteColor;
            //Debug.Log("white ran");
        }
    }

}
