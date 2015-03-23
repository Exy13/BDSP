using UnityEngine;
using System.Collections;

public class GunScript : MonoBehaviour
{

    public Camera Camera;
    public RectTransform scope;


    // private bool shooting = false;
    
    public string Gun_name;
    public int damage = 10;
    public float range = 100f;
    public Animator anim;
    //public float shootspeed;
    public int clip;
    public int total_ammo;
    public int in_clip;


    //private float shootspeed;
    public AudioSource shot_sound;
    private int scale = 5;
    private Ray shootRay;
    private PlayerHud playerHUD;
    //private GameObject zoom_pos;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>(); ;
        //shootspeed = Gun.shootspeed;
        //zoom_pos = GameObject.FindGameObjectWithTag("Pos_camera");
        //Screen.lockCursor = true;
        Camera = FindObjectOfType<Camera>();
        scope = GameObject.FindGameObjectWithTag("Scope").GetComponent<RectTransform>();
        playerHUD = GameObject.FindGameObjectWithTag("Hud").GetComponent<PlayerHud>();
        in_clip = clip;
    }

    // Update is called once per frame
    void Update()
    {

        transform.localRotation = Camera.transform.localRotation;

        if (in_clip <= 0)
        {
            if  (total_ammo - clip < clip && total_ammo > 0)
            {
                in_clip = total_ammo;
                total_ammo = 0; 
                /*Less than clip ammo remaining*/
                playerHUD.reload(in_clip);
            }
            else if (total_ammo - clip > 0)
            {
                total_ammo = total_ammo - clip;
                in_clip = clip;
                playerHUD.reload(clip);
                /*RELOAD*/
            }
            else
            {
                total_ammo = 0;
                in_clip = 0;
                /*OUT OF AMMO*/
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                /*SHOOT*/
                playerHUD.shoot();
                in_clip--;
                shot_sound.Play();
                shootRay.origin = transform.position;
                shootRay.direction = transform.forward;
                RaycastHit shootHit;
                /*play anim shot*/
                if (Physics.Raycast(shootRay, out shootHit, range))
                {
                    if (shootHit.transform.tag == "Goblin")
                    {
                        Debug.Log("tir");

                        shootHit.transform.GetComponent<EnemyScript>().life -= damage;
                    }
                }
            }
            else
            {
                
            }
        }
        if (Input.GetMouseButton(1))
        {
            /*ZOOM*/
            scope.localScale = new Vector3(scale, scale, 1);
            //Camera.transform.localPosition = zoom_pos.transform.localPosition;
            Camera.fieldOfView = 10;
        }
        else
        {
            /*UNZOOM*/
            scope.localScale = new Vector3(1, 1, 1);
            //Camera.transform.localPosition = new Vector3(0, 0.426F, 0);
            Camera.fieldOfView = 60;
        }
    }

}
