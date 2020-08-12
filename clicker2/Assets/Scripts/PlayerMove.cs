using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    //public bool won = false;
    public float money = 0f;
    private float vel = 0.1f;
    public float velocity = 0f;
    public Text text;
    private double startTime = 0f;

    private float lastClickTime = -5f;

    public GameObject startAttackPos;
    public GameObject Attack;
    private Vector2 firePos;
    private bool is_courutine = false;
    private double fps = 0;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        firePos = startAttackPos.transform.position;
    }
    void Update(){
        //Debug.Log(Time.deltaTime);
        fps = 1 / Time.deltaTime;
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0)  && Time.time - startTime > 1)
        {
            lastClickTime = Time.time;
            //Debug.Log("!!!");
            if (!is_courutine) StartCoroutine(Coroutine1());
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        
        GameObject Enemy = GameObject.FindGameObjectWithTag("Enemy");
        if(Enemy == null){
            velocity = vel;
            return;
        }
        bool fight = Enemy.GetComponent<Enemy_Move>().fight;
        if(fight && GameObject.FindGameObjectWithTag("Electro") == null){
            Instantiate(Attack, firePos, Attack.transform.rotation);
        }
        if(!fight && GameObject.FindGameObjectWithTag("Electro") != null){
            Destroy(GameObject.FindGameObjectWithTag("Electro"));
        }
        if(fight){
            velocity = 0.0f;
            Enemy.GetComponent<Enemy_Move>().health -= 2f;
        }
        else {
            velocity = vel;
        }
        text.text = "Money " + money.ToString() + " \n FPS: " + (int)fps;
        /*if(won){
            won = false;
            money += 1;
            text.text = "Money " + money.ToString();
        }*/
    }

    private IEnumerator Coroutine1()
    {
        gameObject.transform.localScale += new Vector3(0.1f,0.1f,0);
        is_courutine = true;
        //Debug.Log("!");
        //transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, transform.position.y + 10f), Time.deltaTime);
        vel = 0.2f;
        while(Time.time - lastClickTime < 1) yield return null;
        //Debug.Log("!!");
        vel = 0.1f;
        //transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, transform.position.y - 10f), Time.deltaTime);
        is_courutine = false;
        gameObject.transform.localScale -= new Vector3(0.1f,0.1f,0);
    }

}
