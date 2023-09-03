using System;
using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Card prefab;
    [SerializeField] private Vector2Int boardSize;
    [SerializeField] private Vector2 cardSpacing;
    [SerializeField] private Sprite[] cardSprites;
    
    private void Start()
    {
        var cardList = new List<Card>();
        InstantiateCards(cardList);
        ShuffleCards(cardList);
    }

    private void ShuffleCards(List<Card> cardList)
    {
        cardList.Shuffle();
        var id = 0;
        for (int i = 0; i < cardList.Count; i += 2)
        {
            cardList[i].SetId(id, cardSprites[id]);
            cardList[i + 1].SetId(id, cardSprites[id]);
            id++;
        }
    }

    private void InstantiateCards(List<Card> cardList)
    {
        for (int x = 0; x < boardSize.x; x++)
        {
            for (int y = 0; y < boardSize.y; y++)
            {
                var position = new Vector3((x - (boardSize.x / 2)) * cardSpacing.x, (y - (boardSize.y / 2)) * cardSpacing.y,
                    0);
                var card = Instantiate(prefab);
                card.transform.position = position;
                cardList.Add(card);
            }
        }
    }
}
