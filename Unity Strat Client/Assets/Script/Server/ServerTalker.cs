using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class ServerTalker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Make a Web Request to get info from server
        // this wil be a text response on JSON
        StartCoroutine(GetWebData("http://141.94.23.39:3000/user/", "33"));
    }

    void ProcessServerResponse( string rawResponse)
    {


        // Parse the JSON
        JSONNode node = JSON.Parse(rawResponse);

        //Output some stuff in consol to proof
        Debug.Log("Username: " + node["username"]);
        Debug.Log("Misc Data: " + node["someArray"][1]["name"] + " = " + node["someArray"][1]["value"]);

    }

    IEnumerator GetWebData ( string adresse, string myID)
    {
        UnityWebRequest www = UnityWebRequest.Get("http://141.94.23.39:3000/user/" + myID);
        yield return www.SendWebRequest();

        if(www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Something went wrong:" + www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            ProcessServerResponse(www.downloadHandler.text);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
