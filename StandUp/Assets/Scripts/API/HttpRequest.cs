using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Requests;

public class HttpRequest : MonoBehaviour
{
    private string _url = @"https://api.chucknorris.io/jokes/random/";

    public IEnumerator SendRequest(Action<string> callback)
    {
        UnityWebRequest request = UnityWebRequest.Get(_url); 

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError)
            callback("Networking Error: " + request.error);
        else
            callback(JsonUtility.FromJson<ResponceStruct>(request.downloadHandler.text).value);
    }

}
