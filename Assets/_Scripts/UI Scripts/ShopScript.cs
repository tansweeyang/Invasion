using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopScript : MonoBehaviour
{
    //-------------------------------------Class Variables--------------------------------------
    public TMP_Text moneyAmountText;
    public int amountMoney;
    public string amountKey = "amountKey";

    public GameObject errorPurchase;
    public GameObject mainMenu;
    public GameObject storeMenu;

    public Button buyMahineGunButton;
    public TMP_Text buyMachineGunButtonText;
    private int isOwnedMachineGun;

    public Button buyShotgunButton;
    public TMP_Text buyShotgunButtonText;
    private int isOwnedShotgun;

    public Button buySniperButton;
    public TMP_Text buySniperButtonText;
    private int isOwnedSniper;
    //------------------------------------------------------------------------------------------

    //-------------------------------------Script Lifecycle-------------------------------------
    //Setup
    private void Start()
    {
        isOwnedMachineGun = 1;
        LoadCoin();
        SetShopCoinAmountText();
        LoadOwnedWeapon();
    }
    //------------------------------------------------------------------------------------------

    //-------------------------------------Load and Save----------------------------------------
    //Sets coin amount
    public void SetShopCoinAmountText()
    {
        moneyAmountText.text = PlayerPrefs.GetInt(amountKey, amountMoney).ToString();
    }

    //Loads coin amount
    private void LoadCoin()
    {
        amountMoney += PlayerPrefs.GetInt(amountKey, amountMoney);
    }

    //Saves weapons owned
    private void SaveOwnedWeapon(Button buyButton)
    {
        if (buyButton == null)
        {
            return;
        }
        else if (buyButton == buyMahineGunButton)
        {
            isOwnedMachineGun = 1;
            PlayerPrefs.SetInt("machineGunOwnedKey", isOwnedMachineGun);
        }
        else if (buyButton == buyShotgunButton)
        {
            isOwnedShotgun = 1;
            PlayerPrefs.SetInt("shotgunOwnedKey", isOwnedShotgun);
        }
        else if (buyButton == buySniperButton)
        {
            isOwnedSniper = 1;
            PlayerPrefs.SetInt("sniperOwnedKey", isOwnedSniper);
        }
    }

    //Loads saved weapons owned, Sets weapons to owned
    private void LoadOwnedWeapon()
    {
        PlayerPrefs.GetInt("machineGunOwnedKey", isOwnedMachineGun);
        PlayerPrefs.GetInt("shotgunOwnedKey", isOwnedShotgun);
        PlayerPrefs.GetInt("sniperOwnedKey", isOwnedSniper);

        if (PlayerPrefs.GetInt("machineGunOwnedKey", isOwnedMachineGun) == 1)
        {
            SetToOwn(buyMahineGunButton, buyMachineGunButtonText);
        }
        if (PlayerPrefs.GetInt("shotgunOwnedKey", isOwnedShotgun) == 1)
        {
            SetToOwn(buyShotgunButton, buyShotgunButtonText);
        }
        if (PlayerPrefs.GetInt("sniperOwnedKey", isOwnedSniper) == 1)
        {
            SetToOwn(buySniperButton, buySniperButtonText);
        }
    }
    //------------------------------------------------------------------------------------------

    //-------------------------------------Button Actions---------------------------------------
    public void BuyMachineGun()
    {
        BuyGun(100, buyMahineGunButton, buyMachineGunButtonText);
    }

    public void BuyShotgun()
    {
        BuyGun(500, buyShotgunButton, buyShotgunButtonText);
    }

    public void BuySniper()
    {
        BuyGun(1000, buySniperButton, buySniperButtonText);
    }

    //Activates MainMenu
    public void Back()
    {
        //Sound
        FindObjectOfType<AudioManagerScript>().Play("Click Sound");

        //Activates MainMenu
        storeMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    //------------------------------------------------------------------------------------------

    //-------------------------------------Other Methods----------------------------------------
    public void BuyGun(int price, Button buyButton, TMP_Text buttonText)
    {
        if (PlayerPrefs.GetInt(amountKey, amountMoney) >= price)
        {
            //Sound
            FindObjectOfType<AudioManagerScript>().Play("Buy Sound");

            //
            amountMoney -= price;
            PlayerPrefs.SetInt(amountKey, amountMoney);
            moneyAmountText.text = PlayerPrefs.GetInt(amountKey, amountMoney).ToString();
            
            SetToOwn(buyButton, buttonText);
            SaveOwnedWeapon(buyButton);
        }
        else
        {
            errorPurchase.SetActive(true);
        }
    }

    //Delete in final
    //Resets game
    public void DeleteRef()
    {
        SetToNotKnown(buyShotgunButton, buyShotgunButtonText);
        SetToNotKnown(buySniperButton, buySniperButtonText);

        PlayerPrefs.DeleteAll();

        moneyAmountText.text = "0";
    }

    //Turns off interactable buy button
    private void SetToNotKnown(Button buyButton, TMP_Text buttonText)
    {
        buttonText.text = "Buy";
        buyButton.interactable = true;
    }

    //Turns on interactable buy button
    private void SetToOwn(Button buyButton, TMP_Text buttonText)
    {
        buyButton.interactable = false;
        buttonText.text = "Owned";
    }
    //------------------------------------------------------------------------------------------
}
