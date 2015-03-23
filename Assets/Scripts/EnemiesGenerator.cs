using UnityEngine;
using System.Collections;

public class EnemiesGenerator : MonoBehaviour {
    public Transform map;
    public GameObject enemy;
    public bool spawn;
    private float timeElapsed;
	public float delayBetweenSpawn = 1f;
	private const int spawnHeight = 40;
    private System.Random r = new System.Random();
    
    
    void Start ()
    {
        if (spawn)
        {
           // InvokeRepeating("Spawn", delayBetweenSpawn, delayBetweenSpawn);    
        }
        
    }
	
	void Update ()
    {
        if (Time.frameCount % 20 == 1)
        {
            Spawn();
        }

	}

    private void Spawn()
    {
        Instantiate(enemy, GetSpawningPosition(), Quaternion.identity);
        
    }


 


    private Vector3 GetSpawningPosition()
    {

        return new Vector3(map.transform.localScale.x * (float)r.NextDouble() * 5 * r.Next(-1,2), 3, map.transform.localScale.x * (float)r.NextDouble() * 5 * r.Next(-1,2));
    }
}
