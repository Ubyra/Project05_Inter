using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [Header("Important Atributtes")]
    public MatchSystem Match;

    [Header("Spots")]
    public List<CardSpot> PlayerSpots;
    public List<CardSpot> EnemySpots;

    #region Update Methods

    private void Start()
    {
        FillMySpots();
    }

    [ContextMenu("Fill Spots")]
    public void FillMySpots()
    {
        PlayerSpots = new List<CardSpot>();

        if (PlayerSpots.Count > 0)
            PlayerSpots.Clear();

        var childs = GetComponentsInChildren<CardSpot>();

        foreach(CardSpot c in childs)
        {
            if (c.playerSpot)
                PlayerSpots.Add(c);
            else
                EnemySpots.Add(c);
        }
    }

    #endregion
}
