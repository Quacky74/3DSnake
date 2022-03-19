using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace Player
{
    public class Movement : MonoBehaviour
    {
        public float speed;
        public float rotationSpeed;
        public float minDistance;

        public GameObject Arrow;
        
        public FloatingJoystick joystick;
        public PlayerCharactor playerCharactor;
        public so_PlayerEvents playerEvents;
        private bool _canMove;
        
        private void OnEnable()
        {
            playerCharactor = GetComponentInParent<PlayerCharactor>();
            playerEvents.OnHitWall += DisableMovement;
            _canMove = true;
        }

        private void FixedUpdate()
        {
            MoveBody(rotationSpeed * new Vector3( joystick.Horizontal, 0, joystick.Vertical));
        }

        void DisableMovement()
        {
            _canMove = false;
            if (joystick != null)
            {
                joystick.gameObject.SetActive(false);
            }
            
        }
        
        void MoveBody(Vector3 direction)    
        {
            if (direction != Vector3.zero)
            {          
              Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
              
              Arrow.transform.rotation = Quaternion.RotateTowards(Arrow.transform.rotation, toRotation, 10);

             // transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed);

            }
            
            transform.Translate(Vector3.forward * (speed * Time.deltaTime));
           

            for (int i = 1; i < playerCharactor.bodyParts.Count; i++)
            {
                Transform curBodyPart = playerCharactor.bodyParts[i];
                Transform prevBodyPart = playerCharactor.bodyParts[i - 1];
           
            
                float dis = Vector3.Distance(prevBodyPart.position,curBodyPart.position);
                Vector3 newpos = prevBodyPart.position;
            
                newpos.y = playerCharactor.bodyParts[0].position.y;
            
                float T = Time.deltaTime * dis / minDistance * speed;
    
                if (T > 0.5f)
                    T = 0.5f;
            
                curBodyPart.position = Vector3.Slerp(curBodyPart.position, newpos, T);
                curBodyPart.rotation = Quaternion.Slerp(curBodyPart.rotation, prevBodyPart.rotation, T);    
            }

        }
        

    }
}
