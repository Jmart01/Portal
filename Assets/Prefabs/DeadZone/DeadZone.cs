using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour
{
    [SerializeField] Transform _playerStart;
    [SerializeField] Transform _artifactSpawn;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other.gameObject.name}");
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            ResetLevel();
            Debug.Log("Spawn new thing");
        }

        if (other.gameObject.CompareTag("Artifact"))
        {
            Destroy(other.gameObject);
            SpawnNewItem(other.gameObject, _artifactSpawn);
            Debug.Log("Spawn new thing");

        }
    }

    private void SpawnNewItem(GameObject SpawnItem, Transform SpawnTrans)
    {
        GameObject thingToSpawn = Instantiate(SpawnItem, SpawnTrans.position, SpawnTrans.rotation);
        Debug.Log($"Spawned new {thingToSpawn}, {SpawnTrans}");
    }

    private void ResetLevel()
    {
        SceneManager.LoadScene(0);
    }
}