using System.Collections;
using UnityEngine;

public class CharacterDissolve : MonoBehaviour
{
    private Material _material;

    private float _fade = 1f;
    private bool _isDissolve;

    private void Awake()
    {
        _material = Resources.Load<Material>(@"Material/CharacterDissolve");
    }

    private void OnEnable()
    {
        _isDissolve = true;
        _material.SetFloat("_Fade", _fade);
    }


    public void RestartCharacter()
    {
        gameObject.SetActive(false);
        gameObject.SetActive(true);
    }

    public void Dissolve()
    {
        StartCoroutine(DissolveCharacter());
    }

    private IEnumerator DissolveCharacter()
    {
        var fade = _fade;
        while (_isDissolve)
        {
            fade -= Time.deltaTime;


            if (fade <= 0)
            {
                _isDissolve = false;
            }
            _material.SetFloat("_Fade", fade);
            yield return null;
        }

        RestartCharacter();
        yield break;
    }
}
