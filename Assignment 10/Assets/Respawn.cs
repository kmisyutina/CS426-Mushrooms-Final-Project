using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RainDropEffect;

public class Respawn : MonoBehaviour
{
    public GameObject rain;

    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(PlayerToRespawn());
        }
    }

    IEnumerator PlayerToRespawn()
    {
        audioSource.Play();
        rain.GetComponent<RainCameraController>().Play();
        yield return new WaitForSeconds(0.5f);
        player.transform.position = respawnPoint.transform.position;
        player.transform.rotation = respawnPoint.transform.rotation;
    }
}
