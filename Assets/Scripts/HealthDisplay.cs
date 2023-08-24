using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    public GameObject target;
    public GameObject Target { get => target;  set { target = value; init(); } }
    private IHealth health;
    private TextMeshProUGUI textMesh;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        init();
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = "Health: " + health.Health;
    }

    private void init()
    {
        health = target.GetComponent<IHealth>();
    }
}
