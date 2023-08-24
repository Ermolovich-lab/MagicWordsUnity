using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellColor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private Cell cell;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        cell = GetComponent<Cell>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!cell.isCanPressed)
        {
            spriteRenderer.color = Color.green;
        }

        if (cell.isPressed)
        {
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, new Color(1, 1, 1, 0.5f), Time.deltaTime * 10);
        }
        else if(cell.isCanPressed)
            spriteRenderer.color = Color.white;

    }
}
