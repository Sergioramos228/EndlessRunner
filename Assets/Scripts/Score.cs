using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    public event UnityAction<int> ScoreChanged;
    public int Value { get; private set; }

    private void Start()
    {
        ScoreChanged?.Invoke(Value);
    }

    public void Apply()
    {
        Value++;
        ScoreChanged?.Invoke(Value);
    }
}
