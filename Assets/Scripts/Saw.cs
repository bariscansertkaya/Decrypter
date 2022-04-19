using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Saw : MonoBehaviour
{
    [SerializeField] float rotateAmount;
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
        transform.Rotate(0, 0, rotateAmount*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            Instantiate(objectToSpawn, collision.gameObject.transform.position, Quaternion.identity);
            deathMenu.SetActive(true);
            audioManager.PlayDeathSound();
            Destroy(collision.gameObject);
        }
        
    }
}
