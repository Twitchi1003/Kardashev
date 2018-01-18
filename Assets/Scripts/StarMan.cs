using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMan : MonoBehaviour
{

    public enum Stype
    {
        WhiteDwarf,
        Sun,
        RedDwarf,
        RedGiant,
        HypeGiant

    }
    public Stype sType;

    public Material[] material;
    Renderer rend;
    Light starLight;
    public ParticleSystem particleSys;


    private Vector3 scaleHolder;


    void Start()
    {

        scaleHolder = transform.localScale;
        rend = GetComponent<Renderer>();
        starLight = GetComponent<Light>();

        //particle sys not working
        particleSys = GetComponent<ParticleSystem>();
        var pShape = particleSys.shape;
        var pMain = particleSys.main;
        var peeMission = particleSys.emission;

        sType = (Stype)Random.Range(0, 5);  //random element

        switch (sType)
        {
            case Stype.WhiteDwarf:
                scaleHolder = scaleHolder * 0.1f;
                rend.sharedMaterial = material[0];
                //particles not changed
                pShape.radius = 0.01f;
                pMain.startSize = 0.6f;
                pMain.startColor = new Color(1, 1, 1);
                break;
            case Stype.Sun:
                rend.sharedMaterial = material[1];

                pShape.radius = 0.3f;
                pMain.startSize = 0.6f;
                pMain.startColor = Color.yellow;
                break;
            case Stype.RedDwarf:
                scaleHolder = scaleHolder * 0.5f;
                rend.sharedMaterial = material[2];
                starLight.color = Color.red;

                pShape.radius = 0.1f;
                pMain.startSize = 0.7f;
                pMain.startColor = new Color(1, 0.1f, 0);
                break;
            case Stype.RedGiant:
                scaleHolder = scaleHolder * 1.5f;
                rend.sharedMaterial = material[2];
                starLight.color = Color.red;

                pShape.radius = 0.75f;
                pMain.startSize = 0.5f;
                pMain.startColor = new Color(1, 0.1f, 0);
                peeMission.rateOverTime = 30;
                pMain.startLifetime = 15;
                pMain.duration = 20;
                break;
            case Stype.HypeGiant:
                scaleHolder = scaleHolder * 2f;
                rend.sharedMaterial = material[3];
                starLight.color = Color.blue;

                pShape.radius = 0.8f;
                pMain.startSize = 0.5f;
                pMain.startColor = new Color(0, 0.1f, 1);
                peeMission.rateOverTime = 30;
                pMain.startLifetime = 15;
                pMain.duration = 20;
                break;
            default:
                Debug.Log("woops, Stype switch statment fail");
                break;
        }

        transform.localScale = scaleHolder;

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnMouseDown()
    {
        // stop orbits
        //var planets = GetComponentsInChildren<orbit>();

        //foreach (orbit o in planets)
        //{
        //if (o.enabled) { o.enabled = false; } else { o.enabled = true; } ;
        //}

        



        var trans = GetComponentInChildren<Transform>();

        foreach (Transform t in trans)
        {

            //stop orbits
            if (t.parent = transform)
            {

                var planets = GetComponentsInChildren<orbit>();

                foreach (orbit o in planets)
                {
                    if (o.enabled) { o.enabled = false; } else { o.enabled = true; };
                }

            }


            //supposed to line up planets side of star.. suposed to
            var parentDist = t.localPosition.magnitude;
            t.position = transform.parent.position + (Camera.main.transform.right * parentDist) ;

        }
       
    }
}
