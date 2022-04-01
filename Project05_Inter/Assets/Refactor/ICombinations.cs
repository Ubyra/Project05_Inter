using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICombinations
{
    public int CheckCombinationOne (List<GameObject> cards);
    public int CheckCombinationTwo (List<GameObject> cards);
    public int CheckCombinationThree (List<GameObject> cards);
    public int CheckCombinationFour (List<GameObject> cards);
    public int CheckCombinationFive (List<GameObject> cards);
}
