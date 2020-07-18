using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : MonoBehaviour
{
    public GameObject coinSpawner;
    private Material material;
    public float speed = -0.5f;
    //private GameObject gameObj;
    private Rigidbody2D rb;
    private bool dissolve = false;
    public bool fight = false;
    public float health = 100;
    private float fade = 1f;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
        material.SetFloat("_Fade", fade);
        rb = GetComponent<Rigidbody2D>();
    }
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.name != "Player") return;
        //Debug.Log(collider.name);
        speed = 0f;
        fight = true;
    }

    // Update is called once per frame
    void Update()
    {
        float move =  speed;
        Vector3 targetVelocity = new Vector2(move * 10f, rb.velocity.y);
        rb.velocity = targetVelocity;
        if(health <= 0 && ! dissolve){
            //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().won = true;
            dissolve = true;
            fight = false;
        }
        if(dissolve){
            speed = -0.25f;
            fade -= Time.deltaTime;
                if(fade < 0f){
                    Instantiate(coinSpawner, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
                material.SetFloat("_Fade", fade);
        }
    }
}
