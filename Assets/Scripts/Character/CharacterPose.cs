using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPose : MonoBehaviour
{
    [SerializeField] List<Sprite> charPose;
    [SerializeField] Sprite charLose;

    SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void GetPoseCharacter(int poseIndex)
    {
        for (int i = 0; i < charPose.Count; i++)
        {
            if(i == poseIndex)
            {
                sprite.sprite = charPose[i];
            }
        }
    }

    public void GetPoseCharacterLose()
    {
        sprite.sprite = charLose;
    }
}
