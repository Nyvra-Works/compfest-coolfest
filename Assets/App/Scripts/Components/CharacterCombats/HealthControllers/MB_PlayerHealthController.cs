using UnityEngine;

public class MB_PlayerHealthController : MonoBehaviour
{
    [SerializeField] private SO_FloatVariable health;
    [SerializeField] bool resetHealthInStart = true;
    [SerializeField] private FloatReference StartingHealth;

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
        if (health.Value <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}