using System.Collections.Generic;
using UnityEngine;

public class UnitLook : MonoBehaviour
{
    public GameObject[] BodyGroup;
    public GameObject[] FaceAccessoryGroup;
    public GameObject[] FaceHairGroup;
    public GameObject[] HandsGroup;
    public GameObject[] HeadGroup;
    public GameObject[] HeadAccessoryGroup;
    public GameObject[] HeadHairGroup;
    public GameObject[] LegsGroup;
    public int ToneCount;

    private int Tone;

    private void Awake()
    {
        Tone = Random.Range(0, ToneCount);

        SetGO(BodyGroup);
        
        if (Random.Range(0, 2) != 0) SetGO(FaceAccessoryGroup);
        if (Random.Range(0, 2) != 0) SetGO(FaceHairGroup);
        
        SetGO(HandsGroup);
        SetGO(HeadGroup);
        
        if (Random.Range(0, 2) != 0) SetGO(HeadAccessoryGroup);
        else SetGO(HeadHairGroup);
        
        SetGO(LegsGroup);
    }

    private void SetGO(GameObject[] GOGroup)
    {
        int Index = Random.Range(0, GOGroup.Length);

        GameObject GO = GOGroup[Index];
        UnitLookContainer Container = GO.GetComponent<UnitLookContainer>();
        int ContainerSectionCapacity = Container.ColorGroup.Length / ToneCount;
        
        Index = Container.ToneRelative ? Tone * ContainerSectionCapacity : 0;
        int IndexTo = Index + ContainerSectionCapacity;

        Index = Random.Range(Index, IndexTo);

        GO.GetComponent<SkinnedMeshRenderer>().SetMaterials(new List<Material>{ Container.ColorGroup[Index] });
        GO.SetActive(true);
    }
}
