using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    public CardSystem[] card;
    public bool randomizeCards;

    public CardConfig[] configs;

    private void Awake()
    {
        if (randomizeCards) Randomize();
    }

    public void Randomize()
    {
        foreach (CardSystem c in card)
        {
            c.cardConfig = configs[Random.Range(0, configs.Length)];
        }
    }
}
