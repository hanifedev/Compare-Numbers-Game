﻿using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdmobManager : MonoBehaviour
{
    private BannerView bannerView;
  
    public void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });
        this.RequestBanner();
    }

    private void RequestBanner()
    {
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/6300978111";
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }

    public void showBanner()
    {
        bannerView.Show();
    }
}