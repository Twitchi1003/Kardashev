using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class systemBuilder : MonoBehaviour
{

    public GameObject starFab;
    public GameObject planetFab;

    // Use this for initialization
    void Start()
    {
        GameObject alphaStar = Instantiate(starFab) as GameObject;

        alphaStar.transform.position = new Vector3(Random.Range(-1000.0f, 1000.0f), Random.Range(-200.0f, 200.0f), Random.Range(-1000.0f, 1000.0f));

        var numberOfPlanets = 5;// Random.Range(0,5);

        for (var i = 0; i < numberOfPlanets; i++)
        {
            var planet = Instantiate(planetFab, alphaStar.transform.position, alphaStar.transform.rotation);
            planet.transform.SetParent(alphaStar.transform, false);
            planet.transform.position = alphaStar.transform.position;
            planet.transform.position += new Vector3(i+1, 0, 0);
        }

        Destroy(gameObject);

    }

    void Update()
    {
        //for all planets, orbit relative to star
    }

}