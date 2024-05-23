using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construction : MonoBehaviour
{
    private bool canStartConstruction;

    private ShopBuildingData buildingData;
    
    [Header("Hologram color")]
    [SerializeField] private Color obstacleColor;
    [SerializeField] private Color noObstacleColor;

    [Header("Socket mesh")]
    [SerializeField] private GameObject socketMesh;
    [SerializeField] private Transform socketTransform;

    private Transform m_Transform;
    private BoxCollider m_BoxCollider;

    private MeshFilter socketMeshFilter;
    private MeshRenderer socketMeshRenderer;

    private void Awake()
    {
        m_Transform = GetComponent<Transform>();
        m_BoxCollider = GetComponent<BoxCollider>();

        socketMeshFilter = socketMesh.GetComponent<MeshFilter>();
        socketMeshRenderer = socketMesh.GetComponent<MeshRenderer>();
    }
    
    public void InitializeHologram(ShopBuildingData buildingData)
    {
        ComponentsSettings(buildingData.PrefabBuilding);

        this.buildingData = buildingData;

        StopAllCoroutines();
        StartCoroutine(CollisionDetect());
    }

    private IEnumerator ProcessConstruction()
    {
        StopCoroutine(CollisionDetect());

        float timerConstruction = buildingData.TimeConstruction;

        while(true)
        {
            timerConstruction -= Time.deltaTime;

            if (timerConstruction <= 0.0f)
            {
                Instantiate(buildingData.PrefabBuilding, m_Transform.position, Quaternion.identity);
                Destroy(gameObject);
                yield break;
            }

            yield return null;
        }
    }

    private IEnumerator CollisionDetect()
    {
        Collider[] _hitColliders = new Collider[2];
        
        while(true)
        {
            Vector3 boxColliderPosition = m_Transform.position + m_BoxCollider.center;

            if(Physics.OverlapBoxNonAlloc(boxColliderPosition, m_BoxCollider.size / 2, _hitColliders, Quaternion.identity) >=2)
            {
                SetColorHologram(obstacleColor);
                canStartConstruction = false;
            }
            else
            {
                SetColorHologram(noObstacleColor);
                canStartConstruction = true;
            }

            yield return new WaitForFixedUpdate();

        }
    }

    public bool AcceptBuying()
    {
        if(canStartConstruction)
        {
            StartCoroutine(ProcessConstruction());
            return true;
           
        }
        else
        {
            return false; 
        }
    }

    private void SetColorHologram(Color color)
    {
        socketMeshRenderer.material.color = color; 
        
    }

    private void ComponentsSettings(GameObject prefabBuilding)
    {
        m_BoxCollider.size = prefabBuilding.GetComponent<BoxCollider>().size;
        m_BoxCollider.center = prefabBuilding.GetComponent<BoxCollider>().center;

        GameObject buildingObject = prefabBuilding.GetComponentInChildren<MeshFilter>().gameObject;

        socketMeshFilter.sharedMesh = buildingObject.GetComponent<MeshFilter>().sharedMesh;

        Transform _transformBuilding = buildingObject.GetComponent<Transform>();
        socketTransform.localPosition = _transformBuilding.localPosition;
        socketTransform.localRotation = _transformBuilding.localRotation;
        socketTransform.localScale = _transformBuilding.localScale;
       
    }
}
