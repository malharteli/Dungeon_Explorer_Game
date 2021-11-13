using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum Faction{
        Player,
        Dragon,
        Orc,
        OldOnes,
        Goblin,
        Bandits
    }
    public Card selectedCard;
    public float gameSpeed =1.0f; 
    
    private void Awake()
    {
        if(!instance)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance error, destroying object");
            Destroy(this);

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {

    }
}
