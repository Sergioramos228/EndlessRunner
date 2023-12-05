using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Heart : MonoBehaviour
{
    [SerializeField] private float _lerpSpeed;

    private float _fill = 0;
    private Coroutine _changing;
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.fillAmount = 0;
    }

    public void Change(float value)
    {
        if (_changing != null)
        {
            StopCoroutine(_changing);
        }
        _changing = StartCoroutine(Filling(value));
    }

    private IEnumerator Filling(float endValue)
    {
        while (_fill != endValue)
        {
            _fill = Mathf.Lerp(_fill, endValue, Time.deltaTime * _lerpSpeed);
            _image.fillAmount = _fill;
            yield return null;
        }

        _changing = null;
    }
}
