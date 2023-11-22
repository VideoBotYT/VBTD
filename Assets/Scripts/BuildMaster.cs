using UnityEngine;

public class BuildMaster : MonoBehaviour{

    public static BuildMaster instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than 1 BuildMaster in scene!");
            return;
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;

    public GameObject buildEffect;

    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void BuildTurretOn (Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.LogError("Money:" + PlayerStats.Money);
    }

    public void SelectTurretToBuild (TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
    
}
