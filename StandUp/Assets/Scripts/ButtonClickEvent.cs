using UnityEngine;
using UnityEngine.Events;

public class ButtonClickEvent : MonoBehaviour
{
    [SerializeField] private Transform _target;
    public UnityEvent<Vector2> OnButtonClick;

    public void MoveTo(Transform target)
    {
        OnButtonClick?.Invoke(target.position);
    }
}
