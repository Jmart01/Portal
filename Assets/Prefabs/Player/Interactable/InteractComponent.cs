using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractComponent : MonoBehaviour
{
    List<Interactable> interactables = new List<Interactable>();

    [SerializeField] float InteractRadius = 2.4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*Interactable[] otherAsInteractable = FindObjectsOfType<Interactable>();}
        float DistanceFromPlayer = Vector3.Distance(otherAsInteractable.transform.position, this.gameObject.transform.position);
        if (DistanceFromPlayer < InteractRadius && !interactables.Contains(otherAsInteractable))
        {
            interactables.Add(otherAsInteractable);
        }
        else if (DistanceFromPlayer > InteractRadius && interactables.Contains(otherAsInteractable))
        {
            interactables.Remove(otherAsInteractable);
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        Interactable otherAsInteractable = other.GetComponent<Interactable>();
        if(otherAsInteractable)
        {
            if(!interactables.Contains(otherAsInteractable))
            {
                interactables.Add(otherAsInteractable);
            }
        }
    }



    private void OnTriggerExit(Collider other)
    {
        Interactable otherAsInteractable = other.GetComponent<Interactable>();
        if (otherAsInteractable)
        {
            if (interactables.Contains(otherAsInteractable))
            {
                interactables.Remove(otherAsInteractable);
            }
        }
    }


    public void Interact()
    {
        Interactable closestInteractable = GetClosestInteractable();
        if(closestInteractable != null)
        {
            closestInteractable.Interact(transform.parent.gameObject);
        }
    }

    Interactable GetClosestInteractable()
    {
        Interactable closestInteractable = null;
        if(interactables.Count == 0)
        {
            return closestInteractable;
        }

        float ClosestDist = float.MaxValue;
        foreach(var interactable in interactables)
        {
            float Dist = Vector3.Distance(transform.position, interactable.transform.position);
            if(Dist < ClosestDist)
            {
                closestInteractable = interactable;
                ClosestDist = Dist;
            }
        }
        return closestInteractable;
    }

}
