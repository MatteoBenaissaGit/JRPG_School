using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ClickEffect : MonoBehaviour
{
    [SerializeField] [Range(0.0f, 5.0f)] private float _transformSizeMultiplicator;
    [SerializeField] [Range(0.0f, 5.0f)] private float _transformTime;

    private void Start()
    {
        transform.DOScaleX(transform.localScale.x* _transformSizeMultiplicator, _transformTime);
        transform.DOScaleY(transform.localScale.y* _transformSizeMultiplicator, _transformTime);
        GetComponent<SpriteRenderer>().DOFade(0, _transformTime);
        StartCoroutine(DestroyClickEffect());
    }

    private IEnumerator DestroyClickEffect()
    {
        yield return new WaitForSeconds(_transformTime);
        Destroy(gameObject);
    }
}
