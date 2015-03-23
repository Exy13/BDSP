using UnityEngine;
using System.Collections;


public class EnemyScript : MonoBehaviour
{
    public int life;
    public Transform playerTransform;
    public PlayerHud playerHud;
    public int speed;
    public int sinkSpeed;
    public bool is_attacking = false;


    private NavMeshAgent nav;
    private CapsuleCollider capsuleCollider;
   // private bool isOnTheGround = false;
    private bool alive = true;
    private System.Random rand = new System.Random();
    private int toto;
    // Use this for initialization
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
		capsuleCollider = GetComponent<CapsuleCollider>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        playerHud = GameObject.FindGameObjectWithTag("Hud").GetComponent<PlayerHud>();
		nav.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (nav.enabled)
        {
            nav.SetDestination(playerTransform.position);    
			GetComponent<Animation>().CrossFade("run");
        }

        
        toto = rand.Next(0, 4);

        
        if (!alive && !GetComponent<Animation>().IsPlaying("death"))
        {
            transform.Translate(Vector3.down * sinkSpeed * Time.deltaTime);
            Destroy(gameObject, 4f);

        }


        if (Vector3.Distance(playerTransform.localPosition, transform.localPosition) < 2.5)
        {

            if (!(GetComponent<Animation>().IsPlaying("attack1")) && !(GetComponent<Animation>().IsPlaying("attack2")) && !(GetComponent<Animation>().IsPlaying("attack3")))
            {

                switch (toto)
                {
                    case 1:
                        GetComponent<Animation>().Play("attack1");
                        break;
                    case 2:
                        GetComponent<Animation>().Play("attack2");
                        break;
                    case 3:
                        GetComponent<Animation>().Play("attack3");
                        break;
                    default:
                        GetComponent<Animation>().Play("idle");
                        break;
                }
                playerHud.take_damage(2);
            }
        }


        if (life < 0 && alive)
        {
            die();
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "GROUND")
        {
            //isOnTheGround = true;
        }

    }

    void OnTriggerEnter(Collider other)
    {
       


    }




    void die()
    {
        playerHud.score(10);
        nav.enabled = false;
        GetComponent<Animation>().Play("death");
        GetComponent<Animation>()["death"].speed = 2;
        tag = "Dead_Goblin";
        GetComponent<Rigidbody>().isKinematic = true;
        capsuleCollider.isTrigger = true;
        alive = false;

    }



}
