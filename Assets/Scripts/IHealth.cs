using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    float Health { get; }

    void AddHealth(float value);
    void RemoveHealth(float value);
}
