using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckButtonPressed : MonoBehaviour
{
    public LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 positiomMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hitInfo = Physics2D.Raycast(positiomMouse, Vector2.zero, mask);

            if(hitInfo.collider != null)
                hitInfo.collider.GetComponent<IPressed>().Press();
        }
    }
}
