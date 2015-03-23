using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {


    //private List<GameObject> consumables = new List<GameObject>();
    public List<GameObject> Weapons = new List<GameObject>();
    public int mana;
    private int cur;
    private PlayerHud playerHUD;

	void Start () {
        print(Weapons.Count);
        cur = 0;        
        Weapons[1].GetComponent<GunScript>().enabled = false;
        Weapons[2].GetComponent<GunScript>().enabled = false;
        playerHUD = GameObject.FindGameObjectWithTag("Hud").GetComponent<PlayerHud>();
	}
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Change_weapon(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Change_weapon(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Change_weapon(2);
        }
            
    }


    /*
    void Add_Item(GameObject g)
    {
        if (Weapons.Count <= 2)
        {
            Weapons.Add(g);
            Instantiate(g, Weapons[cur].transform.position, Weapons[cur].transform.rotation);
            
        }
        
    }*/

    private void swicth_transform(Transform t1, Transform t2)
    {
        Vector3 t = t1.position;
        t1.position = t2.position;
        t2.position = t;
        Quaternion q = t1.rotation;
        t1.rotation = t2.rotation;
        t2.rotation = q;
    }

    private void switch_parent(GameObject g1, GameObject g2)
    {
        Transform g = g1.transform.parent;
        g1.transform.parent = g2.transform.parent;
        g2.transform.parent = g;
        g1.transform.localPosition = Vector3.zero;
        g1.transform.localRotation = Quaternion.identity;
        g2.transform.localPosition = Vector3.zero;
        g2.transform.localRotation = Quaternion.identity;
        g2.GetComponent<GunScript>().enabled = false;
        g1.GetComponent<GunScript>().enabled = true;
        g2.tag = "inventory";
        g1.tag = "active_gun";
    }

    void Change_weapon(int n)
    {
        //swicth_transform(Weapons[n].transform, Weapons[cur].transform);
        switch_parent(Weapons[n], Weapons[cur]);
        cur = n;
        playerHUD.switch_weapon();
    }


}
