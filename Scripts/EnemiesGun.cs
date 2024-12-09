using UnityEngine;

public class EnemiesGun : MonoBehaviour
{
    [SerializeField] SpawnBullet spawnScript;
    [SerializeField] float timeDelay = 0f;
    [SerializeField] float repeatRate = 0f;
    private void Awake()
    {
        spawnScript = GetComponent<SpawnBullet>();
    }
    private void Start()
    {
        InvokeRepeating(nameof(Pasteher),timeDelay,repeatRate);
    }
    void OnDestroy()
    {
        CancelInvoke(nameof(Pasteher));
    }
    private void Pasteher()
    {
        spawnScript.Paste();
    }
}
