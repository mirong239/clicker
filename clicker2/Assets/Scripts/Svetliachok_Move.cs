using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Svetliachok_Move : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 vel = new Vector2(0f, 0f);
    Vector2 acceleration = new Vector2(0f, 0f);

    Vector2 startPosition = new Vector2(0f, 0f);

    public GameObject start;
    public float maxDistance = 9f;
    public float maxSquereVelocity = 1;
    public float delta_acceleration = 1f;
    private Rigidbody2D rb;

    float distanse(Vector2 a, Vector2 b){
        return (a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = start.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(distanse(vel, new Vector2(0f, 0f)) > maxSquereVelocity){
            vel /= distanse(vel, new Vector2(0f, 0f)) / maxSquereVelocity;
        }
        if(distanse(startPosition, transform.position) > maxDistance){
            acceleration = (startPosition - new Vector2(transform.position.x, transform.position.y)) / 1;
        }
        else{
            acceleration += new Vector2(UnityEngine.Random.Range(0f, delta_acceleration) - delta_acceleration / 2, UnityEngine.Random.Range(0f, delta_acceleration) - delta_acceleration / 2);
        }
        rb.velocity = vel;
        vel += acceleration * Time.deltaTime;
    }
}
