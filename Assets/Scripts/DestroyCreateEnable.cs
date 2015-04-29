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

    // enabloi gameobject tagin avulla
    // ei toimi, älä käytä
    public void EnableGameContent(GameObject enablebleObject, string tag)
    {
        enablebleObject = GameObject.FindGameObjectWithTag(tag);
        enablebleObject.SetActive(true);
    }
}
