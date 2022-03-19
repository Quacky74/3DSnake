using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Player
{
    public class PlayerCharactor : MonoBehaviour
    {
        [SerializeField] float minBodayDis = 0.25f;
        [SerializeField] int MaxCollectableCount;
        [SerializeField] float CollisionBumpScale;
        
        [SerializeField] AudioSource levelUpAudio;
        [SerializeField] PlayerCollision collisionBump;
        
        [SerializeField] so_PlayerEvents playerEvents;
        [SerializeField] UI_PlayerBar playerBar;
        [SerializeField] so_CollectableController worldCollectableController;

        [SerializeField] private int maxPlayerLevel;
        
        public List<Transform> bodyParts;
        
        private List<Collectable> _playerCollectables;
        
        private int _currentPlayerLevel;
        private int _collectableCount;
        private bool _hasHitWall;
        
        private void OnEnable()
        {
            _currentPlayerLevel = 0;
            if (levelUpAudio == null)
            {
                levelUpAudio = GetComponent<AudioSource>();
            }
            
            bodyParts = new List<Transform> {this.transform};
            _playerCollectables = new List<Collectable>();
            _hasHitWall = false;
        }
    


        public void HitCollectable(Collectable pCollectable)
        {
            if (pCollectable.GetComponent<AudioSource>())
            {
                pCollectable.GetComponent<AudioSource>().Play();
            }
            

            if (pCollectable.isCollectable)
            {
                _collectableCount++;
                if (_collectableCount > MaxCollectableCount)
                {
                    _collectableCount = 0;
                    _playerCollectables.Add(pCollectable);
                    CreateBodayPart(pCollectable);
                }


                
                //Update the players UI
                playerBar.AddCount();
                playerBar.UpdateFillAmount();
                
                if (playerBar.CountCheck() && _currentPlayerLevel < maxPlayerLevel)
                {
                    levelUpAudio.Play();
                    playerBar.ResetCount();

                    _currentPlayerLevel++;
                    float currentXScale = collisionBump.GetComponent<Transform>().localScale.x;
                    Vector3 newScale = new Vector3(currentXScale + CollisionBumpScale,
                        collisionBump.GetComponent<Transform>().localScale.y,
                        collisionBump.GetComponent<Transform>().localScale.z);
                    collisionBump.GetComponent<Transform>().localScale = newScale;

                }
            

        
                // run the hit collectable event
                playerEvents.HitCollectable(pCollectable);
            
                //remove the collectable from the controller
                worldCollectableController.RemoveCollectable(pCollectable);
                pCollectable.DisableCollectable();
            }

        }

        void CreateBodayPart(Collectable pCollectable)
        {
            Vector3 spawnPos = GetBodySpawnPoint(bodyParts.Last().position);
            Transform newPart = (Instantiate(pCollectable.gameObject, spawnPos, bodyParts.Last().rotation) as GameObject).transform;
        
            newPart.GetComponent<Collectable>().isCollectable = false;
            newPart.tag = "Wall";
            bodyParts.Add(newPart);
        
        }

        Vector3 GetBodySpawnPoint(Vector3 lastBodyPoint)
        {
        
            float xpoint = 0, zpoint = 0;

            if (lastBodyPoint.x > 1)
            {
                xpoint = minBodayDis * -1.0f;
            }
            else
            {
                xpoint = minBodayDis;
            }
        
            if (lastBodyPoint.z > 1)
            {
                zpoint = minBodayDis * -1.0f;
            }
            else
            {
                zpoint = minBodayDis;
            }
        
            return new Vector3(lastBodyPoint.x + xpoint, lastBodyPoint.y, lastBodyPoint.z + zpoint);
        }

        public void HitWall()
        {
            if (!_hasHitWall)
            {
                _hasHitWall = true;
            
                playerEvents.HitWall();
                playerEvents.GameOver(_playerCollectables, false);
            }

        }

        public List<Collectable> GetCollectables()
        {
            return _playerCollectables;
        }
    }
}
