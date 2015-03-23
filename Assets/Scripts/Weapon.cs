using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    public string Gun_name;
    public int damage = 10;
    public float range = 100f;
    public Animator anim;
    //public float shootspeed;
    public AudioSource shot_sound;
    public int clip = 30;
    private int total_ammo = 1000;
    private int in_clip = 30;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int get_in_clip()
    {
        return in_clip;
    }
    public int get_ammo()
    {
        return total_ammo;
    }

}
