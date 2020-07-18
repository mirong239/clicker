using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Net : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MyGet());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator MyGet(){
        UnityWebRequest inf = UnityWebRequest.Get("https://api.kido.ws/v0/register");
        yield return inf.SendWebRequest();
        Debug.Log(inf.ToString());
        Debug.Log(inf.downloadHandler.text);
        Debug.Log("!");
    }
}
