using UnityEngine;

namespace Player
{
    public class PlayerCollision : MonoBehaviour
    {
        [SerializeField] private PlayerCharactor _charactor;

        private void OnEnable()
        {
            if (_charactor == null)
            {
                _charactor = GetComponentInParent<PlayerCharactor>();   
            }
        }
    
    
        private void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.GetComponent<Collectable>())
            {
                _charactor.HitCollectable(other.gameObject.GetComponent<Collectable>());
            }

            //TODO: Find another way to check if the player has hit the wall
            if (other.CompareTag("Wall"))
            {
                _charactor.HitWall();
            }
        
        }
    
    
    
    }
}
