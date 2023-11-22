using UnityEngine;

public class Shop : MonoBehaviour{

    public TurretBlueprint standardTurret;

    BuildMaster buildMaster;

    void Start()
    {
        buildMaster = BuildMaster.instance;
    }

    public void SelectStandardTurret()
    {
        buildMaster.SelectTurretToBuild(standardTurret);
    }

}
