using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPose : MonoBehaviour
{
    [SerializeField] List<Sprite> charPose;
    [SerializeField] Sprite charLose;

    SpriteRenderer sprite;

    int poseIndex;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        poseIndex = 0;
    }

    public void GetPoseCharacter()
    {
        poseIndex += 1;
        if (poseIndex >= charPose.Count)
        {
            poseIndex = 0;
        }
        sprite.sprite = charPose[poseIndex];
    }

    public void GetPoseCharacterLose()
    {
        sprite.sprite = charLose;
    }
}
