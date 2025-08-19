using UnityEngine;

public class MB_PersistentHealthController : MonoBehaviour, IDamagable
{
    
    [SerializeField] private SO_FloatVariable health;
    [SerializeField] bool resetHealthInStart = true;
    [SerializeField] private FloatReference StartingHealth;
    [SerializeField] private bool disableOnZeroHealth = true;

    public void TakeDamage(float amount)
    {
        health.ApplyChange(-amount);
    }

    void Start()
    {
        if (resetHealthInStart)
        {
            health.SetValue(StartingHealth);
        }
    }
    void Update()
    {
        if (health.Value <= 0 && disableOnZeroHealth)
        {
            gameObject.SetActive(false);
        }
    }
}