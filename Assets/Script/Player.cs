using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public float minigDuration = 0.5f;

    public AudioSource moveSound;
    public AudioSource mineSound;
    public AudioSource activateSound;

    private NavMeshAgent agent;
    private float minigTimer;
    public int minerals;

    public int Minerals { get { return minerals;   } }

    public void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Move the player");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                //transform.position = hit.point;
                agent.SetDestination(hit.point);
                moveSound.Play();
            }
        }
        //Make the minig timer work.
        minigTimer -= Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Station>() != null)
        {
            Station station = other.gameObject.GetComponent<Station>();
            if(!station.IsActive &&minerals>= station.requiredMinerals)
            {
                minerals -= station.requiredMinerals;
                station.Activate();
                activateSound.Play();
            }
        }
    }
    private void OnTriggerStay(Collider otherCollider)
    {
        if(otherCollider.gameObject.GetComponent<Rock>() != null)
        {
            Rock rock = otherCollider.gameObject.GetComponent<Rock>();
            //Debug.Log("Deberia funcionar Mine");
            if(minigTimer <= 0 &&rock.minerals>0)
            {
                minigTimer = minigDuration;
                minerals++;
                Debug.Log("Player now has: " + minerals + " minerals");
                rock.Mine();
                mineSound.Play();
            }
        }
    }
}
