using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class Tile : MonoBehaviour
{
    public GridLayout gridLayout;
    public Vector3Int cellLocation;
    public Vector3Int nextCellLocation;
    public Vector3 speechBubbleOffset = Vector3.zero;
    public bool selectionGlow = false;
    public Animator outlineAnimator;
    const string IDLE = "OutlineIdle";
    const string ACTIVE = "OutlineActive";

    public TileCardManager.StateEnum selectState = TileCardManager.StateEnum.Idle;
    // Start is called before the first frame update
    void Awake()
    {
        if (!gridLayout)
        {
            transform.parent.GetComponentInParent<GridLayout>();
        }
        cellLocation = gridLayout.WorldToCell(transform.position);
        SnapToGrid();
    }

    // Update is called once per frame
    void Update()
    {
        nextCellLocation = gridLayout.WorldToCell(transform.position);
        SnapToGrid();
        UpdateAnimator();
    }

    void OnMouseEnter()
    {
        Debug.Log("Mouse over " + cellLocation);
        selectionGlow = true;
        selectState = TileCardManager.StateEnum.Active;
    }

    void OnMouseExit()
    {
        selectionGlow = false;
        selectState = TileCardManager.StateEnum.Idle;
    }

    void UpdateAnimator()
    {
        if(outlineAnimator)
        {
            switch(selectState)
            {
                case TileCardManager.StateEnum.Idle:
                    outlineAnimator.PlayInFixedTime(IDLE);
                    break;
                case TileCardManager.StateEnum.Active:
                    outlineAnimator.PlayInFixedTime(ACTIVE);
                    break;
                default:
                    outlineAnimator.PlayInFixedTime(IDLE);
                    break;
            }
        }
    }

    public void SnapToGrid()
    {
        if (nextCellLocation != cellLocation)
        {
            transform.position = gridLayout.CellToWorld(nextCellLocation);
        }
        else 
        {
            transform.position = gridLayout.CellToWorld(cellLocation);
        }
        cellLocation = nextCellLocation;
    }

}
