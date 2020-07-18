using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_enemys : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    Vector2 where_to_spawn;
    public float spawn_rate = 5f;
    private float next_spawn_time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool has_enemy_on_scene = false;
        GameObject[] allGo = FindObjectsOfType<GameObject>();
        foreach (GameObject go in allGo){
            if(go.CompareTag("Enemy")){
                has_enemy_on_scene = true;
            }
            //Debug.Log(go.tag);
        }
        if(has_enemy_on_scene) return;
        //Debug.Log("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        //Debug.Log(Time.time);
        //Debug.Log(next_spawn_time);
        next_spawn_time = Time.time + spawn_rate;
        where_to_spawn = transform.position;
        float random = UnityEngine.Random.Range(0f, 1f);
        if(random > 0.75f)Instantiate (enemy1, where_to_spawn, Quaternion.identity);
        else if(random > 0.50f)Instantiate (enemy2, where_to_spawn, Quaternion.identity);
        else if(random > 0.25f) {
            where_to_spawn.y -= 0.25f;
            Instantiate (enemy3, where_to_spawn, Quaternion.identity);
        }
        else {
            where_to_spawn.y += 1f;
            Instantiate (enemy4, where_to_spawn, Quaternion.identity);
        }
    }
}
