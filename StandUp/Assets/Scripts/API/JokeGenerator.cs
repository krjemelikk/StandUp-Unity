using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

[RequireComponent(typeof(HttpRequest))]
public class JokeGenerator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _outputField;
    private HttpRequest HttpRequest;

    private void Start()
    {
        HttpRequest = GetComponent<HttpRequest>();
    }

    public void GetJoke()
    {
        StartCoroutine(HttpRequest.SendRequest(result => ShowJoke(result)));
    }

    private void ShowJoke(string message)
    {
        _outputField.text = message;
    }
}
