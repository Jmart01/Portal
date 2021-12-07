using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface Togglable
{
    void ToggleOn();
    void ToggleOff();
}

public class Door : MonoBehaviour, Togglable
{
    private DoorMoveComp[] _doorMoveComp;
    void Start()
    {
        _doorMoveComp = GetComponentsInChildren<DoorMoveComp>();
    }

    public void ToggleOn()
    {
        for (int i = 0; i < _doorMoveComp.Length; i++)
        {
            _doorMoveComp[i].MoveTo(true);
        }
    }

    public void ToggleOff()
    {
        for (int i = 0; i < _doorMoveComp.Length; i++)
        {
            _doorMoveComp[i].MoveTo(false);
        }
    }

}
