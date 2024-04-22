using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public int education = 0;
    public int gangStatus = 0;

    public void IncreaseEducation(int value)
    {
        education += value;


        Debug.Log("Education increased to: " + education);
    }

    public void DecreaseEducation(int value)
    {
        education -= value;
        if (education < 0)
        {
            education = 0;
        }



        Debug.Log("Education decreased to: " + education);
    }

    public void IncreaseGangStatus(int value)
    {
        gangStatus += value;

        Debug.Log("Gang status has increased to: " + gangStatus);
    }

    public void DecreaseGangStatus(int value)
    {
        gangStatus -= value;
        if (gangStatus < 0)
        {
            gangStatus = 0;
        }


        Debug.Log("Gang status has decreased to: " + gangStatus);
    }
}
