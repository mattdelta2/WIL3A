using UnityEngine;
using UnityEngine.Rendering;

public class DayAndNight : MonoBehaviour
{
    Vector3 rot=Vector3.zero;
    float degPerSec = 6;


    
    void Update()
    {
        rot.x = degPerSec* Time.deltaTime;
        transform.Rotate(rot, Space.World);

    }
}
