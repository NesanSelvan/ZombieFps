using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public Transform playerbody;
    private float Xrotation = 0f;
    private float Yrotation = 0f;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * 1000 * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * 1000 * Time.deltaTime;

        Yrotation += mouseX;
        Yrotation = Mathf.Clamp(Yrotation, -360f, 360f);
        Xrotation -= mouseY;
        Xrotation = Mathf.Clamp(Xrotation, -90f, 90f);
        playerbody.localRotation = Quaternion.Euler(Xrotation,Yrotation,0f);
    }
}
