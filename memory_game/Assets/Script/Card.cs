using System;
using DG.Tweening;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private float flipDuration;
    [SerializeField] private SpriteRenderer spriteRenderer;
    

    public int id;
    
    private bool isFlipped;
    private bool isAnimating;

    private void Start()
    {
        isFlipped = true;
        transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    private void OnMouseDown()
    {
        if (!isAnimating)
        {
            var tween = transform.DORotate(new Vector3(0, isFlipped?0:180, 0), flipDuration);
            tween.OnComplete((() => isAnimating=false));
            isAnimating = true;
            isFlipped = !isFlipped;
        }

    }

    public void SetId(int id, Sprite sprite)
    {
        this.id = id;
        spriteRenderer.sprite = sprite;
    }
}
