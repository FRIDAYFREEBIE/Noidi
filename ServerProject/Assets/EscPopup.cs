using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class EscPopup : MonoBehaviourPun
{
    public GameObject popupObject; // Ȱ��ȭ�� ���� ������Ʈ ����
    public Slider volumeSlider; // �����̴��� ����Ű�� ���۷���
    public Image volumeImageLow; // ������ ���� ��
    public Image volumeImageHigh; // ������ ���� ��
    public PlayerContainer playerContainer; 


    private int count = 0;
    private string playerID;

    private void Start()
    {
        playerID = PhotonNetwork.LocalPlayer.UserId;

        popupObject.SetActive(false);

        volumeSlider.value = 0.5f;
    }

    void Update()
    {
        // Check if the ESC key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            popupObject.SetActive(true); // Ȱ��ȭ ���� ����
            count++;
        }

        if (count % 2 == 0) 
            Disabled();

        AudioListener.volume = volumeSlider.value;

        if (AudioListener.volume > 0.5)
        {
            volumeImageLow.gameObject.SetActive(false);
            volumeImageHigh.gameObject.SetActive(true);
        }
        else
        {
            volumeImageLow.gameObject.SetActive(true);
            volumeImageHigh.gameObject.SetActive(false);
        }
    }

    public void DisabledButton()
    {
        count--;

        popupObject.SetActive(false);
    }

    void Disabled()
    {
        popupObject.SetActive(false);
    }

    public void ToLobby()
    {
        playerContainer.ResetContainer(playerID);
        
        PhotonNetwork.Disconnect();
        PhotonNetwork.LoadLevel("Lobby");
    }
}
