﻿using System;

public delegate void IncomingCallHandler(string callerIdentity);

public class MobilePhone
{
    public event IncomingCallHandler OnCallRing;

    public void GetIncomingCall(string callerInfo)
    {
        Console.WriteLine($"\n--- Your device is ringing from {callerInfo} ---");

        if (OnCallRing != null)
        {
            OnCallRing(callerInfo);
        }
        else
        {
            Console.WriteLine("Nobody's set up to respond to this ring! (No listeners connected)");
        }
    }
}

public class RingtonePlayer
{
    public static void PlayRingtone(string callerInfo)
    {
        Console.WriteLine("Playing ringtone...");
    }
}

public class ScreenDisplay
{
    public static void ShowCallerInfo(string callerInfo)
    {
        Console.WriteLine($"Displaying caller information: {callerInfo}");
    }
}

public class VibrationMotor
{
    public static void StartVibration(string callerInfo)
    {
        Console.WriteLine("Phone is vibrating...");
    }
}

public class MyDailyRoutine
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Setting up a brand new handheld device...\n");

        MobilePhone myPersonalDevice = new MobilePhone();

        Console.WriteLine("Connecting various actions to the ringing notification:");

        myPersonalDevice.OnCallRing += RingtonePlayer.PlayRingtone;
        myPersonalDevice.OnCallRing += ScreenDisplay.ShowCallerInfo;
        myPersonalDevice.OnCallRing += VibrationMotor.StartVibration;

        Console.WriteLine("\n--- Simulating an Incoming Call ---");

        myPersonalDevice.GetIncomingCall("Your Boss");

        Console.WriteLine("\n--- Demo Complete ---");
        Console.ReadKey();
    }
}