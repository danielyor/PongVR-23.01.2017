using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    public float speed;
    Transform RacketUp;

    void Start() {
        // Initial Velocity
        GetComponent<Rigidbody>().velocity = Vector3.right * speed;
    }
    
    void Update() {
        if ( transform.position.x > 16.5f || transform.position.x < -16.5f ) {
            // reset ball position
            transform.position = new Vector3(0f, 1f, 0f);
            // reset speed
            speed = 20;          
            GetComponent<Rigidbody>().velocity = Vector3.right * speed;
            // reset ai position
            RacketUp = GameObject.FindGameObjectWithTag("RacketUp").transform;
            RacketUp.position = new Vector3(14.3f, 1f, 0f);
        }
    }

    float hitFactor(Vector3 ballPos, Vector3 racketPos,
                    float racketHeight) {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        return (ballPos.z - racketPos.z) / racketHeight;
    }

    void OnCollisionEnter(Collision col) {
        // Note: 'col' holds the collision information. If the
        // Ball collided with a racket, then:
        //   col.gameObject is the racket
        //   col.transform.position is the racket's position
        //   col.collider is the racket's collider
        
        // Hit the left Racket?
        if (col.gameObject.name == "RacketDown") {
            // increase ball speed
            speed++;

            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.z);

            // Calculate direction, make length=1 via .normalized
            Vector3 dir = new Vector3(1, 0, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody>().velocity = dir * speed;
        }

        // Hit the right Racket?
        if (col.gameObject.name == "RacketUp") {
            // increase ball speed
            speed++;
            
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.z);

            // Calculate direction, make length=1 via .normalized
            Vector3 dir = new Vector3(-1, 0, y).normalized;
            
            // Set Velocity with dir * speed
            GetComponent<Rigidbody>().velocity = dir * speed;
        }
    }

    public void ToggleVRMode()
    {
        GvrViewer.Instance.VRModeEnabled = !GvrViewer.Instance.VRModeEnabled;
    }
}
