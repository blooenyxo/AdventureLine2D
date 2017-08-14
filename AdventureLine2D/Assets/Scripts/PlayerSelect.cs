using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
   public GameObject wizzard_normal;
   public GameObject wizzard_fire;
   public GameObject wizzard_ice;
   public float followSpeed;
   private GameObject target;
   private Vector3 temp_position;

   // Use this for initialization
   void Start()
   {
      wizzard_normal = GameObject.Find("wizzard_normal");
      wizzard_fire   = GameObject.Find("wizzard_fire");
      wizzard_ice    = GameObject.Find("wizzard_ice");

      wizzard_normal.GetComponent<PlayerInput>().selectedUnit = true;
      target = wizzard_normal;
   }

   // Update is called once per frame
   void Update()
   {
      if (Input.GetKeyDown(KeyCode.Alpha1))

      {
         wizzard_normal.GetComponent<PlayerInput>().selectedUnit = true;
         wizzard_fire.GetComponent<PlayerInput>().selectedUnit   = false;
         wizzard_ice.GetComponent<PlayerInput>().selectedUnit    = false;
         target = wizzard_normal;
      }
      if (Input.GetKeyDown(KeyCode.Alpha2))
      {
         wizzard_normal.GetComponent<PlayerInput>().selectedUnit = false;
         wizzard_fire.GetComponent<PlayerInput>().selectedUnit   = true;
         wizzard_ice.GetComponent<PlayerInput>().selectedUnit    = false;
         target = wizzard_fire;
      }
      if (Input.GetKeyDown(KeyCode.Alpha3))
      {
         wizzard_normal.GetComponent<PlayerInput>().selectedUnit = false;
         wizzard_fire.GetComponent<PlayerInput>().selectedUnit   = false;
         wizzard_ice.GetComponent<PlayerInput>().selectedUnit    = true;
         target = wizzard_ice;
      }

      temp_position      = new Vector3(target.transform.position.x, target.transform.position.y, gameObject.transform.position.z);
      transform.position = Vector3.Lerp(gameObject.transform.position, temp_position, followSpeed * Time.deltaTime);
   }
}
