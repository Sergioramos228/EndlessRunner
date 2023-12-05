using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.ApplyDamage(_damage);
        }

        if (collision.TryGetComponent(out EndField endField))
        {
            endField.GetScore();
        }

        Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
