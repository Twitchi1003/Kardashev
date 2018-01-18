using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camControl : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }
    private static float movementSpeed = 1.0f;

    void Update()
    {
        //movementSpeed = Mathf.Max(movementSpeed += Input.GetAxis(), 0.0f);
        transform.position += (transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical") + transform.up * Input.GetAxis("Mouse ScrollWheel")* 3) * movementSpeed;

        if (Input.GetMouseButton(1))
        {
            Debug.Log("right clicked");
            transform.eulerAngles += new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), Input.GetAxis("Rotation"));
        }
    }

    void OnMouseOver()
    {
        
    }

}