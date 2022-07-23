using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(Animator))]
public class Character : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _targetPoint;

    private Rigidbody2D _rigidbody;
    private float _speed = 0.3f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();        
    }

    private void OnEnable()
    {
        transform.position = _spawnPoint.transform.position;
        StartCoroutine(Move(_targetPoint.position));
    }

    public void StartMoveCorrutine(Vector2 direction)
    {
        StartCoroutine(Move(direction));
    }

    private IEnumerator Move(Vector2 direction)
    {
        Vector2 dir = new Vector2(direction.x, 0);
        var offset = dir.normalized.x * _speed;
        while (Math.Abs(transform.position.x - direction.x) > offset)
        {
            
            _rigidbody.MovePosition(new Vector2(_rigidbody.position.x + offset, _rigidbody.position.y));
            yield return null;

        }
        yield break;
    }
}
