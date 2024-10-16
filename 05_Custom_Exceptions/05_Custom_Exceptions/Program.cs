using System;

namespace Coding.Exercise
{
    //your code goes here

    public class TransactionData
    {
        public string Sender { get; init; }
        public string Receiver { get; init; }
        public decimal Amount { get; init; }
    }

    public class InvalidTransactionException : Exception
    {
        public TransactionData TransactionData { get; }

    }
} 
