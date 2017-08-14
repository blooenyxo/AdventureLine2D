using UnityEngine;

public class Camera_Follow : MonoBehaviour {
   public GameObject target;
   public float followSpeed;

   private Vector3 temp_position;


   // Update is called once per frame
   void Update()
   {
      temp_position      = new Vector3(target.transform.position.x, target.transform.position.y, -15);
      transform.position = Vector3.Lerp(transform.position, temp_position, followSpeed * Time.deltaTime);
   }
}
