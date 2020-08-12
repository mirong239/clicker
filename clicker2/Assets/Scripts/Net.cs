using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Net : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MyGet_player_info());
    }

    UnityWebRequest createRequest(string url, string username, string password)
    {
	    UnityWebRequest req = UnityWebRequest.Get(url);

	    // could also use "US-ASCII" or "ISO-8859-1" encoding
	    string encoding = "UTF-8"; 
	    string base64 = System.Convert.ToBase64String(
		System.Text.Encoding.GetEncoding(encoding)
			.GetBytes(username + ":" + password)
	    );

	    req.SetRequestHeader("Authorization", "Basic " + base64);
	    return req;
    }
    private IEnumerator MyGet_player_info(){
        UnityWebRequest inf = createRequest("https://api.kido.ws/v0/player", "5825f176-cc20-11ea-a8e2-1a1210d012ab", "yjwkKL2HqQo8AMhi");
        yield return inf.SendWebRequest();
        Debug.Log(inf.ToString());
        Debug.Log(inf.downloadHandler.text);
        Debug.Log("!");
    }

    private IEnumerator MyGet_Id_pass(){
        UnityWebRequest inf = UnityWebRequest.Get("https://api.kido.ws/v0/register");
        yield return inf.SendWebRequest();
        Debug.Log(inf.ToString());
        Debug.Log(inf.downloadHandler.text);
        Debug.Log("!");
    }
}
