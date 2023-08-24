using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTimerController : MonoBehaviour
{
    public bool IsTimeOver { get; private set; } = false;
    private bool isStopTime = false;

    [SerializeField]
    private float moveTimer = 30;

    public float MoveTimer { get => moveTimer; }

    [SerializeField]
    private float speed = 1f;

    public float CurrTime { get; private set; } = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStopTime)
            CurrTime += Time.deltaTime * speed;

        if (CurrTime > moveTimer)
        {
            StopTime();
            IsTimeOver = true;
        }
    }

    public void ResetTime()
    {
        CurrTime = 0;
        IsTimeOver = false;
    }

    public void StopTime()
    {
        isStopTime = true;
    }

    public void PlayTime()
    {
        isStopTime = false;
    }
}
