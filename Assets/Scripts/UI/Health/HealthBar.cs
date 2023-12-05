using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Heart _heartTemplate;

    private readonly List<Heart> _hearts = new();

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(float residue)
    {
        int necessaryHearts = (int)Math.Ceiling(residue);

        while(_hearts.Count < necessaryHearts)
        {
            CreateHeart();
        }

        foreach (Heart heart in _hearts)
        {
            heart.Change(Mathf.Min(1, residue));
            residue = Mathf.Max(--residue, 0);
        }
    }

    private void CreateHeart()
    {
        Heart newHeart = Instantiate(_heartTemplate, transform);
        _hearts.Add(newHeart.GetComponent<Heart>());
    }
}
