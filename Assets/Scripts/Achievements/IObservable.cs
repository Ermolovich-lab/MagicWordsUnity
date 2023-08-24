using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObservable
{
    void RegisterObserver(IObserver o);
    void RemoveObserver(IObserver o);
    void NotifyObservers();
}
