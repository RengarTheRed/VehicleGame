using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _score=0;

    public void IncreaseScore()
    {
        _score += 1;
    }
}
