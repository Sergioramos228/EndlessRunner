using UnityEngine;

[RequireComponent(typeof(Score))]
public class EndField : MonoBehaviour
{
    [SerializeField] private int _step;
    [SerializeField] private float _restoreHeal;
    [SerializeField] private Player _player;

    private int _nextStepToHeal;
    private Score _score;

    private void Start()
    {
        _score = GetComponent<Score>();
        _nextStepToHeal = _step;

        if (_step == 0)
            _step = 10;

        if (_restoreHeal == 0)
            _restoreHeal = 1;
    }

    public void GetScore()
    {
        _score.Apply();

        if (_score.Value == _nextStepToHeal)
        {
            _player.ApplyHeal(_restoreHeal);
            _nextStepToHeal += _step;
        }
    }
}
