using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]

public class Coin : MonoBehaviour
{
    [SerializeField] private float _sleepTime;

    private SpriteRenderer _spriteRenderer;
    private Collider2D _collider;

    private WaitForSeconds _sleepTimer;

    private void Awake()
    {
        _sleepTimer = new WaitForSeconds(_sleepTime);
        _collider = GetComponent<Collider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Respawn()
    {
        StartCoroutine(Respawning());
    }

    private IEnumerator Respawning()
    {
        _collider.enabled = false;
        _spriteRenderer.enabled = false;

        yield return _sleepTimer;

        _spriteRenderer.enabled = true;
        _collider.enabled = true;
    }
}