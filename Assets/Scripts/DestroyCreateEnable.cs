using UnityEngine;
using System.Collections;

public class DestroyCreateEnable : MonoBehaviour
{
    // tuhoaa gameobjektin asetetun ajan päästä
    public void DestoryGameObject(GameObject destroiableGameObject, float timer)
    {
        Destroy(destroiableGameObject, timer);
    }

    // luo gameobjektin haluttuun paikkaan
    public void CreateGO(GameObject newGameObject, Vector3 position)
    {
        Instantiate(newGameObject, position, Quaternion.identity);
    }

    // enabloi/disabloi objektin
    public void EnableGameContent(GameObject enablebleObject, string name, bool active)
    {
        enablebleObject = GameObject.Find(name);
        enablebleObject.SetActive(active);
    }

    public void EnableDisableContent(string name, bool active)
    {
        GameObject go = GameObject.Find(name);
        go.SetActive(active);
    }
}
