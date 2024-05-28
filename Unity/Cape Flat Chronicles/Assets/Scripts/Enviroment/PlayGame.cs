using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGame : MonoBehaviour
{
    public GameObject door;
    // Start is called before the first frame update


    public void DestroyObject()
    {
        Destroy(door);
    }
}
