using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;
using UnityEngine.PlayerLoop;
using LevelManagment;

public class CharacterSelectMenu : Menu<CharacterSelectMenu>
{
    [Tooltip("The different Avatars (Padle+Ball) a player can play as.")]
    [SerializeField]
    List<Avatar> availableAvatars;

    public int currentAvatarIndex;
    private Avatar currentAvatar;

    #region UI Parts
    [SerializeField]
    Image avatarImage;
    [SerializeField]
    TextMeshProUGUI avatarName;
    [SerializeField]
    TextMeshProUGUI avatarQuote;
    #endregion


    //TODO Move this to an other class e.g player select
    public void OnEnable()
    {
        availableAvatars = Resources.LoadAll("ScriptableObjects/Avatars", typeof(Avatar)).Cast<Avatar>().ToList();
        if (availableAvatars.Count == 0)
        {
            GameManager.Instance.DeclareError(Session.ErrorType.CantLoadAssets);
        }
        else
        {
            SetCurrentAvatar(currentAvatarIndex);
            UpdateVisuals();
        }
    }

    public void SetCurrentAvatar(int avatarID)
    {
        for (int i = 0; i < availableAvatars.Count; i++)
        {
            if (avatarID == availableAvatars[i].avatarID)
            {
                currentAvatar = availableAvatars[i];
            }
        }
        if (!currentAvatar)
        {
            currentAvatar = availableAvatars[0];
        }
    }

    private void UpdateVisuals()
    {
        avatarImage.sprite = currentAvatar.avatarIllustration;
        avatarName.text = currentAvatar.avatarName;
        avatarQuote.text = "\"" + currentAvatar.AvatarQuote + "\"";
    }

    public void NextAvatar()
    {
        if (currentAvatarIndex == availableAvatars.Count - 1)
        {
            currentAvatarIndex = 0;
        }
        else
        {
            currentAvatarIndex++;
        }
        SetCurrentAvatar(currentAvatarIndex);
        AudioManager.PlaySoundEffect(AudioAssets.Soundeffects.UINavigate, this.transform.position);
        UpdateVisuals();
    }
    public void PreviousAvatar()
    {
        if (currentAvatarIndex == 0)
        {
            currentAvatarIndex = availableAvatars.Count - 1;
        }
        else
        {
            currentAvatarIndex--;
        }

        SetCurrentAvatar(currentAvatarIndex);
        AudioManager.PlaySoundEffect(AudioAssets.Soundeffects.UINavigate, this.transform.position);
        UpdateVisuals();


    }
    public void SelectAvatar()
    {
        GameManager.Instance.SetPlayerAvatar(currentAvatar);
        AudioManager.PlaySoundEffect(AudioAssets.Soundeffects.UINavigate, this.transform.position);
        GameManager.Instance.StartCurrentLevel();

        MenuManager.Instance.CloseMenu(this);
    }

}
