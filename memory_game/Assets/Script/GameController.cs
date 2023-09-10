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
    
    private enum BoardState
    {
        noCardFlipped,
        oneCardFlipped,
        endGame
    }
    private BoardState boardState;
    private Card flippedCard;
    
    private void Start()
    {
        var cardList = new List<Card>();
        InstantiateCards(cardList);
        ShuffleCards(cardList);
        boardState = BoardState.noCardFlipped;
    }

    private void ShuffleCards(List<Card> cardList)
    {
        cardList.Shuffle();
        for (int i = 0; i < cardList.Count; i ++)
        {
            var id = i / 2;
            cardList[i].Init(id, cardSprites[id], OnCardFlipped);
        }
    }

    private void OnCardFlipped(Card card)
    {
        Debug.Log($"Carta {card.id} virou");
        switch (boardState)
        {
            case BoardState.noCardFlipped:
                boardState = BoardState.oneCardFlipped;
                flippedCard = card;
                break;
            case BoardState.oneCardFlipped:
                if (card.id == flippedCard.id)
                {
                    Debug.Log("Cartas sao iguais");
                }
                else
                {
                    Debug.Log("Cartas diferentes");
                    card.FlipCard(true);
                    flippedCard.FlipCard(true);
                }
                boardState = BoardState.noCardFlipped;
                flippedCard = null;
                break;
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
