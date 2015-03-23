using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerHud : MonoBehaviour {

    public List<Text> texts = new List<Text>();
    public List<Slider> slides = new List<Slider>();
    public Dictionary<string, int> vars = new Dictionary<string,int>();
    public Sprite bullet;
    public GameObject image_pos;

    private GameObject active_gun;
    private GameObject player;
    

    /*
    texts : 
     * 0 - score
     * 1 - money
     * 2 - ammo
     * 3 - clip
     * 4 - health
     * 5 - shields
     * 
     * Slides : 
     * 0 - Health
     * 1 - Shields
    */

	void Start () {
        active_gun = GameObject.FindGameObjectWithTag("active_gun");
        vars.Add("life", 100);
        vars.Add("shield", 100);
        vars.Add("score", 0);
        vars.Add("money", 0);   
        vars.Add("clip", active_gun.GetComponent<GunScript>().in_clip);
        vars.Add("ammo", active_gun.GetComponent<GunScript>().total_ammo);
        vars.Add("mana", GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().mana);


        texts[0].text = "Score : " + vars["score"].ToString();
        texts[1].text = "Money : " + vars["money"].ToString();
        texts[2].text = "/" + vars["ammo"].ToString();
        texts[3].text = vars["clip"].ToString();
        texts[4].text = vars["life"].ToString();
        texts[5].text = vars["shield"].ToString();
        
        slides[0].value = vars["life"];
        slides[1].value = vars["shield"];
	}

    public void shoot()
    {
        vars["clip"] --;
        texts[3].text = vars["clip"].ToString();        
    }
    public void reload(int clip) // APPELLER APRES LES CALCULS DE RELOAD
    {
        vars["clip"] = clip;
        vars["ammo"] = active_gun.GetComponent<GunScript>().total_ammo;
        texts[2].text = "/" + vars["ammo"].ToString(); 
        texts[3].text = vars["clip"].ToString();        
    }

    public void take_damage(int amount)
    {
        
        if (vars["shield"] - amount < 0)
        {
            vars["life"] -= amount - vars["shield"];
            vars["shield"] = 0;
            if (vars["life"] < 0)
            {
                /*DIE*/
            }
            else
            {
                texts[4].text = vars["life"].ToString();
                slides[0].value = vars["life"];                
            }
        }
        else
        {
            vars["shield"] -= amount;
            texts[5].text = vars["shield"].ToString();
            slides[1].value = vars["shield"];
        }        
    }

    public void score(int amount)
    {
        vars["score"] += amount;
        vars["money"] += amount;
        texts[0].text = "Score : " + vars["score"].ToString();
        texts[1].text = "Money : " + vars["money"].ToString();
    }

    void display_score(bool b)
    {
        if (b)
        {
            texts[0].color = new Color(255, 255, 255, 255);
        }
        else
        {
            texts[0].color = new Color(255, 255, 255, 0);
        }
    }

    public void switch_weapon()
    {
        active_gun = GameObject.FindGameObjectWithTag("active_gun");
        vars["ammo"] = active_gun.GetComponent<GunScript>().total_ammo;
        vars["clip"] = active_gun.GetComponent<GunScript>().clip;
        texts[2].text = "/" + vars["ammo"].ToString();
        texts[3].text = vars["clip"].ToString();        
    }




    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            display_score(true);
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            display_score(false);
        }
    }
}
