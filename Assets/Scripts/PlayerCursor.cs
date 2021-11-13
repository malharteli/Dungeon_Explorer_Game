using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCursor : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 inputVector = Vector2.zero;
    public GridLayout gridLayout;
    public Vector3Int cellLocation = Vector3Int.zero;
    public Vector3Int nextCellLocation = Vector3Int.zero;
    public Vector3 speechBubbleOffset = Vector3.zero;
    // Awake is called when first frame is updated
    void Awake()
    {
        if (!rb)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (!gridLayout)
        {
            transform.parent.GetComponentInParent<GridLayout>();
        }
        SnapToGrid();
    }

    // Update is called once per frame
    void Update()
    {
        inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        speechBubbleOffset = transform.position + new Vector3(1f, 1f, 3f);
        cellLocation = gridLayout.WorldToCell(transform.position);
    }

    void FixedUpdate()
    {
        SnapToGrid();
    }

    public void SnapToGrid()
    {
        nextCellLocation = new Vector3Int(cellLocation.x + (int)inputVector.x, cellLocation.y+  + (int)inputVector.y, cellLocation.z);
        Debug.Log(nextCellLocation);
        transform.position = gridLayout.CellToWorld(nextCellLocation);
    }
}
