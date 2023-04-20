using UnityEngine;

public class PlaceableObject : MonoBehaviour
{
    private GameObject[] zonesPlacement;
    
    private void Awake()
    {
        zonesPlacement = GameObject.FindGameObjectsWithTag("Placement Zone");
    }

    public void OnGrab()
    {
        foreach (GameObject zone in zonesPlacement)
        {
            PlacementManager manager = zone.GetComponent<PlacementManager>();
            manager.SetZoneVisible(true);
        }
    }

    public void OnDrag()
    {
        // TODO :  Afficher le fant�me de l'objet    
    }

    public void OnRelease()
    {
        // TODO : Poser le pi�ge s'il est dans une position valide
        foreach (GameObject zone in zonesPlacement)
        {
            PlacementManager manager = zone.GetComponent<PlacementManager>();
            manager.SetZoneVisible(false);
        }
    }
}
