<<<<<<< HEAD
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

public class MyDailyRoutine
{
    public static void AnswerIt(string caller)
    {
        Console.WriteLine($"*Chime! Chime!* Ah, it's {caller}! Picking up the receiver...");
    }

    public static void LetItRing(string caller)
    {
        Console.WriteLine($"*Buzz* {caller} is trying to reach you, but I'm busy. Letting it go to voicemail.");
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Setting up a brand new handheld device...");

        MobilePhone myPersonalDevice = new MobilePhone();

        Console.WriteLine("Connecting actions to the ringing notification...");
        myPersonalDevice.OnCallRing += AnswerIt;
        myPersonalDevice.OnCallRing += LetItRing;

        Console.WriteLine("\n--- Simulating Incoming Calls ---");

        myPersonalDevice.GetIncomingCall("Family Member");
        myPersonalDevice.GetIncomingCall("The Office");

        Console.WriteLine("\n--- Disconnecting one action ---");
        myPersonalDevice.OnCallRing -= LetItRing;

        myPersonalDevice.GetIncomingCall("Good Friend");

        Console.WriteLine("\n--- No actions left ---");
        myPersonalDevice.OnCallRing -= AnswerIt;

        myPersonalDevice.GetIncomingCall("Sales Caller");

        Console.ReadKey();
    }
=======
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

public class MyDailyRoutine
{
    public static void AnswerIt(string caller)
    {
        Console.WriteLine($"*Chime! Chime!* Ah, it's {caller}! Picking up the receiver...");
    }

    public static void LetItRing(string caller)
    {
        Console.WriteLine($"*Buzz* {caller} is trying to reach you, but I'm busy. Letting it go to voicemail.");
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Setting up a brand new handheld device...");

        MobilePhone myPersonalDevice = new MobilePhone();

        Console.WriteLine("Connecting actions to the ringing notification...");
        myPersonalDevice.OnCallRing += AnswerIt;
        myPersonalDevice.OnCallRing += LetItRing;

        Console.WriteLine("\n--- Simulating Incoming Calls ---");

        myPersonalDevice.GetIncomingCall("Family Member");
        myPersonalDevice.GetIncomingCall("The Office");

        Console.WriteLine("\n--- Disconnecting one action ---");
        myPersonalDevice.OnCallRing -= LetItRing;

        myPersonalDevice.GetIncomingCall("Good Friend");

        Console.WriteLine("\n--- No actions left ---");
        myPersonalDevice.OnCallRing -= AnswerIt;

        myPersonalDevice.GetIncomingCall("Sales Caller");

        Console.ReadKey();
    }
>>>>>>> 68a266f (sqlassignment)
}