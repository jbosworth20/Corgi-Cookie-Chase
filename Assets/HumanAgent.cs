using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanAgent : MonoBehaviour {

	public Transform target;
	UnityEngine.AI.NavMeshAgent agent;
	Animator anim;
	Vector2 smooth = Vector2.zero;
    Vector2 velocity = Vector2.zero;

	// Use this for initialization
	void Start () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		agent.speed = 10;
		anim = GetComponent<Animator>();
		agent.updatePosition = false;
	}
	
	// Update is called once per frame
	void Update () {
        float rand = Random.Range(0, 1);
        if(rand == .003){

        }
		agent.SetDestination(target.position);
		
		Vector3 deltaPos = agent.nextPosition - transform.position;

        // Map 'deltaPos' to local space
        float dx = Vector3.Dot (transform.right, deltaPos);
        float dy = Vector3.Dot (transform.forward, deltaPos);
        Vector2 deltaPosition = new Vector2 (dx, dy);

        // Low-pass filter the deltaMove
        float s = Mathf.Min(1.0f, Time.deltaTime/0.15f);
        smooth = Vector2.Lerp (smooth, deltaPosition, s);

        // Update velocity if time advances
        if (Time.deltaTime > 1e-5f)
            velocity = smooth / Time.deltaTime;

        //bool shouldMove = velocity.magnitude > 0.5f && agent.remainingDistance > agent.radius;

		//print(agent.remainingDistance + ", " + (agent.transform.position - target.position).magnitude);

		//if( (agent.transform.position - target.position).magnitude <= 5){
		if (agent.remainingDistance <= 10) {
			if(anim.GetFloat("MoveSpeed") != 0){
				anim.SetFloat("MoveSpeed", 0f);
				anim.SetTrigger("Pickup");
                //Sound below this: For when human picks you up
                PlayAudio audio = FindObjectOfType<PlayAudio>();
                audio.PlayAtLocation(0, transform.position);
                //TODO: GAME OVER!
                //Sound below this: For when you lose
                PlayAudio loss_audio = FindObjectOfType<PlayAudio>();
                loss_audio.PlayAtLocation(3, transform.position);
            }
				
		}
		else{
			// Update move speed
        	anim.SetFloat ("MoveSpeed", Mathf.Abs(velocity.x) + Mathf.Abs(velocity.y));
		}
    }

    void OnAnimatorMove ()
    {
        // Update position to agent position
		if(anim.GetFloat("MoveSpeed") > 0)
        	transform.position = agent.nextPosition;
    }
}
