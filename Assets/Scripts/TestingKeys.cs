using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingKeys : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 1. Mouse
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Button Pressed");
        }

        // 2. Getting keyboard button events
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Using Jump. You can use this to make the player jump");
        }

        // 3. Getting axis for movement when user tap a keyboard (Left,Right,Up,Down) 
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal < 0f || horizontal > 0f)
        {
            Debug.Log("Horizontal axis is: " + horizontal);
        }

        if (vertical < 0f || vertical > 0f)
        {
            Debug.Log("Horizontal axis is: " + vertical);
        }
    }
}
