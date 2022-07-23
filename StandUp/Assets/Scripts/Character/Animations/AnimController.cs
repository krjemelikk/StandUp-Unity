using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class AnimController : MonoBehaviour
{
    private Dictionary<AnimStates, string> animStates = new Dictionary<AnimStates, string> 
    {
        { AnimStates.Walk, "Walk" },
        { AnimStates.Idle, "Idle" },
        { AnimStates.Death, "Death" },
        { AnimStates.Run, "Run" },
        { AnimStates.Exit, "Exit" }
    };

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        SetAnimation(AnimStates.Walk);
    }

    public void SetAnimation(AnimStates state)
    {
        Debug.Log(state);
        var str = animStates.TryGetValue(state, out string currentstate);
        if(currentstate != null)
        {
            _animator.SetBool(currentstate, true);
        }
    } 
}
