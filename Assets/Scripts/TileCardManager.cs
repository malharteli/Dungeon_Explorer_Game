using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCardManager : MonoBehaviour
{
    public static TileCardManager instance;
    public enum StateEnum{
        Idle,
        Active
    } 
    public enum CardTypeEnum{
        Land,
        Action,
        Character
    }
    public enum ElementTypeEnum{
        Earth,
        Wind,
        Fire,
        Water,
        Lust
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
