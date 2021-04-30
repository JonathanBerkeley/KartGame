using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;

public class KartAi : MonoBehaviour
{
    public GameObject checkpointParent;

    private List<Transform> checkpoints = new List<Transform>();
    private List<Transform> initialCheckpoints = new List<Transform>();
    private ArcadeKart botKart;
    private Rigidbody botBody;
    void Start()
    {
        botBody = gameObject.GetComponent<Rigidbody>();
        botKart = gameObject.GetComponent<ArcadeKart>();

        foreach (Transform c in checkpointParent.GetComponentsInChildren<Transform>())
        {
            checkpoints.Add(c);
        }
        initialCheckpoints = checkpoints;
        botBody.AddExplosionForce(10.0f, botBody.transform.position, 1.0f);
    }

    void Update()
    {
        
        botBody.AddForce(transform.forward * 1000.0f);
    }

    Transform GetClosestCheckpoint()
    {
        Transform closestCheckpoint = null;
        float dist = Mathf.Infinity;
        Vector3 thisPos = transform.position;
        foreach(Transform go in checkpoints)
        {
            Vector3 directionToCheckpoint = go.position - thisPos;
            float distSqred = directionToCheckpoint.sqrMagnitude;

            if (distSqred < dist)
            {
                dist = distSqred;
                closestCheckpoint = go;
            }
        }

        return closestCheckpoint;
    }

    public void SetLook()
    {
        Transform closest = GetClosestCheckpoint();
        
        Vector3 toLook = closest.position;
        Vector3 shiftView = new Vector3(
            toLook.x + Random.Range(-3.0f, 3.0f),
            gameObject.transform.position.y,
            toLook.z + Random.Range(-3.0f, 3.0f)
        );

        StartCoroutine(RemoveOnTime(closest));

        transform.LookAt(shiftView);
    }

    IEnumerator RemoveOnTime(Transform _closest)
    {
        yield return new WaitForSeconds(0.3f);
        checkpoints.Remove(_closest);
    }
}
