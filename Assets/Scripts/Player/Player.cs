using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;

    public float MaxHealth { get; private set; }
    public event UnityAction<float> HealthChanged;
    public event UnityAction Died;

    private void Start()
    {
        HealthChanged?.Invoke(_health);
        MaxHealth = _health;
    }

    public void ApplyDamage(float damage)
    {
        if (damage < 0)
            return;

        _health -= damage;
        HealthChanged?.Invoke(_health);

        if (_health <= 0)
            Die();
    }

    public void ApplyHeal(float heal)
    {
        if (heal <= 0 || _health >= MaxHealth)
            return;

        _health += heal;
        _health = Mathf.Clamp(_health, 0, MaxHealth);
        HealthChanged?.Invoke(_health);
    }

    public void Die()
    {
        Died?.Invoke();
    }
}
