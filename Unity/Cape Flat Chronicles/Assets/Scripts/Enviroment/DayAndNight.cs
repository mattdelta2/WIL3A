using UnityEngine;
using UnityEngine.Rendering;

public class DayAndNight : MonoBehaviour
{
    Vector3 rot=Vector3.zero;
    float degPerSec = 3; 
    /*
     at 3 1 minute day/ 1 minute night cycle
        6 30 sec day/ 30sec night cycle

     */


    
    void Update()
    {
        rot.x = degPerSec* Time.deltaTime;
        transform.Rotate(rot, Space.World);

    }
}
