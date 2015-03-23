using UnityEngine;
using System.Collections;

public class RTS_view : MonoBehaviour {

    public Camera cctv1;
    private float zoom;
    public float min_limit_zoom = 5;
    public float max_limit_zoom = 100;
    public float sensix = 1;
    public float sensiy = 50;
    public float sensiz = 1;


    private Ray ray;
    private float x, y, z;
    private RaycastHit shootHit;

	// Use this for initialization
	void Start () {
        ray = new Ray(cctv1.transform.position,new Vector3(cctv1.fieldOfView / 90, 1, cctv1.fieldOfView / 90));        
        x = transform.position.x + transform.localPosition.x;
        y = transform.position.y + transform.localPosition.y;
        z = transform.position.z + transform.localPosition.z;
        if (Physics.Raycast(ray, out shootHit))
        {
            Debug.Log(cctv1.fieldOfView);
            Debug.Log(ray.direction);
            Debug.Log("hit" + shootHit.transform.position);
        }

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Z))
        {
            z += sensiz;
        }
        if (Input.GetKey(KeyCode.S))
        {
            z -= sensiz;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            x -= sensix;
        }
        if (Input.GetKey(KeyCode.D))
        {
            x += sensix;
        }
        y -= Input.GetAxis("Mouse ScrollWheel") * sensiy;
        transform.position = new Vector3(x, y, z);


	}
}
