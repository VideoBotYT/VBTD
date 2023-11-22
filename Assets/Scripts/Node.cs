using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour{

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turret;

    private Renderer rend;
    private Color startColor;

    BuildMaster buildMaster;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildMaster = BuildMaster.instance;
    }

    public Vector3 GetBuildPosition ()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildMaster.CanBuild)
        {
            return;
        }

        if (turret != null)
        {
            Debug.Log("Can't build here bitch - MAKE IT ON SCREEN STUPID ASS");
            return;
        }

        buildMaster.BuildTurretOn(this);
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildMaster.CanBuild)
        {
            return;
        }

        if (buildMaster.HasMoney)
        {
            rend.material.color = hoverColor;
        }else
        {
            rend.material.color = notEnoughMoneyColor; 
        }
        
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}
