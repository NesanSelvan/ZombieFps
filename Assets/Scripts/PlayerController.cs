using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController m_ch;
    private Vector3 velocity;
    private float gravity =-9.18f;
    public Transform groundcheck;
    public LayerMask groundmask;
    private float groundistance = 0.4f;
    private bool isgrounded;
   

    // Start is called before the first frame update
    void Awake()
    {
        m_ch = GetComponent<CharacterController>();
       
    }

    // Update is called once per frame
    void Update()
    {
        isgrounded = Physics.CheckSphere(groundcheck.position, groundistance, groundmask);
       if(isgrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if(Input.GetKey(KeyCode.Space) && isgrounded)
        {
            velocity.y = 4;
            Debug.Log("Jump");
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.forward * z+ transform.right * x;
        m_ch.Move(move * 2);
        velocity.y += gravity * Time.deltaTime;
      
        m_ch.Move(velocity * Time.deltaTime * 50);
      
    }
}
