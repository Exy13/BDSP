using UnityEngine;
using System.Collections;

public class DontDie : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        col.gameObject.transform.position = new Vector3(0, 5, 0);
        

    }


	// Update is called once per frame
	void Update () {
	
	}
}
