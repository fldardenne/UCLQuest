using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swiper : MonoBehaviour
{
 public Transform target;
    public Camera cam ;
     public float distance = 2.0f;
     public float xSpeed = 20.0f;
     public float ySpeed = 20.0f;
     public float yMinLimit = -90f;
     public float yMaxLimit = 90f;
     public float distanceMin = 10f;
     public float distanceMax = 10f;
     public float smoothTime = 2f;
     float rotationYAxis = 0.0f;
     float rotationXAxis = 0.0f;
     float velocityX = 0.0f;
     float velocityY = 0.0f;
     public Touch touch;
     // Use this for initialization
     void Start()
     {
         Vector3 angles = cam.transform.eulerAngles;
         rotationYAxis = angles.y;
         rotationXAxis = angles.x;
         // Make the rigid body not change rotation
         if (GetComponent<Rigidbody>())
         {
             GetComponent<Rigidbody>().freezeRotation = true;
         }
     }
     void LateUpdate()
     {
         if (target)
         {
             if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
             {
                 touch = Input.GetTouch(0);
                 velocityX += xSpeed * touch.deltaPosition.x * 0.02f;
                 //velocityY += ySpeed * touch.deltaPosition.y * 0.02f;
             }
             rotationYAxis += velocityX;
             rotationXAxis -= velocityY;
             rotationXAxis = ClampAngle(rotationXAxis, yMinLimit, yMaxLimit);
             Quaternion fromRotation = Quaternion.Euler(cam.transform.rotation.eulerAngles.x, cam.transform.rotation.eulerAngles.y, 0);
             Quaternion toRotation = Quaternion.Euler(rotationXAxis, rotationYAxis, 0);
             Quaternion rotation = toRotation;
 
             distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);
             RaycastHit hit;
             if (Physics.Linecast(target.position, cam.transform.position, out hit))
             {
                 distance -= hit.distance;
             }
             Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
             Vector3 position = rotation * negDistance + target.position;
 
             cam.transform.rotation = rotation;
             cam.transform.position = position;
             velocityX = Mathf.Lerp(velocityX, 0, Time.deltaTime * smoothTime);
             velocityY = Mathf.Lerp(velocityY, 0, Time.deltaTime * smoothTime);
         }
     }
     public static float ClampAngle(float angle, float min, float max)
     {
         if (angle < -360F)
             angle += 360F;
         if (angle > 360F)
             angle -= 360F;
         return Mathf.Clamp(angle, min, max);
     }
}

