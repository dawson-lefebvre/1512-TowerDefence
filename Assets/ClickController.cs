using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;
using Unity.AI.Navigation;

public class ClickController : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject TowerPrefab;
    [SerializeField] GameObject MinePrefab;

    int enemyPathMask = 1 << 3;
    int towerMask = 1 << 4;

    public void OnPointerClick(PointerEventData eventData)
    {
        NavMeshHit hit;
        RaycastResult raycastHit = eventData.pointerCurrentRaycast;
        NavMesh.SamplePosition(eventData.pointerCurrentRaycast.worldPosition, out hit, 0.1f, NavMesh.AllAreas);
        if (hit.mask == towerMask && eventData.button == PointerEventData.InputButton.Left)
        {
            Instantiate(TowerPrefab, hit.position, Quaternion.identity);
        }
        else if (hit.mask == enemyPathMask && eventData.button == PointerEventData.InputButton.Right)
        {
            Instantiate(MinePrefab, hit.position, Quaternion.identity);
        }
    }
}