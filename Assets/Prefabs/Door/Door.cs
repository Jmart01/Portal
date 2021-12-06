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
    private DoorMoveComp _doorMoveComp;
    void Start()
    {
        _doorMoveComp = GetComponent<DoorMoveComp>();
    }

    public void ToggleOn()
    {
        _doorMoveComp.MoveTo(true);
    }

    public void ToggleOff()
    {
        _doorMoveComp.MoveTo(false);
    }

}
