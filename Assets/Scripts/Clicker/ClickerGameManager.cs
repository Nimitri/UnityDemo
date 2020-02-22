using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClickerGameManager : MonoBehaviour
{
    public ClickerGameManager I { get; private set; }


    [SerializeField] private TextMeshProUGUI cookieCountText;
    [SerializeField] private TextMeshProUGUI cookieCpsText;
    [SerializeField] private TextMeshProUGUI cookiesPerClickText;
    [SerializeField] private TextMeshProUGUI cookieCpsCostText;
    [SerializeField] private TextMeshProUGUI cookiesPerClickCostText;


    private int _cookieCount;

    public int CookieCount
    {
        get => _cookieCount;
        set
        {
            _cookieCount = value;
            cookieCountText.text = CookieCount + " Cookies";
        }
    }

    private int _cookieCps;

    public int CookieCps
    {
        get => _cookieCps;
        set
        {
            _cookieCps = value;
            cookieCpsText.text = CookieCps + "/s";
        }
    }

    private int _cookiesPerClick;

    public int CookiesPerClick
    {
        get => _cookiesPerClick;
        set
        {
            _cookiesPerClick = value;
            cookiesPerClickText.text = CookiesPerClick + " per Click";
        }
    }

    private int _cookieCpsCost;

    public int CookieCpsCost
    {
        get => _cookieCpsCost;
        set
        {
            _cookieCpsCost = value;
            cookieCpsCostText.text = "Cost: " + CookieCpsCost + " Cookies";
        }
    }

    private int _cookiesPerClickCost;

    public int CookiesPerClickCost
    {
        get => _cookiesPerClickCost;
        set
        {
            _cookiesPerClickCost = value;
            cookiesPerClickCostText.text = "Cost: " + CookiesPerClickCost + " Cookies";
        }
    }


    private void Awake()
    {
        if (I == null)
            I = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        CookieCount = 0;
        CookieCps = 0;
        CookieCpsCost = 10;
        CookiesPerClickCost = 5;
        CookiesPerClick = 1;
        InvokeRepeating(nameof(CookiesPerSecond), 1, 1);
    }

    public void ClickCookie()
    {
        CookieCount += CookiesPerClick;
    }

    public void CookiesPerSecond()
    {
        CookieCount += _cookieCps;
    }

    public void AddCps(int added)
    {
        if (CookieCount >= CookieCpsCost)
        {
            CookieCount -= CookieCpsCost;
            CookieCpsCost *= 5;
            CookieCps += added;
        }
    }

    public void AddCpc(int added)
    {
        if (CookieCount >= CookiesPerClickCost)
        {
            CookieCount -= CookiesPerClickCost;
            CookiesPerClickCost *= 2;
            CookiesPerClick += added;
        }
    }
}