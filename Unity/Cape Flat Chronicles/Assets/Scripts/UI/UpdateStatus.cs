using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateStatus : MonoBehaviour
{
    public TextMeshProUGUI GangStatus;
    public TextMeshProUGUI EduStatus;
    public FirstPersonController fpscontroller;

    private int gangStatus;
    private int eduStatus;
    // Start is called before the first frame update
    void Start()
    {
        gangStatus = fpscontroller.GangStatus;
        eduStatus = fpscontroller.EducationStatus;
        
    }

    // Update is called once per frame
    void Update()
    {
        GangStatus.text = gangStatus.ToString();
        EduStatus.text = eduStatus.ToString();
        
    }
}
