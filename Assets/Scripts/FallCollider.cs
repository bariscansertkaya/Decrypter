using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallCollider : MonoBehaviour
{
    AudioManager audioManager;
    [SerializeField]GameObject deathMenu;
    [SerializeField] GameObject objectToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(objectToSpawn, collision.transform.position, Quaternion.identity);
        deathMenu.SetActive(true);
        audioManager.PlayDeathSound();
        Destroy(collision.gameObject);
    }
}
