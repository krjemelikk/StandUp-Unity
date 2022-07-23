using UnityEngine;
using UnityEngine.Events;

public class AnimEvent : MonoBehaviour
{
    [SerializeField] private AnimStates animStates;
    public UnityEvent<AnimStates> OnEnter;

    public void InvokeEvent()
    {
        OnEnter?.Invoke(animStates);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        InvokeEvent();
    }
}
