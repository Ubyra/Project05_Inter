using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDeck : Deck
{
    #region Métodos iniciais

    private void Awake()
    {
        areaCollider = GetComponent<Collider>();
    }

    private void Start()
    {
        Card = new List<GameObject>();
        Shuffle();
    }

    private void Update()
    {
    }

    #endregion

    #region Métodos override

    [ContextMenu("Fill Deck")]
    public override void FillDeck()
    {
        string debug = "";

        if (Card.Count > 0)
            Card.Clear();

        var childs = GetComponentsInChildren<CardSystem>();

        debug += "- Start Fill Deck \n";

        foreach(CardSystem card in childs)
        {
            Card.Add(card.gameObject);
        }

        debug += "-- Fill Deck Complete \n";
        debug += "[Deck Filled] \n";

        Debug.Log(debug);
        FillDeckConfigs();
    }

    [ContextMenu("Shuffle")]
    public override void Shuffle()
    {
        string debug = "";

        FillDeck();

        List<CardSystem> currentCardConfigs = new List<CardSystem>();
        List<CardConfig> newOrder = new List<CardConfig>();

        foreach (GameObject g in Card)
        {
            currentCardConfigs.Add(g.GetComponent<CardSystem>());
        }

        int randomNumber = (int)Random.Range(0, currentCardConfigs.Count);
        List<int> numberAlreadySorted = new List<int>();

        debug += "- Start Shuffle \n";

        while (numberAlreadySorted.Count != currentCardConfigs.Count)
        {
            if (!ExistNumberInArray(randomNumber, numberAlreadySorted))
            {
                numberAlreadySorted.Add(randomNumber);
                newOrder.Add(currentCardConfigs[randomNumber].Config);
            }
            else
                randomNumber = (int)Random.Range(0, currentCardConfigs.Count);
        }

        debug += "-- Shuffle Complete \n";

        for (int i = 0; i < Card.Count; i++)
        {
            Card[i].GetComponent<CardSystem>().Config = newOrder[i];
        }

        debug += "[Cards Shuffled]";
        Debug.Log(debug);
    }

    public override void DrawCard(Transform t)
    {
        Transform child = transform.GetChild(0);

        child.SetParent(t, true);
        Card.Remove(Card[0]);
    }

    #endregion

    #region Métodos Suporte

    private void FillDeckConfigs()
    {
        string debug = "";

        var rawConfigs = Resources.LoadAll("CardsConfigs", typeof(CardConfig));
        List<CardConfig> configs = new List<CardConfig>();

        foreach(Object a in rawConfigs)
        {
            configs.Add((CardConfig)a);
        }

        debug += "- Start Fill Deck Configs \n";

        for (int i = 0; i < Card.Count; i++)
        {
            Card[i].GetComponent<CardSystem>().Config = configs[i];
        }

        debug += "-- Fill Deck Configs Complete \n";
        debug += "[Deck Configs Filled] \n";
        Debug.Log(debug);

        UpdateUiElements();
    }

    private void UpdateUiElements()
    {
        foreach (GameObject g in Card)
        {
            g.GetComponent<CardSystem>().UIElements.UpdateElements();
        }
    }

    private bool ExistNumberInArray(int number, List<int> array)
    {
        for (int i = 0; i < array.Count; i++)
        {
            if (number == array[i])
            {
                return true;
            }
        }

        return false;
    }

    #endregion
}