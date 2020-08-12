using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConiFall1 : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Collider2D cd;
    public float delta_vel_y = 2f;
    public float delta_vel_x = 5f;
    public GameObject _lastPos;
    private Vector2 acceleretion = new Vector2(0f, 0f);
    public float maxSquereVel = 10f;
    private float collisionTime = 0f;
    private bool flag = false;
    private bool flag1 = false;
    public float minDistance = 0.1f;
    Vector2 lastPos;

    void startMove(){
        flag1 = true;
        rb.velocity = new Vector2(UnityEngine.Random.Range(0f, delta_vel_x) - delta_vel_x / 2, UnityEngine.Random.Range(delta_vel_y / 2, delta_vel_y));
        //Debug.Log(rb.velocity.y);
    }
    void Start()
    {
        _lastPos = GameObject.FindGameObjectWithTag("Money");
        lastPos = new Vector2(_lastPos.transform.position.x, _lastPos.transform.position.y);
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<Collider2D>();
        startMove();
    }

    float distance(Vector2 a, Vector2 b){
        return (a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y);
    }
    


    // Update is called once per frame
    void Update()
    {
        if(Time.time > collisionTime && !flag1){
            cd.isTrigger = true;
            rb.gravityScale = 0;
            acceleretion = (lastPos - new Vector2(transform.position.x, transform.position.y));
            rb.velocity += acceleretion;
            if ((rb.velocity.x * rb.velocity.x + rb.velocity.y * rb.velocity.y) > maxSquereVel){
                rb.velocity *= maxSquereVel / (rb.velocity.x * rb.velocity.x + rb.velocity.y * rb.velocity.y);
            }
        }
        if(transform.position.y > lastPos.y){
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().money += 1;
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision){
        if(flag1 && collision.collider.name != "Coin_0") {
            collisionTime = Time.time + 1;
            flag1 = false;
        }
    }
}
