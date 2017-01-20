using UnityEngine;
using System.Collections;



public class Move : MonoBehaviour {
  
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 rot = Camera.main.transform.localEulerAngles;

        if ( rot.y > 310f ) {
            transform.position = new Vector3(-14.3f, 1f, (Mathf.Pow(rot.y, -0.1f) * 892f) -495f) ;
            // trial and error 
        }   
        else if (rot.y < 50f) {
            transform.position = new Vector3(-14.3f, 1f, -(rot.y / 6.5f));
        }
    }

}
