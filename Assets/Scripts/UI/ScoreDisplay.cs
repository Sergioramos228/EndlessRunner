using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private TMP_Text _scoreDisplay;

    private void OnEnable()
    {
        _score.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _score.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _scoreDisplay.text = $"Score: {score}";
    }
}
