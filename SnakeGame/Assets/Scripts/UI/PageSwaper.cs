using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*
 * Orginal code from Press start Link: https://pressstart.vip/tutorials/2019/05/15/95/swiping-pages-in-unity.html
 *
 *                          Adjusted to work with
 *                          -Vertical swapping,
 *                          -A ranged movement based on the number of chilled objects,
 *                          -Event trigger to move the screen,
 *                          -Set level based on panel selected
 */
namespace UI
{
    public class PageSwaper : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        private Vector3 _panelLocation;
        
        private float percentThreshold = 0.2f;
        private float easing = 0.5f;
        private int _panelIndex;
        private int _totalPanels;

        [SerializeField] private so_LevelManger _levelManger;
        [SerializeField] List<Transform> Panels;
        
        private void Start()
        {
            _panelIndex = 0;
            
            _totalPanels = transform.childCount;
            _panelLocation = transform.position;

        }

        public void OnDrag(PointerEventData eventData)
        {
            StopAllCoroutines();
            //Get the direction of the drag
            float differenceY = eventData.pressPosition.y - eventData.position.y;
            transform.position = _panelLocation - new Vector3(0, differenceY, 0);
        
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            float percentage = (eventData.pressPosition.y - eventData.position.y) / Screen.height;
            int tempIndex = _panelIndex;
            /*
         * Check that the drag amount is high enough to trigger changing the panel.
         */
            if (Mathf.Abs(percentage) >= percentThreshold) 
            {
                
                Vector3 newLocation = _panelLocation;
            
                if (percentage > 0)
                {
                    if (_panelIndex < _totalPanels - 1)
                    {
                        newLocation += new Vector3(0, -Screen.height, 0);
                        _panelIndex++;
                    }

                }
                else if(percentage < 0)
                {
                    if (_panelIndex > 0)
                    {
                        newLocation += new Vector3(0, Screen.height, 0);
                        _panelIndex--;
                    }

                }
            
                StartCoroutine(SmoothMove(transform.position, newLocation, easing));
                _panelLocation = newLocation;
            }
            else
            {
                StartCoroutine(SmoothMove(transform.position, _panelLocation, easing));
            }
            _levelManger.SetCurrentLevel(_panelIndex);
        }

        
        IEnumerator SmoothMove(Vector3 startPos, Vector3 endPos, float seconds)
        {
            float t = 0f;
            while (t < 1.0)
            {
                t += Time.deltaTime / seconds;
                transform.position = Vector3.Lerp(startPos, endPos, Mathf.SmoothStep(0, 1, t));
                yield return null;
            }
        }
    }
}
