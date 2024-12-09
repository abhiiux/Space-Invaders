using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] float yValue = 0f; 
    Vector3 location; 
    void Update()
    {
        location = GetComponent<Transform>().position;
        location += new Vector3(0f,yValue,0);
    }
    public void Paste()
    {
        Quaternion rotation = Quaternion.AngleAxis(90f,Vector3.forward);
        Instantiate(prefab,location,rotation);
    }    
}
