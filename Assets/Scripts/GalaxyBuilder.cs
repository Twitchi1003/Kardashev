using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyBuilder : MonoBehaviour {

    public GameObject sysFab;

    public int galaxyPop = 500;

    // Use this for initialization
    void Start () {



        for (int i = 0; i < galaxyPop; i++)
        {
            Instantiate(sysFab);
        }

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
