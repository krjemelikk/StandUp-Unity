using UnityEngine;
using UnityEngine.Events;

public class PointEvent : MonoBehaviour
{
    public UnityEvent OnEnter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnEnter?.Invoke();
    }
}
