using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public float floatingCardHeight = -2;
    public bool isSelected;
    public bool isFaceDown = false;

    private Vector2 mousePos = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelected)
        {
            SelectActive();
        }

        mousePos = Input.mousePosition;
    }

    void SelectActive()
    {
        Vector3 target = new Vector3(mousePos.x, mousePos.y, floatingCardHeight);
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime* GameManager.instance.gameSpeed);
    }
}
