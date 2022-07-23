using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CharacterRandomizer : MonoBehaviour
{
    #region Character's spriteRenderers

    [SerializeField] 
    private SpriteRenderer _rogueFace, _rogueHood, _rogueElbowLeft, _rogueElbowRight,
        _rogueShoulderLeft, _rogueShoulderRight, _rogueWristLeft, _rogueWristRight,
        _rogueTorso, _roguePelvis, _rogueLegLeft, _rogueLegRight, 
        _rogueBootLeft, _rogueBootRight;
    #endregion

    #region Character's sprites
    private Sprite[] _faces, _hoods, _elbowsLeft, _elbowsRight, 
        _shouldersLeft, _shouldersRight, _wristsLeft, _wristsRight, 
        _torsos, _pelvises, _legsLeft, _legsRight, 
        _bootsLeft, _bootsRight;
    #endregion

    private Dictionary<SpriteRenderer, Sprite[]> _spritesDirectories;

    private void Awake()
    {
        LoadResources();

        _spritesDirectories = new Dictionary<SpriteRenderer, Sprite[]>
        {

            {_rogueFace, _faces},
            {_rogueHood, _hoods},

            {_rogueElbowLeft, _elbowsLeft},
            {_rogueElbowRight, _elbowsRight},
            {_rogueShoulderLeft, _shouldersLeft},
            {_rogueShoulderRight, _shouldersRight},
            {_rogueWristLeft,_wristsLeft},
            {_rogueWristRight, _wristsRight},

            {_rogueTorso, _torsos},
            {_roguePelvis, _pelvises},

            {_rogueLegLeft, _legsLeft},
            {_rogueLegRight, _legsRight},
            {_rogueBootLeft, _bootsLeft},
            {_rogueBootRight, _bootsRight}
        };
    }

    private void OnEnable()
    {
        RandomizeCharacter();
    }
    private void LoadResources() // need more concise solution
    {
        _faces = Resources.LoadAll<Sprite>(@"Rogue/Rogue_face");
        _hoods = Resources.LoadAll<Sprite>(@"Rogue/Rogue_hood");

        _elbowsLeft = Resources.LoadAll<Sprite>(@"Rogue/Rogue_elbow_l");
        _elbowsRight = Resources.LoadAll<Sprite>(@"Rogue/Rogue_elbow_r");
        _shouldersLeft = Resources.LoadAll<Sprite>(@"Rogue/Rogue_shoulder_l");
        _shouldersRight = Resources.LoadAll<Sprite>(@"Rogue/Rogue_shoulder_r");
        _wristsLeft = Resources.LoadAll<Sprite>(@"Rogue/Rogue_wrist_l");
        _wristsRight = Resources.LoadAll<Sprite>(@"Rogue/Rogue_wrist_r");

        _torsos = Resources.LoadAll<Sprite>(@"Rogue/Rogue_torso");
        _pelvises = Resources.LoadAll<Sprite>(@"Rogue/Rogue_pelvis");

        _legsLeft = Resources.LoadAll<Sprite>(@"Rogue/Rogue_leg_l");
        _legsRight = Resources.LoadAll<Sprite>(@"Rogue/Rogue_leg_r");
        _bootsLeft = Resources.LoadAll<Sprite>(@"Rogue/Rogue_boot_l");
        _bootsRight = Resources.LoadAll<Sprite>(@"Rogue/Rogue_boot_r");
    }

    public void RandomizeCharacter()
    {
        RandomizeSinglePart(_rogueFace);
        RandomizeSinglePart(_rogueHood);

        RandomizeDoubleParts(_rogueElbowLeft, _rogueElbowRight);
        RandomizeDoubleParts(_rogueShoulderLeft, _rogueShoulderRight);
        RandomizeDoubleParts(_rogueWristLeft, _rogueWristRight);

        RandomizeDoubleParts(_rogueTorso, _roguePelvis);

        RandomizeDoubleParts(_rogueLegLeft, _rogueLegRight);
        RandomizeDoubleParts(_rogueBootLeft, _rogueBootRight);
    }

    private void RandomizeSinglePart(SpriteRenderer spriteRenderer)
    {
        _spritesDirectories.TryGetValue(spriteRenderer, out Sprite[] sprites);

        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
    }

    private void RandomizeDoubleParts(SpriteRenderer firstSpriteRenderer, SpriteRenderer secondSpriteRenderer)
    {
        _spritesDirectories.TryGetValue(firstSpriteRenderer, out Sprite[] firstSprites);
        _spritesDirectories.TryGetValue(secondSpriteRenderer, out Sprite[] secondSprites);

        if(firstSprites.Length == secondSprites.Length)
        {
            int spritesNumber = Random.Range(0, firstSprites.Length);

            firstSpriteRenderer.sprite = firstSprites[spritesNumber];
            secondSpriteRenderer.sprite = secondSprites[spritesNumber];
        }

        else
            throw new ArgumentException("Sprite arrays have different lengths");
    }

}
