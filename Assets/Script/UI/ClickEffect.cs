using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ClickEffect : MonoBehaviour
{
    [SerializeField] [Range(0.0f, 5.0f)] private float TransformSizeMultiplicator;
    [SerializeField] [Range(0.0f, 5.0f)] private float TransformTime;

    private void Start()
    {
        transform.DOScaleX(transform.localScale.x*TransformSizeMultiplicator, TransformTime);
        transform.DOScaleY(transform.localScale.y*TransformSizeMultiplicator, TransformTime);
        GetComponent<SpriteRenderer>().DOFade(0, TransformTime);
        StartCoroutine(DestroyClickEffect());
    }

    private IEnumerator DestroyClickEffect()
    {
        yield return new WaitForSeconds(TransformTime);
        Destroy(gameObject);
    }
}
