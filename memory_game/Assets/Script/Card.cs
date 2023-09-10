using System;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private float flipDuration;
    [SerializeField] private SpriteRenderer spriteRenderer;

    public int id { get; private set; }

    private Action<Card> onCardFlipped;
    private bool isFaceDown;
    private bool isAnimating;

    private void Start()
    {
        isFaceDown = true;
        transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    private void OnMouseDown()
    {
        if (isFaceDown)
        {
            FlipCard(false);
        }
    }

    public void FlipCard(bool faceDown)
    {
        if (!isAnimating)
        {
            isFaceDown = faceDown;
            var tween = transform.DORotate(new Vector3(0, !isFaceDown?0:180, 0), flipDuration);
            tween.OnComplete(() =>
            {
                isAnimating = false;
                if (!faceDown)
                {
                    onCardFlipped?.Invoke(this);
                }
            });
            isAnimating = true;
        }
    }

    public void Init(int id, Sprite sprite, Action<Card> onCardFlipped)
    {
        this.id = id;
        spriteRenderer.sprite = sprite;

        this.onCardFlipped = onCardFlipped;
    }
}
