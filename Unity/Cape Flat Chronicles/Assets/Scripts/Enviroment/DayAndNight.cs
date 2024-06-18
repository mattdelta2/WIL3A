using UnityEngine;
using UnityEngine.Rendering;

public class DayAndNight : MonoBehaviour
{
    Vector3 rot = new Vector3(90, 0, 0); // Initialize the rot vector correctly
    float degPerSec = 3;

    /*
     at 3 1 minute day/ 1 minute night cycle
        6 30 sec day/ 30sec night cycle
     */
    private void Start()
    {
        SetMiddayRotation();
    }

  /*  void Update()
    {
        // Calculate the rotation based on degrees per second and time elapsed
        float rotationAmount = degPerSec * Time.deltaTime;
        rot.x = rotationAmount;

        // Rotate the transform
        transform.Rotate(rot, Space.World);
    }*/

    public void SetMiddayRotation() // Method to set sun's rotation to midday
    {
        transform.rotation = Quaternion.Euler(90, 0, 0); // Adjust as needed
    }
}
