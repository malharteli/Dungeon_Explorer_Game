using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class HorizontalDistribute : MonoBehaviour
{
    public Card[] hand;
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        hand = GetComponentsInChildren<Card>();
        speed = GameManager.instance.gameSpeed;
        Debug.Log(GameManager.instance.gameSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        hand = GetComponentsInChildren<Card>();
        for (int i = 0; i< hand.Length; i++)
        {
            Vector3 nextTarget = new Vector3(-hand.Length + 2*i +transform.position.x, transform.position.y, transform.position.z);
            hand[i].transform.position = Vector3.MoveTowards(hand[i].transform.position, nextTarget, Time.deltaTime*speed);
        }
    }
}
