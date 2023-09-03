using DG.Tweening;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private float flipDuration;

    private bool isFlipped;
    private bool isAnimating;
    
    private void OnMouseDown()
    {
        // if (isFlipped)
        // {
        //     transform.DORotate(new Vector3(0, 0, 0), flipDuration);
        // }
        // else
        // {
        //     transform.DORotate(new Vector3(0, 180, 0), flipDuration);
        // }
        if (!isAnimating)
        {
            var tween = transform.DORotate(new Vector3(0, isFlipped?0:180, 0), flipDuration);
            tween.OnComplete((() => isAnimating=false));
            isAnimating = true;
            isFlipped = !isFlipped;
        }

    }
}
