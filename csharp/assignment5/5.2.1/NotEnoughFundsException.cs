<<<<<<< HEAD
﻿using System;

public class NotEnoughFundsException : Exception
{
    public NotEnoughFundsException() : base("Sorry, there aren't enough funds in your account.")
    {
    }

    public NotEnoughFundsException(string message) : base(message)
    {
    }

    public NotEnoughFundsException(string message, Exception innerProblem)
        : base(message, innerProblem)
    {
    }
=======
﻿using System;

public class NotEnoughFundsException : Exception
{
    public NotEnoughFundsException() : base("Sorry, there aren't enough funds in your account.")
    {
    }

    public NotEnoughFundsException(string message) : base(message)
    {
    }

    public NotEnoughFundsException(string message, Exception innerProblem)
        : base(message, innerProblem)
    {
    }
>>>>>>> 68a266f (sqlassignment)
}