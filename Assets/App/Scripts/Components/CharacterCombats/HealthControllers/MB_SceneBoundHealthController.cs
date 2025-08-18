using System;
using UnityEngine;

public class MB_SceneBoundHealthController : MonoBehaviour, IDamagable
{
    private float _currentHealth;
    [SerializeField] private FloatReference StartingHealth;
    [SerializeField] private bool disableOnZeroHealth = true;
    public static Action OnDamageTakenHandler;

    private void Start()
    {
        _currentHealth = StartingHealth;
    }

    public void TakeDamage(float amount)
    {
        OnDamageTakenHandler?.Invoke();
        _currentHealth -= amount;
    }

    private void Update()
    {
        if (_currentHealth <= 0 && disableOnZeroHealth)
        {
            gameObject.SetActive(false);
        }
    }
}