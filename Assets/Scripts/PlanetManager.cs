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


	public float materials;
	private float hoverTime;
	private Vector3 scaleHolder;


    public GameObject PinfoParent; //world UI,planet Information
    private bool InfoShow = false;

    public GameObject shuttle;

    
    void Start () {

		hoverTime = 0;
		materials = 100f; //random.range 3,1000     murcury:jupiter ratio  
		scaleHolder = transform.localScale;
		rend = GetComponent<Renderer>();


        ptype = (Ptype)Random.Range(0, 5);  //random element


        switch (ptype) {
		    case Ptype.Dwarf:
				materials = materials * 0.5f;
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
				materials = materials * 1.5f;
				scaleHolder = scaleHolder * 1.5f;
				rend.sharedMaterial = material[3];
			break;
			case Ptype.GasGiant:
				materials = materials * 2f;
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
            materials -= 10F;
        }
        else {
            Debug.Log("NO MATERIALS");
        }

    }




}
