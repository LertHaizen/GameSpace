using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShopBuilding : MonoBehaviour
{
    public bool StatusBuy { get; private set; }

    public static int win_build = 0;

    [SerializeField] private ShopBuildingData[] buildingData;

    [Header("Hologram settings")]
    [SerializeField] private GameObject prefabHologram;
    [SerializeField] private LayerMask maskMoveHologram;

    private int indexBuyBuilding;
    private Construction hologramBuilding;
    private Transform transformHologram;
    
    public void BuyBuilding(int indexInShop)
    {
        if(Resurs.material >= buildingData[indexInShop].Cost)
        {
            indexBuyBuilding = indexInShop;

            if(StatusBuy)
            {
                hologramBuilding.InitializeHologram(buildingData[indexBuyBuilding]);
                Resurs.material -= buildingData[indexInShop].Cost; 
                return;
            }

            hologramBuilding = Instantiate(prefabHologram, Vector3.zero, Quaternion.identity).GetComponent<Construction>();
            hologramBuilding.InitializeHologram(buildingData[indexBuyBuilding]);


            transformHologram = hologramBuilding.transform;
            StatusBuy = true;
        }
    }

    public void MoveHologram()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, maskMoveHologram))
        {
            transformHologram.position = new Vector3(hitInfo.point.x, 1.0f, hitInfo.point.z);
        }
    }
    public void PurchaseBuilding()
    {
        StartCoroutine(AcceptBuing());
    }

    private IEnumerator AcceptBuing()
    {
        yield return new WaitForFixedUpdate();

        if(hologramBuilding.AcceptBuying())
        {
            Resurs.material -= buildingData[indexBuyBuilding].Cost;
            StatusBuy = false;
            win_build += 1;
            Debug.Log("Построилось");
            Debug.Log(win_build);
        }
    }

    public void CancelBuy()
    {
        StatusBuy = false;
        Destroy(hologramBuilding.gameObject);
        
    }

}
