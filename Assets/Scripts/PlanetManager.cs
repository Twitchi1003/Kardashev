using UnityEngine;
using System.Collections;

public class PlanetManager : MonoBehaviour {


    public enum Ptype {
		Dwarf,
		Rocky,
		Terrestrial,
		IceGiant,
		GasGiant

	}
	public Ptype ptype;

	public Material[] material;
	Renderer rend;


	public int materials;
	private float hoverTime;
	private Vector3 scaleHolder;


    public GameObject PinfoParent; //world UI,planet Information
    private bool InfoShow = false;

    public GameObject shuttle;

    
    void Start () {

		hoverTime = 0;
        materials = Random.Range(3, 1000);     //murcury:jupiter ratio  
		scaleHolder = transform.localScale;
		rend = GetComponent<Renderer>();

       if (materials <= 100f)
            ptype = Ptype.Dwarf;
        else if (materials > 100f && materials <= 400f)
            ptype = Ptype.Rocky;
        else if (materials > 400f && materials <= 600f)
            ptype = Ptype.IceGiant;
        else if (materials > 600f && materials <= 1000f)
            ptype = Ptype.GasGiant;

       //make terestrial if in Habital zone, reaches from = (sun.mass/1.1)*scalefactor to (sun.mass/0.5)*scalefactor

        switch (ptype) {
		    case Ptype.Dwarf:
				scaleHolder = scaleHolder * 0.5f;
				rend.sharedMaterial = material[0];
				break;
			case Ptype.Rocky:
				rend.sharedMaterial = material[1];
				break;
			case Ptype.Terrestrial:
				rend.sharedMaterial = material[2];
				break;
		    case Ptype.IceGiant:
				scaleHolder = scaleHolder * 1.5f;
				rend.sharedMaterial = material[3];
			break;
			case Ptype.GasGiant:
				scaleHolder = scaleHolder * 2f;
				rend.sharedMaterial = material[4];
				break;
			default:
				Debug.Log ("woops, ptype switch statment fail");
				break;
		}
		transform.localScale = scaleHolder;
        
    }

    void Update()
    {
         
       
    }


    void OnMouseEnter() {			
        scaleHolder = scaleHolder * 1.1f;
		transform.localScale = scaleHolder;
    }

   
	void OnMouseOver() {
		if (hoverTime < 1000) {
			hoverTime += 1;
        }

		if (hoverTime > 75 && !InfoShow) {
            InfoShow = true; //so we only get one canvas ;)
            Instantiate(PinfoParent, transform.position + new Vector3( 1f * transform.lossyScale.magnitude, 1f * transform.lossyScale.magnitude, 0), transform.rotation,transform);
        }
	}

    void OnMouseExit()
    {
        hoverTime = 0;
        scaleHolder = scaleHolder / 1.1f;
        transform.localScale = scaleHolder;
        Destroy(GameObject.Find("PinfoParent(Clone)"));
        InfoShow = false;
    }

    void OnMouseDown()
    {
        if (materials > 10f)
        {
            Instantiate(shuttle, transform.position + (Vector3.left * 0.25F), Quaternion.Euler(0, 180, -90), transform); // this should be on pop up ui element
            materials -= 10;
        }
        else {
            Debug.Log("NO MATERIALS");
        }

    }




}
