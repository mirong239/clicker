using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPref;
    public GameObject[] selectorArr;
    // Start is called before the first frame update
    void Start()
    {
        selectorArr = new GameObject[10];
        for (int i = 0; i < 10; i++)
        {
            GameObject coin = Instantiate(coinPref, transform.position, Quaternion.identity) as GameObject;
            selectorArr[i] = coin;
        }
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
