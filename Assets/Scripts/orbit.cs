using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbit : MonoBehaviour {

    private float parentDist;

    // Use this for initialization
    void Start () {

        parentDist = transform.localPosition.magnitude; //orbital param

    }
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(transform.parent.position, Vector3.down, 20 * Time.deltaTime / (parentDist * parentDist));
    }
}
